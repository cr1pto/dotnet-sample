using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net.Mail;

namespace Samples.Web.Auth.AspIdentityImpl
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            await CreateSmtpClient()
            .SendMailAsync(CreateEmail(email, subject, htmlMessage));
        }

        private SmtpClient CreateSmtpClient()
        {
            return new SmtpClient("localhost", 587);
        }

        private MailMessage CreateEmail(string email, string subject, string htmlMessage)
        {
            var mailAddress = new MailAddress(email);

            var message = new MailMessage
            {
                From = mailAddress,
                To = { mailAddress },
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true
            };
            return message;
        }
    }
}
