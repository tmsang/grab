namespace tmsang.application
{
    public interface IGuestService
    {
        TokenDto GuestLogin(GuestLoginDto loginDto);        
        void GuestRegister(GuestRegisterDto registerDto);        
        void GuestActivate(string token);
        void GuestForgotPassword(string email);        
        TokenDto GuestResetPassword(GuestResetPasswordDto resetPasswordDto);        
        TokenDto GuestChangePassword(GuestChangePasswordDto changePasswordDto);        
        void SendSmsCode(string phone);
    }
}
