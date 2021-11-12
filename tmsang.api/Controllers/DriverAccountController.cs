using Microsoft.AspNetCore.Mvc;
using System;
using tmsang.application;

namespace tmsang.api
{
    [Route("api/driver")]
    public class DriverAccountController : Controller
    {
        readonly IDriverService accountService;

        public DriverAccountController(IDriverService accountService)
        {
            this.accountService = accountService;
        }

        [HttpPost("register")]
        public void Register(DriverRegisterDto registerDto)
        {
            try
            {
                this.accountService.DriverRegister(registerDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("active")]
        public void Activate(string token)
        {
            try
            {
                this.accountService.DriverActivate(token);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("login")]
        public TokenDto Login(DriverLoginDto loginDto)
        {
            try
            {
                return this.accountService.DriverLogin(loginDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("forgot")]
        public void ForgotPassword(string email)
        {
            try
            {
                this.accountService.DriverForgotPassword(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("reset")]
        public TokenDto ResetPassword(DriverResetPasswordDto resetPasswordDto)
        {
            try
            {
                return this.accountService.DriverResetPassword(resetPasswordDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Authorize]
        [HttpPost("change")]
        public TokenDto ChangePassword(DriverChangePasswordDto changePasswordDto)
        {
            try
            {
                return this.accountService.DriverChangePassword(changePasswordDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("smscode")]
        public void SmsCode(string phone)
        {
            try
            {
                this.accountService.SendSmsCode(phone);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
