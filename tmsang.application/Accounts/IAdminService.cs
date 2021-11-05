namespace tmsang.application
{
    public interface IAdminService
    {                
        TokenDto AdminLogin(AdminLoginDto loginDto);     
        void AdminRegister(AdminRegisterDto registerDto);
        void AdminActivate(string token);
        void AdminForgotPassword(string email);
        TokenDto AdminResetPassword(AdminResetPasswordDto resetPasswordDto);
        TokenDto AdminChangePassword(AdminChangePasswordDto changePasswordDto);
        void SendSmsCode(string phone);
    }
}
