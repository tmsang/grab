namespace tmsang.application
{
    public interface IDriverService
    {        
        TokenDto DriverLogin(DriverLoginDto loginDto);                
        void DriverRegister(DriverRegisterDto registerDto);        
        void DriverActivate(string token);        
        void DriverForgotPassword(string email);                
        TokenDto DriverResetPassword(DriverResetPasswordDto resetPasswordDto);                
        TokenDto DriverChangePassword(DriverChangePasswordDto changePasswordDto);        
        void SendSmsCode(string phone);
        void PushPosition(string lat, string lng);
    }
}
