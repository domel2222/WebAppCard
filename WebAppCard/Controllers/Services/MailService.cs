using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppCard.Controllers.Services
{
    public class MailService : IMailService
    {
        private readonly ILogger<MailService> _logger;

        public MailService(ILogger<MailService> logger)
        {
            this._logger = logger;
        }


        public void SendMessage(string to, string subject, string body)
        {
            //log message
            _logger.LogInformation($"To: {to} {subject} ");
        }
    }
}
