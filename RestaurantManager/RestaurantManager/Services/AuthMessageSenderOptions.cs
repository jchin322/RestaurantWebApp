using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManager.Services
{
    public class AuthMessageSenderOptions
    {
        public string MailGunKey { get; set; }
        public string smtpPw { get; set; }
        public string SMSAccountIdentification { get; set; }
        public string SMSAccountPassword { get; set; }
        public string SMSAccountFrom { get; set; }
    }
}
