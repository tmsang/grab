using System.Collections.Generic;

namespace tmsang.domain
{
    public class R_AdminChangePasswordEmailHandle : Handles<R_AdminChangePasswordEvent>
    {
        readonly IAuth auth;
        readonly IEmailDispatcher emailDispatcher;
        readonly IEmailGenerator emailGenerator;

        public R_AdminChangePasswordEmailHandle(IAuth auth, IEmailGenerator emailGenerator, IEmailDispatcher emailDispatcher)
        {
            this.auth = auth;
            this.emailGenerator = emailGenerator;
            this.emailDispatcher = emailDispatcher;
        }

        public void Handle(R_AdminChangePasswordEvent args)
        {
            var holder = new EmailHolder
            {
                From = "sangnew2021@gmail.com",
                To = args.R_Admin.Email,
                Subject = "Change Password by Reset Password - GRAB BIKE",
                Parameters = new List<string> { args.R_Admin.FullName }
            };

            var message = this.emailGenerator.Generate(holder, E_AccountEmailTemplate.ResetPassword);
            this.emailDispatcher.Dispatch(message);
        }
    }
}
