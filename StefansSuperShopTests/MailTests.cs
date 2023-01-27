using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StefansSuperShop.Configuration;
using StefansSuperShop.Data;
using StefansSuperShop.Interfaces;
using StefansSuperShop.Services;
using StefansSuperShop.ViewModels;
using StefansSuperShop.Pages.Admin;
using Microsoft.Extensions.Options;
using StefansSuperShop.Pages.Admin;
using System.Text.Json;

namespace StefansSuperShopTests
{
    [TestClass]
    public class MailTests
    {
        private IMailService sut;
        private IOptions<MailSettings> mailSettings;


        public MailTests()
        {
            string jsonData = File.ReadAllText("C:\\Github\\StefansSuperShopRazorPages\\StefansSuperShop\\appsettings.json");

            mailSettings = JsonSerializer.Deserialize<IOptions<MailSettings>>(jsonData);

            sut = new EtherealMailService(mailSettings);
        }

        [TestMethod]
        public async Task Should_send_an_email()
        {
            var to = new List<string>();
            to.Add("test@test.com");

            var subject = "";
            var body = "";

            MailData mailData = new MailData(to, subject, body);

            var result = await sut.SendAsync(mailData, new CancellationToken());

            Assert.IsTrue(result);
        }
    }
}