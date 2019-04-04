using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarmeBakker.Services

{
    public class NullMailService : IMailService
    {
        private readonly ILogger<NullMailService> _logger;

        public NullMailService(ILogger<NullMailService> logger)
        {
            _logger = logger;
        }

        public void SendMail(object p, string email, string v, string message)
        {
            throw new NotImplementedException();
        }

        public void SendMessage(string to, string subject, string body)
        {
            //log the message
            _logger.LogInformation($"To {to} subject: {subject} body: {body}");
        }

    }




}