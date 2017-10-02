using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Microsoft.Extensions.Options;

namespace RestaurantManager.Services
{
    public class SMSSender : ISMSSender
    {
        public SMSSender(IOptions<AuthMessageSenderOptions> options)
        {
            Options = options.Value;
        }

        public AuthMessageSenderOptions Options { get; set; }

        public Task SendSMSAsync(string number, string message)
        {
            var accoundSid = Options.SMSAccoundIdentification;
            var authToken = Options.SMSAccountPassword;
            var smsFrom = Options.SMSAccountFrom;

            // Initialize client with auth info.
            TwilioClient.Init(accoundSid, authToken);
            // Create the sms message payload.
            var msg = MessageResource.Create(
                to: new PhoneNumber(number),
                from: new PhoneNumber(smsFrom),
                body: message);
            return Task.FromResult(0);
        }
    }
}
