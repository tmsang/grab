﻿using Microsoft.AspNetCore.Http;
using System;
using tmsang.domain;

namespace tmsang.application
{
    public class AccountService : IAccountService
    {
        readonly IRepository<R_Admin> adminAccountRepository;
        readonly IRepository<R_Driver> driverAccountRepository;
        readonly IRepository<R_Guest> guestAccountRepository;
        
        readonly IStorage storage;
        readonly IAuth auth;

        readonly AccountDomainService accountDomainService;
        readonly IHttpContextAccessor http;
        readonly IUnitOfWork unitOfWork;

        public AccountService(
            IRepository<R_Admin> adminAccountRepository,
            IRepository<R_Driver> driverAccountRepository,
            IRepository<R_Guest> guestAccountRepository,            

            AccountDomainService accountDomainService,
            IStorage storage,
            IAuth auth,
            IHttpContextAccessor http,
            IUnitOfWork unitOfWork)
        {
            this.adminAccountRepository = adminAccountRepository;
            this.driverAccountRepository = driverAccountRepository;
            this.guestAccountRepository = guestAccountRepository;            

            this.accountDomainService = accountDomainService;
            this.storage = storage;
            this.auth = auth;
            this.http = http;

            this.unitOfWork = unitOfWork;
        }

        public void SendSmsCode(string phone) {
            // send ma SMS code
            var code = (new Random()).Next(1000000, 9999999).ToString();
            this.storage.SmsSet(phone, code);
        }

        //=========================================================
        // ADMIN
        //=========================================================
        public void AdminRegister(AdminRegisterDto registerDto)
        {
            // check null or empty
            registerDto.EmptyValidation();
            // kiem tra su ton tai
            var isExists = this.accountDomainService.CanExists(registerDto.Email, registerDto.Phone);
            if (isExists) {
                throw new Exception("This email or phone is exists");
            }
            // kiem tra SMS code (duoc goi luc Forgot password) - Phone format: +84 919239080  (khong co so 0 dau nhe)
            var code = this.storage.SmsGetCode(registerDto.Phone);
            if (code != registerDto.SmsCode)
            {
                throw new Exception("SMS Code is invalid");
            }
            // add thong tin dang ky vao bang R_Admin -> raise event (email)
            var hash = auth.EncryptPassword(registerDto.Password);
            var account = R_Admin.Create(registerDto.FullName, registerDto.Email, registerDto.Phone, registerDto.Address, hash.Hash, hash.Salt);
            this.unitOfWork.ForceBeginTransaction();
            this.adminAccountRepository.Add(account);
        }

        public TokenDto AdminLogin(AdminLoginDto loginDto)
        {
            // validate input
            loginDto.EmptyValidation();

            // doi chieu email - co ton tai trong database
            var user = this.accountDomainService.GetAdminByEmail(loginDto.Email);
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
                jwt = auth.GenerateToken(user.Id.ToString(), E_AccountType.Admin.ToString())
            };
        }

        public void AdminForgotPassword(string email)
        {
            // kiem tra su ton tai user
            var user = this.accountDomainService.GetAdminByEmail(email);
            if (user == null)
            {
                throw new Exception("This account is not exists");
            }
            // send ma SMS code
            SendSmsCode(user.Phone);
        }

        public TokenDto AdminResetPassword(AdminResetPasswordDto resetPasswordDto)
        {
            // validate input (required)
            resetPasswordDto.EmptyValidation();
            // kiem tra su ton tai user
            var user = this.accountDomainService.GetAdminByEmail(resetPasswordDto.Email);
            if (user == null)
            {
                throw new Exception("This account is not exists");
            }
            // kiem tra SMS code (duoc goi luc Forgot password)
            var code = this.storage.SmsGetCode(user.Phone);
            if (code != resetPasswordDto.SmsCode) {
                throw new Exception("SMS Code is invalid");
            }
            // update password vao bang R_Admin
            var hash = auth.EncryptPassword(resetPasswordDto.NewPassword);
            user.ResetPassword(hash.Hash, hash.Salt);
            this.unitOfWork.ForceBeginTransaction();
            this.adminAccountRepository.Update(user);
            // return token
            return new TokenDto {
                jwt = auth.GenerateToken(user.Id.ToString(), E_AccountType.Admin.ToString())
            };
        }

        public TokenDto AdminChangePassword(AdminChangePasswordDto changePasswordDto)
        {
            // validate input (required)
            changePasswordDto.EmptyValidation();
            // lay thong tin user trong HttpContext
            var user = (R_Admin)http.HttpContext.Items["User"];
            // kiem tra SMS code (duoc goi luc Forgot password)
            var code = this.storage.SmsGetCode(user.Phone);
            if (code != changePasswordDto.SmsCode)
            {
                throw new Exception("SMS Code is invalid");
            }
            // update password vao bang R_Admin
            var hash = auth.EncryptPassword(changePasswordDto.NewPassword);
            user.ResetPassword(hash.Hash, hash.Salt);
            this.adminAccountRepository.Update(user);
            // return token
            return new TokenDto
            {
                jwt = auth.GenerateToken(user.Id.ToString(), E_AccountType.Admin.ToString())
            };
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

            var account = R_Driver.Create(registerDto.FullName, registerDto.PersonalId, 
                                            registerDto.Avatar, registerDto.Address, registerDto.Phone, registerDto.Email, 
                                            hash.Hash, hash.Salt);

            var bike = B_DriverBike.Create(account.Id, registerDto.PlateNo, registerDto.BikeOwner, registerDto.EngineNo,
                                            registerDto.ChassisNo, registerDto.BikeType, registerDto.Brand, registerDto.RegistrationDate);
            
            this.unitOfWork.ForceBeginTransaction();

            // bike is just branch -> should use root (Driver)
            account.Bikes.Add(bike);                          // vi Bike quan he 1-1 voi Driver Account, nen ta add the nay, chu 1-n thi di tu root

            this.driverAccountRepository.Add(account);            
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
                jwt = auth.GenerateToken(user.Id.ToString(), E_AccountType.Driver.ToString())
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
            user.ResetPassword(resetPasswordDto.NewPassword);
            this.unitOfWork.ForceBeginTransaction();
            this.driverAccountRepository.Update(user);
            // return token
            return new TokenDto
            {
                jwt = auth.GenerateToken(user.Id.ToString(), E_AccountType.Driver.ToString())
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
            user.ResetPassword(changePasswordDto.NewPassword);
            this.driverAccountRepository.Update(user);
            // return token
            return new TokenDto
            {
                jwt = auth.GenerateToken(user.Id.ToString(), E_AccountType.Driver.ToString())
            };
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
                jwt = auth.GenerateToken(user.Id.ToString(), E_AccountType.Guest.ToString())
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
            // update password vao bang R_Admin
            user.ResetPassword(resetPasswordDto.NewPassword);
            this.unitOfWork.ForceBeginTransaction();
            this.guestAccountRepository.Update(user);
            // return token
            return new TokenDto
            {
                jwt = auth.GenerateToken(user.Id.ToString(), E_AccountType.Guest.ToString())
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
            user.ResetPassword(changePasswordDto.NewPassword);
            this.guestAccountRepository.Update(user);
            // return token
            return new TokenDto
            {
                jwt = auth.GenerateToken(user.Id.ToString(), E_AccountType.Guest.ToString())
            };
        }

    }
}
