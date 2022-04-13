using System.Collections.Generic;

namespace tmsang.application
{
    public interface IAdminService
    {                
        // quan ly rieng admin account
        TokenDto AdminLogin(AdminLoginDto loginDto);     
        void AdminRegister(AdminRegisterDto registerDto);
        void AdminActivate(string token);
        void AdminForgotPassword(string email);
        TokenDto AdminResetPassword(AdminResetPasswordDto resetPasswordDto);
        TokenDto AdminChangePassword(AdminChangePasswordDto changePasswordDto);
        void SendSmsCode(string phone);
        string EncryptPassword(string password);

        //quan ly cac account khac
        IEnumerable<ActiveAccountDto> GetAccounts(string type);
        void ActionOnAccount(ActionOnAccountDto action);
    }
}
