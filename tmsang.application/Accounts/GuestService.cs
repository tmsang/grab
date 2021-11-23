using Microsoft.AspNetCore.Http;
using System;
using tmsang.domain;

namespace tmsang.application
{
    public class GuestService: IGuestService
    {        
        readonly IRepository<R_Guest> guestAccountRepository;

        readonly IStorage storage;
        readonly IAuth auth;

        readonly R_GuestDomainService accountDomainService;
        readonly IHttpContextAccessor http;
        readonly IUnitOfWork unitOfWork;

        public GuestService(            
            IRepository<R_Guest> guestAccountRepository,
            R_GuestDomainService accountDomainService,
            IStorage storage,
            IAuth auth,
            IHttpContextAccessor http,
            IUnitOfWork unitOfWork)
        {            
            this.guestAccountRepository = guestAccountRepository;
            this.accountDomainService = accountDomainService;
            this.storage = storage;
            this.auth = auth;
            this.http = http;

            this.unitOfWork = unitOfWork;
        }

        public void SendSmsCode(string phone)
        {
            // send ma SMS code
            var code = (new Random()).Next(1000000, 9999999).ToString();
            this.storage.SmsSet(phone, code);
        }

        //=========================================================
        // GUEST
        //=========================================================
        public void GuestRegister(GuestRegisterDto registerDto)
        {
            // check null or empty
            registerDto.EmptyValidation();
            // kiem tra su ton tai
            var isExists = this.accountDomainService.CanExists(registerDto.Email, registerDto.Phone);
            if (isExists)
            {
                throw new Exception("This email or phone is exists");
            }
            // kiem tra SMS code (duoc goi luc Forgot password)
            var code = this.storage.SmsGetCode(registerDto.Phone);
            if (code != registerDto.SmsCode)
            {
                throw new Exception("SMS Code is invalid");
            }
            // add thong tin dang ky vao bang R_Admin -> raise event (email)
            var hash = auth.EncryptPassword(registerDto.Password);
            var account = R_Guest.Create(registerDto.FullName, registerDto.Phone, registerDto.Email, hash.Hash, hash.Salt);
            this.unitOfWork.ForceBeginTransaction();
            this.guestAccountRepository.Add(account);
        }

        public void GuestActivate(string token)
        {
            // check token
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new Exception("Token is null or empty");
            }

            // decrypt token => email, expire date, ...
            var isTokenValid = auth.ValidateCurrentToken(token);
            if (!isTokenValid)
            {
                throw new Exception("Token is not valid");
            }

            // check expired date (nameid = ecd6672c-25b0-4e8a-82be-0d9e276b1a77;sangnews2014@gmail.com;2021-11-04 13:10:55)
            var exp = auth.GetClaim(token, "exp");
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(long.Parse(exp));
            if (DateTime.Now > dateTimeOffset.LocalDateTime)
            {
                throw new Exception("Expired date is over");
            }

            // set isActive for email
            var nameid = auth.GetClaim(token, "nameid");
            var nameids = nameid.Split(';');
            var email = nameids[1];

            var user = this.accountDomainService.GetGuestByEmailIgnoreActive(email);
            if (user == null)
            {
                throw new Exception("This account is not exists");
            }

            user.Activate();
            this.unitOfWork.ForceBeginTransaction();
            this.guestAccountRepository.Update(user);
        }

        public TokenDto GuestLogin(GuestLoginDto loginDto)
        {
            // validate input
            loginDto.EmptyValidation();

            // doi chieu email - co ton tai trong database
            var user = this.accountDomainService.GetGuestByEmail(loginDto.Email);
            if (user == null)
            {
                throw new Exception("This account is not exists");
            }
            // doi chieu password - va kiem tra password hop le
            var isPasswordMatched = auth.VerifyPassword(loginDto.Password, user.Salt, user.Password);
            if (!isPasswordMatched)
            {
                throw new Exception("Password is invalid");
            }
            // neu thoa thi return token
            return new TokenDto
            {
                jwt = auth.GenerateToken(user.Id.ToString(), E_AccountType.Guest.ToString(), Constants.LOGIN_TOKEN_EXPIRED)
            };
        }
        public void GuestForgotPassword(string email)
        {
            // kiem tra su ton tai user
            var user = this.accountDomainService.GetGuestByEmail(email);
            if (user == null)
            {
                throw new Exception("This account is not exists");
            }
            // send ma SMS code
            SendSmsCode(user.Phone);
        }
        public TokenDto GuestResetPassword(GuestResetPasswordDto resetPasswordDto)
        {
            // validate input (required)
            resetPasswordDto.EmptyValidation();
            // kiem tra su ton tai user
            var user = this.accountDomainService.GetGuestByEmail(resetPasswordDto.Email);
            if (user == null)
            {
                throw new Exception("This account is not exists");
            }
            // kiem tra SMS code (duoc goi luc Forgot password)
            var code = this.storage.SmsGetCode(user.Phone);
            if (code != resetPasswordDto.SmsCode)
            {
                throw new Exception("SMS Code is invalid");
            }
            // doi chieu password -va kiem tra password hop le
            var isPasswordMatched = auth.VerifyPassword(resetPasswordDto.OldPassword, user.Salt, user.Password);
            if (!isPasswordMatched)
            {
                throw new Exception("Old Password is invalid");
            }
            // update password vao bang R_Guest
            var hash = auth.EncryptPassword(resetPasswordDto.NewPassword);
            user.ResetPassword(hash.Hash, hash.Salt);            
            this.unitOfWork.ForceBeginTransaction();
            this.guestAccountRepository.Update(user);
            // return token
            return new TokenDto
            {
                jwt = auth.GenerateToken(user.Id.ToString(), E_AccountType.Guest.ToString(), Constants.LOGIN_TOKEN_EXPIRED)
            };
        }
        public TokenDto GuestChangePassword(GuestChangePasswordDto changePasswordDto)
        {
            // validate input (required)
            changePasswordDto.EmptyValidation();
            // lay thong tin user trong HttpContext
            var user = (R_Guest)http.HttpContext.Items["User"];
            // kiem tra SMS code (duoc goi luc Forgot password)
            var code = this.storage.SmsGetCode(user.Phone);
            if (code != changePasswordDto.SmsCode)
            {
                throw new Exception("SMS Code is invalid");
            }
            // update password vao bang R_Admin
            var hash = auth.EncryptPassword(changePasswordDto.NewPassword);
            user.ResetPassword(hash.Hash, hash.Salt);            
            this.guestAccountRepository.Update(user);
            // return token
            return new TokenDto
            {
                jwt = auth.GenerateToken(user.Id.ToString(), E_AccountType.Guest.ToString(), Constants.LOGIN_TOKEN_EXPIRED)
            };
        }
    }
}
