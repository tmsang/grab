using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using tmsang.domain;
using Microsoft.Extensions.Configuration;
using Twilio.Types;

namespace tmsang.infra
{
    public class SmsProvider : ISmsProvider
    {
        private readonly IConfiguration _config;

        public SmsProvider(IConfiguration config)
        {
            _config = config;
        }

        public void Send(string phone, string code)
        {
            var accountSid = _config.GetSection("Twilio:AccountSid").Value;
            var authToken = _config.GetSection("Twilio:AuthToken").Value;
            var myPhoneForTwilio = _config.GetSection("Twilio:MyPhone").Value;

            TwilioClient.Init(accountSid, authToken);

            var messageOptions = new CreateMessageOptions(new PhoneNumber(phone));              // To
            messageOptions.MessagingServiceSid = "MGa9348787a321179f689e1b65c3bfd2f8";          // From (duoc cap boi Twilio)
            messageOptions.Body = $"GRAB - [{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] Your code is {code}";

            var message = MessageResource.Create(messageOptions);

            Console.WriteLine(message.Sid);
        }
    }
}
