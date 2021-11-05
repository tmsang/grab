using Microsoft.AspNetCore.Mvc;
using tmsang.application;

namespace tmsang.api
{
    [Route("api/admin")]
    public class AdminAccountController : Controller
    {
        readonly IAdminService accountService;

        public AdminAccountController(IAdminService accountService)
        {
            this.accountService = accountService;
        }

        [HttpPost("register")]
        public void Register(AdminRegisterDto registerDto)
        {
            try
            {
                this.accountService.AdminRegister(registerDto);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpGet("active")]
        public void Activate(string token)
        {
            try
            {
                this.accountService.AdminActivate(token);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost("login")]
        public TokenDto Login(AdminLoginDto loginDto)
        {
            try
            {
                return this.accountService.AdminLogin(loginDto);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost("forgot")]
        public void ForgotPassword(string email)
        {
            try
            {
                this.accountService.AdminForgotPassword(email);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost("reset")]
        public TokenDto ResetPassword(AdminResetPasswordDto resetPasswordDto)
        {
            try
            {
                return this.accountService.AdminResetPassword(resetPasswordDto);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [Authorize]
        [HttpPost("change")]
        public TokenDto ChangePassword(AdminChangePasswordDto changePasswordDto)
        {
            try
            {
                return this.accountService.AdminChangePassword(changePasswordDto);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpGet("smscode")]
        public void SmsCode(string phone)
        {
            try
            {
                this.accountService.SendSmsCode(phone);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
