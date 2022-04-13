using System;
using System.Collections.Generic;

namespace tmsang.domain
{
    public class R_GuestCreatedEmailHandle : Handles<R_GuestCreatedEvent>
    {
        readonly IAuth auth;
        readonly IEmailDispatcher emailDispatcher;
        readonly IEmailGenerator emailGenerator;

        public R_GuestCreatedEmailHandle(IAuth auth, IEmailGenerator emailGenerator, IEmailDispatcher emailDispatcher)
        {
            this.auth = auth;
            this.emailGenerator = emailGenerator;
            this.emailDispatcher = emailDispatcher;
        }

        public void Handle(R_GuestCreatedEvent args)
        {
            var mixInfo = args.R_Guest.Id.ToString() + ";" + args.R_Guest.Email + ";" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var activeAccountTokenLink = Singleton.Instance.UrlApi + "/api/guest/active?token=" + auth.GenerateToken(mixInfo, E_AccountType.Guest.ToString(), 60 * 24 * 1);

            var holder = new EmailHolder
            {
                From = "sangnew2021@gmail.com",
                To = args.R_Guest.Email,
                Subject = "Active Account for Registration - GRAB BIKE",
                Parameters = new List<string> { args.R_Guest.FullName, activeAccountTokenLink }
            };

            var message = this.emailGenerator.Generate(holder, E_AccountEmailTemplate.ActivateAccount);
            this.emailDispatcher.Dispatch(message);
        }
    }
}
