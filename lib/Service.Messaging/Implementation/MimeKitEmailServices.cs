using System;
using Alamut.Service.Messaging.Configration;
using Alamut.Service.Messaging.Contracts;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Logging;
using MimeKit;

namespace Alamut.Service.Messaging.Implementation
{
    public class MimeKitEmailServices : IEmailService
    {
        private readonly EmailConfig _emailConfig;
        private readonly ILogger<MimeKitEmailServices> _logger;

        public MimeKitEmailServices(EmailConfig emailConfig, ILogger<MimeKitEmailServices> logger)
        {
            _emailConfig = emailConfig;
            _logger = logger;
        }


        public void SendEmail<TMailId>(EmailBody<TMailId> body, Action<TMailId> onSuccess = null)
            where TMailId : struct
            => Send(body, _emailConfig, _logger, onSuccess); 

        private static void Send<TMailId>(EmailBody<TMailId> email,
            EmailConfig config,
            ILogger logger,
            Action<TMailId> onSuccess = null)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(config.From));
            message.To.Add(new MailboxAddress(email.To));
            message.Subject = email.Subject;

            message.Body = new TextPart("html")
            {
                Text = email.Body
            };

            try
            {
                using (var client = new SmtpClient())
                {
                    client.Connect(config.Server, config.Port);

                    client.AuthenticationMechanisms.Remove("XOAUTH2");

                    client.Authenticate(config.From, config.Password);

                    client.Send(message);

                    client.Disconnect(true);
                }

                onSuccess?.Invoke(email.Id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
            }
        }
    }
}
