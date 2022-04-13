using System;
using DMedics.Services.Interfaces;
using Microsoft.Extensions.Logging;
using SendGrid;
using SendGrid.Helpers.Mail;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace DMedics.Services.Services
{
    public class NotificationService : INotificationService
    {
        private ILogger<AppointmentService> _logger;

        public NotificationService(ILogger<AppointmentService> logger)
        {
           _logger = logger;

        }
        public async void SendEmail(string toEmail, string subject, string messageContent)
        {
            try
            {
                var apiKey = "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";
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress("test@example.com", "DMedics");
                var to = new EmailAddress(toEmail);
                var htmlContent = $"<strong>{messageContent}</strong>";
                var msg = MailHelper.CreateSingleEmail(from, to, subject, messageContent, htmlContent);
                var response = await client.SendEmailAsync(msg);
            }
            catch (Exception e)
            {
                _logger.LogError("SendEmail Exception: e", e.Message);
            }
        }

        public void SendTextMessage(string phoneNumber, string messageContent)
        {
            try
            {
                var accountSid = "ACe9321c9e357c13e9ad074052239a40aa";
                var authToken = "b760d1d24bbedae11009024662bbef59";
                TwilioClient.Init(accountSid, authToken);

                var messageOptions = new CreateMessageOptions(
                    new PhoneNumber(phoneNumber));

                messageOptions.MessagingServiceSid = "MGdb52f966f84e576c1fbb6ead4cb41d3e";
                messageOptions.Body = messageContent;

                var message = MessageResource.Create(messageOptions);
                Console.WriteLine(message.Body);

            }
            catch (Exception e)
            {
                _logger.LogError("SendTextMessage Exception: e", e.Message);
            }
        }
    }
}
