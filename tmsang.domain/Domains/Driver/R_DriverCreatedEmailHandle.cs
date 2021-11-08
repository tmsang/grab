using System;
using System.Collections.Generic;

namespace tmsang.domain
{
    public class R_DriverCreatedEmailHandle : Handles<R_DriverCreatedEvent>
    {
        readonly IAuth auth;
        readonly IEmailDispatcher emailDispatcher;
        readonly IEmailGenerator emailGenerator;

        public R_DriverCreatedEmailHandle(IAuth auth, IEmailGenerator emailGenerator, IEmailDispatcher emailDispatcher)
        {
            this.auth = auth;
            this.emailGenerator = emailGenerator;
            this.emailDispatcher = emailDispatcher;
        }

        public void Handle(R_DriverCreatedEvent args)
        {
            var mixInfo = args.R_Driver.Id.ToString() + ";" + args.R_Driver.Email + ";" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var activeAccountTokenLink = Singleton.Instance.UrlApi + "api/driver/active?token=" + auth.GenerateToken(mixInfo, E_AccountType.Driver.ToString(), 60 * 24 * 1);

            var holder = new EmailHolder
            {
                From = "sangnew2021@gmail.com",
                To = args.R_Driver.Email,
                Subject = "Active Account for Registration - GRAB BIKE",
                Parameters = new List<string> { args.R_Driver.FullName, activeAccountTokenLink }
            };

            var message = this.emailGenerator.Generate(holder, E_AccountEmailTemplate.ActivateAccount);
            this.emailDispatcher.Dispatch(message);
        }
    }
}
