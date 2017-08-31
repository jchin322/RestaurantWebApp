using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using RestaurantManager.Services;

namespace RestaurantManager.Services
{
    public class EmailSender : IEmailSender
    {
        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public AuthMessageSenderOptions Options { get; } // Access via secret manager.

        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Execute(Options.MailGunKey, email, subject, message);
        }

        public Task Execute(string apiKey, string email, string subject, string message)
        {
            // Send via SMTP
            MimeMessage mail = new MimeMessage();
            mail.From.Add(new MailboxAddress("Confirm Email", "myrestauranttestacc@gmail.com"));
            mail.To.Add(new MailboxAddress("", email));
            mail.Subject = subject;
            mail.Body = new TextPart("plain")
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect("smtp.mailgun.org", 587, false);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate("postmaster@sandboxd924539cd7ae4e36833ceaf877522b27.mailgun.org", Options.smtpPw);

                client.Send(mail);
                client.Disconnect(true);
                return Task.CompletedTask;
                // Send via mailgun API
                //RestClient client = new RestClient
                //{
                //    BaseUrl = new Uri("https://api.mailgun.net/v3"),
                //    Authenticator = new HttpBasicAuthenticator("api", apiKey)
                //};
                //RestRequest request = new RestRequest();
                //request.AddParameter("domain", "sandboxd924539cd7ae4e36833ceaf877522b27.mailgun.org", ParameterType.UrlSegment);
                //request.Resource = "{domain}/messages";
                //request.AddParameter("from", "myRestaurant <mailgun@sandboxd924539cd7ae4e36833ceaf877522b27.mailgun.org>");
                //request.AddParameter("to", email);
                //request.AddParameter("subject", subject);
                //request.AddParameter("text", message);
                //request.Method = Method.POST;
                //return client.ExecuteTaskAsync(request);
            }
        }
    }
}
