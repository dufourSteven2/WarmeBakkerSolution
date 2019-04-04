//using Microsoft.Extensions.Configuration;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace WarmeBakker.Services
//{
//    public class EmailSender : IEmailSender
//    {
//        private readonly IConfiguration _configuration;

//        public EmailSender(IConfiguration configuration)
//        {
//            _configuration = configuration;
//        }

//        public Task SendEmailAsync(string email, string subject, string message)
//        {

//            var apiKey = _configuration.GetSection("SendgridApiKey").Value;  //api value voor sendgrid die zich in config.json bevindt
//            return Execute(apiKey, subject, message, email);
//        }
//        public Task Execute(string apiKey, string subject, string message, string email)
//        {
//            var client = new SendGridClient(apiKey);
//            var msg = new SendGridMessage()
//            {
//                From = new EmailAddress("benny.vanderschaeghe@gmail.com"),

//                Subject = subject,
//                PlainTextContent = message,
//                HtmlContent = message
//            };
//            msg.AddTo(new EmailAddress(email));
//            return client.SendEmailAsync(msg);
//        }
//    }
//}
