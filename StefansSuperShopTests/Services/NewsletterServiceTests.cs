using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StefansSuperShop.Data;
using StefansSuperShop.Services;

namespace StefansSuperShopTests.Services
{
    [TestClass]
	public class NewsletterServiceTests
	{
        private Mock<IdentityDbContext> dbContext;
        private Mock<NewsletterService> newsletterService;

		public NewsletterServiceTests()
		{
            dbContext = new Mock<IdentityDbContext>();
            newsletterService = new Mock<NewsletterService>();

            var _newsletterService = new FakeNewsletterService(dbContext.Object);

		}

        [TestMethod]
		public void New_user_can_subscribe()
		{
			var email = "test@test.com";

            newsletterService.Verify(userRep => userRep.AddSubscriber(email), Times.Once());

		}
	}

    public class FakeDbContext : IdentityDbContext
    {

    }

    public class FakeNewsletterService : INewsletterService
    {
        private IdentityDbContext _context;

        public FakeNewsletterService(IdentityDbContext context)
        {
            _context = context;
        }

        public bool AddNewsletter(Newsletter newsletter)
        {
            throw new NotImplementedException();
        }

        public void AddSubscriber(string mail)
        {
            throw new NotImplementedException();
        }

        public Newsletter CreateNewsletter(string title, string body, bool isSent)
        {
            throw new NotImplementedException();
        }

        public List<Newsletter> GetAllNewsletters()
        {
            throw new NotImplementedException();
        }

        public Newsletter GetNewsletter(int id)
        {
            throw new NotImplementedException();
        }

        public List<string> GetSubscriberEmails()
        {
            throw new NotImplementedException();
        }

        public bool IsEmailSubscriber(string email)
        {
            throw new NotImplementedException();
        }
    }
}

