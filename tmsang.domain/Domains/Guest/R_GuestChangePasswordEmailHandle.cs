using System.Collections.Generic;

namespace tmsang.domain
{
    public class R_GuestChangePasswordEmailHandle : Handles<R_GuestChangePasswordEvent>
    {
        readonly IAuth auth;
        readonly IEmailDispatcher emailDispatcher;
        readonly IEmailGenerator emailGenerator;

        public R_GuestChangePasswordEmailHandle(IAuth auth, IEmailGenerator emailGenerator, IEmailDispatcher emailDispatcher)
        {
            this.auth = auth;
            this.emailGenerator = emailGenerator;
            this.emailDispatcher = emailDispatcher;
        }

        public void Handle(R_GuestChangePasswordEvent args)
        {
            var holder = new EmailHolder
            {
                From = "sangnew2021@gmail.com",
                To = args.R_Guest.Email,
                Subject = "Change Password by Reset Password - GRAB BIKE",
                Parameters = new List<string> { args.R_Guest.FullName }
            };

            var message = this.emailGenerator.Generate(holder, E_AccountEmailTemplate.ResetPassword);
            this.emailDispatcher.Dispatch(message);
        }
    }
}
