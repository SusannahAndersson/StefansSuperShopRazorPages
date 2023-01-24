using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using StefansSuperShop.Configuration;
using StefansSuperShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StefansSuperShop.Services
{
    public interface IMailService //TODO: move to new interface folder?
    {
        Task<bool> SendAsync(MailData mailData, CancellationToken ct);
        public Task<bool> SendContactUsAsync(MailData mailData);
    }

    public class MailService : IMailService
    {
        private readonly MailSettings _settings;

        public MailService(IOptions<MailSettings> settings)
        {
            _settings = settings.Value;
        }

        public async Task<bool> SendContactUsAsync(MailData mailData)
        {
            mailData.To = new List<string>{_settings.ContactUsEmail};

            return await SendAsync(mailData);
        }

        public async Task<bool> SendAsync(MailData mailData, CancellationToken ct = default)
        {
            try
            {
                var mail = GetMail(mailData);
                await SendMailAsync(_settings.UserName, _settings.Password, mail, ct);

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        private async Task SendMailAsync(string userName, string Password,
            MimeMessage mail, CancellationToken ct)
        {
            using var smtp = new SmtpClient();

            if (_settings.UseSSL)
            {
                await smtp.ConnectAsync(_settings.Host, _settings.Port, SecureSocketOptions.SslOnConnect, ct);
            }
            else if (_settings.UseStartTls)
            {
                await smtp.ConnectAsync(_settings.Host, _settings.Port, SecureSocketOptions.StartTls, ct);
            }

            await smtp.AuthenticateAsync(_settings.UserName, _settings.Password, ct);
            await smtp.SendAsync(mail, ct);
            await smtp.DisconnectAsync(true, ct);
        }

        private MimeMessage GetMail(MailData mailData)//TODO: needs to be refactored further
        {
            var mail = new MimeMessage();

            // Sender - if the user has not entered "from", it's retrieved from appsettings instead
            mail.From.Add(new MailboxAddress(_settings.DisplayName, mailData.From ?? _settings.From));
            mail.Sender = new MailboxAddress(mailData.DisplayName ?? _settings.DisplayName, mailData.From ?? _settings.From);

            // Receiver
            foreach (string mailAddress in mailData.To)
                mail.To.Add(MailboxAddress.Parse(mailAddress));

            // Add Content to Mime Message
            var body = new BodyBuilder();
            mail.Subject = mailData.Subject;
            body.HtmlBody = mailData.Body;
            mail.Body = body.ToMessageBody();

            return mail;
        }
    }
}
