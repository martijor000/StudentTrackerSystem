﻿using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace StudentTrackerSystem.Server.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly ILogger _logger;
        /// <summary>
        /// SendGridKey should be set in secret manager
        /// </summary>
        private readonly string SendGridKey = "";//add api key here

        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor,
                           ILogger<EmailSender> logger)
        {
            Options = optionsAccessor.Value;
            _logger = logger;
        }

        public AuthMessageSenderOptions Options { get; } //Set with Secret Manager.

        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            if (string.IsNullOrEmpty(SendGridKey))
            {
                throw new Exception("Null SendGridKey");
                //throw new Exception("Null SendGridKey");
            }
            await Execute(SendGridKey, subject, message, toEmail);
            //await Execute(Options.SendGridKey, subject, message, toEmail);
        }

        public async Task Execute(string apiKey, string subject, string message, string toEmail)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("it330centralia@gmail.com", "Action Needed"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(toEmail));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);
            var response = await client.SendEmailAsync(msg);
            _logger.LogInformation(response.IsSuccessStatusCode
                                   ? $"Email to {toEmail} queued successfully!"
                                   : $"Failure Email to {toEmail}");
        }
    }
}
