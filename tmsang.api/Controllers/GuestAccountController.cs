using Microsoft.AspNetCore.Mvc;
using System;
using tmsang.application;

namespace tmsang.api
{
    [Route("api/guest")]
    public class GuestAccountController : Controller
    {
        readonly IGuestService accountService;

        public GuestAccountController(IGuestService accountService)
        {
            this.accountService = accountService;
        }

        [HttpPost("register")]
        public void Register(GuestRegisterDto registerDto)
        {
            try
            {
                this.accountService.GuestRegister(registerDto);
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
                this.accountService.GuestActivate(token);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("login")]
        public TokenDto Login(GuestLoginDto loginDto)
        {
            try
            {
                return this.accountService.GuestLogin(loginDto);
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
                this.accountService.GuestForgotPassword(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("reset")]
        public TokenDto ResetPassword(GuestResetPasswordDto resetPasswordDto)
        {
            try
            {
                return this.accountService.GuestResetPassword(resetPasswordDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Authorize]
        [HttpPost("change")]
        public TokenDto ChangePassword(GuestChangePasswordDto changePasswordDto)
        {
            try
            {
                return this.accountService.GuestChangePassword(changePasswordDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("smscode")]
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
