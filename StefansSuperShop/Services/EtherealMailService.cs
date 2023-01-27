using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using StefansSuperShop.Configuration;
using StefansSuperShop.Interfaces;
using StefansSuperShop.ViewModels;
using System;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace StefansSuperShop.Services
{
    public class EtherealMailService : IMailService
    {
        private readonly MailSettings _settings;

        public EtherealMailService(IOptions<MailSettings> settings)
        {
            _settings = settings.Value;
        }

        public async Task<bool> SendAsync(MailData mailData, CancellationToken ct = default)
        {
            try
            {
                var mail = GetMailContent(mailData);
                await SendMailAsync(mail, ct);

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        private async Task SendMailAsync(MimeMessage mail, CancellationToken ct)
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

        private MimeMessage GetMailContent(MailData mailData)
        {
            string jsonData = File.ReadAllText("C:\\Github\\StefansSuperShopRazorPages\\StefansSuperShop\\appsettings.Development.json");

            var dynamic = JsonSerializer.Deserialize<dynamic>(jsonData);

            var x = dynamic.ValueKind["MailSettings:DisplayName"];

            var mailSettings = new MailSettings()
            {
                DisplayName = dynamic.value[0]["MailSettings:DisplayName"]
            };

            var mail = new MimeMessage();

            // Sender - if the user has not entered "from", it's retrieved from appsettings instead
            mail.From.Add(new MailboxAddress(mailData.DisplayName ?? mailSettings.DisplayName, mailData.From ?? mailSettings.From));
            mail.Sender = new MailboxAddress(mailData.DisplayName ?? mailSettings.DisplayName, mailData.From ?? mailSettings.From);

            // Receiver (won't actually receive the email, since ethereal.email never actually sends it)
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
