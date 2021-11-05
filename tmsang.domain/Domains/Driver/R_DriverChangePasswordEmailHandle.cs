using System.Collections.Generic;

namespace tmsang.domain
{
    public class R_DriverChangePasswordEmailHandle : Handles<R_DriverChangePasswordEvent>
    {
        readonly IAuth auth;
        readonly IEmailDispatcher emailDispatcher;
        readonly IEmailGenerator emailGenerator;

        public R_DriverChangePasswordEmailHandle(IAuth auth, IEmailGenerator emailGenerator, IEmailDispatcher emailDispatcher)
        {
            this.auth = auth;
            this.emailGenerator = emailGenerator;
            this.emailDispatcher = emailDispatcher;
        }

        public void Handle(R_DriverChangePasswordEvent args)
        {
            var holder = new EmailHolder
            {
                From = "sangnew2021@gmail.com",
                To = args.R_Driver.Email,
                Subject = "Change Password by Reset Password - GRAB BIKE",
                Parameters = new List<string> { args.R_Driver.FullName }
            };

            var message = this.emailGenerator.Generate(holder, E_AccountEmailTemplate.ResetPassword);
            this.emailDispatcher.Dispatch(message);
        }
    }
}
