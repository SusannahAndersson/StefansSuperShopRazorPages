using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StefansSuperShop.Configuration;
using StefansSuperShop.Interfaces;
using StefansSuperShop.Services;
using StefansSuperShop.ViewModels;

namespace StefansSuperShopTests.Services
{
    [TestClass]
    public class EtherealMailTests
    {
        private IMailService sut;


        public EtherealMailTests()
        {
            MailSettings settings = new()
            {
                DisplayName = "Stefans Super Shop",
                From = "info@stefansupershop.com",
                UserName = "stefan.crist87@ethereal.email",
                Password = "dg1fmzfYd8hx7UH1XQ",
                Host = "smtp.ethereal.email",
                Port = 587,
                UseSSL = false,
                UseStartTls = true
            };

            Mock<IOptions<MailSettings>> mailSettings = new Mock<IOptions<MailSettings>>();
            mailSettings.Setup(x => x.Value).Returns(settings);

            sut = new EtherealMailService(mailSettings.Object);
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