using Microsoft.AspNetCore.Http;
using System;
using tmsang.domain;

namespace tmsang.application
{
    public class DriverService: IDriverService
    {        
        readonly IRepository<R_Driver> driverAccountRepository;        

        readonly IStorage storage;
        readonly IAuth auth;

        readonly R_DriverDomainService accountDomainService;
        readonly IHttpContextAccessor http;
        readonly IUnitOfWork unitOfWork;

        public DriverService(            
            IRepository<R_Driver> driverAccountRepository,            

            R_DriverDomainService accountDomainService,
            IStorage storage,
            IAuth auth,
            IHttpContextAccessor http,
            IUnitOfWork unitOfWork)
        {            
            this.driverAccountRepository = driverAccountRepository;            
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
        // DRIVER
        //=========================================================
        public void DriverRegister(DriverRegisterDto registerDto)
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

            var driver = R_Driver.Create(registerDto.FullName, registerDto.PersonalId,
                                            registerDto.Avatar, registerDto.Address, registerDto.Phone, registerDto.Email,
                                            hash.Hash, hash.Salt);

            var bike = B_DriverBike.Create(driver.Id, registerDto.PlateNo, registerDto.BikeOwner, registerDto.EngineNo,
                                            registerDto.ChassisNo, registerDto.BikeType, registerDto.Brand, registerDto.RegistrationDate);

            // bike is just branch -> should use root (Driver)
            driver.Bikes.Add(bike);                          // vi Bike quan he 1-1 voi Driver Account, nen ta add the nay, chu 1-n thi di tu root            

            this.unitOfWork.ForceBeginTransaction();            
            this.driverAccountRepository.Add(driver);
        }

        public void DriverActivate(string token)
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

            var driver = this.accountDomainService.GetDriverByEmailIgnoreActive(email);
            if (driver == null)
            {
                throw new Exception("This account is not exists");
            }
            driver.Activate();            

            this.unitOfWork.ForceBeginTransaction();
            this.driverAccountRepository.Update(driver);
        }

        public TokenDto DriverLogin(DriverLoginDto loginDto)
        {
            // validate input
            loginDto.EmptyValidation();

            // doi chieu email - co ton tai trong database
            var user = this.accountDomainService.GetDriverByEmail(loginDto.Email);
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
                jwt = auth.GenerateToken(user.Id.ToString(), E_AccountType.Driver.ToString(), Constants.LOGIN_TOKEN_EXPIRED),
                FullName = user.FullName,
                Phone = user.Phone,
                Email = user.Email
            };
        }

        public void DriverForgotPassword(string email)
        {
            // kiem tra su ton tai user
            var user = this.accountDomainService.GetDriverByEmail(email);
            if (user == null)
            {
                throw new Exception("This account is not exists");
            }
            // send ma SMS code
            SendSmsCode(user.Phone);
        }

        public TokenDto DriverResetPassword(DriverResetPasswordDto resetPasswordDto)
        {
            // validate input (required)
            resetPasswordDto.EmptyValidation();
            // kiem tra su ton tai user
            var user = this.accountDomainService.GetDriverByEmail(resetPasswordDto.Email);
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
            // update password vao bang R_Admin
            var hash = auth.EncryptPassword(resetPasswordDto.NewPassword);
            user.ResetPassword(hash.Hash, hash.Salt);

            this.unitOfWork.ForceBeginTransaction();
            this.driverAccountRepository.Update(user);
            // return token
            return new TokenDto
            {
                jwt = auth.GenerateToken(user.Id.ToString(), E_AccountType.Driver.ToString(), Constants.LOGIN_TOKEN_EXPIRED)
            };
        }

        public TokenDto DriverChangePassword(DriverChangePasswordDto changePasswordDto)
        {
            // validate input (required)
            changePasswordDto.EmptyValidation();
            // lay thong tin user trong HttpContext
            var user = (R_Driver)http.HttpContext.Items["User"];
            // kiem tra SMS code (duoc goi luc Forgot password)
            var code = this.storage.SmsGetCode(user.Phone);
            if (code != changePasswordDto.SmsCode)
            {
                throw new Exception("SMS Code is invalid");
            }
            // update password vao bang R_Admin
            var hash = auth.EncryptPassword(changePasswordDto.NewPassword);
            user.ResetPassword(hash.Hash, hash.Salt);

            this.unitOfWork.ForceBeginTransaction();
            this.driverAccountRepository.Update(user);
            // return token
            return new TokenDto
            {
                jwt = auth.GenerateToken(user.Id.ToString(), E_AccountType.Driver.ToString(), Constants.LOGIN_TOKEN_EXPIRED)
            };
        }

        public void PushPosition(string lat, string lng)
        {
            if (string.IsNullOrEmpty(lat) || string.IsNullOrEmpty(lng))
            {
                throw new Exception("Latitude or Longitude is null or empty");
            }
            double _lat = 0.0, _lng = 0.0;
            if (!double.TryParse(lat, out _lat) || !double.TryParse(lng, out _lng))
            {
                throw new Exception("Latitude or Longitude is invalid number (double)");
            }

            var user = (R_Driver)http.HttpContext.Items["User"];
            user.PushPosition(_lat, _lng);

            this.unitOfWork.ForceBeginTransaction();
            this.driverAccountRepository.Update(user);
        }
    }
}
