using System.Collections.Generic;
using System.Linq;
using StefansSuperShop.Data;

namespace StefansSuperShop.Services
{
	public interface INewsletterService
	{
		public Newsletter GetNewsletter(int id);
		public List<Newsletter> GetAllNewsletters();
		public bool CreateNewsletter(Newsletter newsletter);
	}
	public class NewsletterService : INewsletterService
	{
        private readonly ApplicationDbContext _context;

        public NewsletterService(ApplicationDbContext context)
		{
			_context = context;
		}

		public Newsletter? GetNewsletter(int id)
		{
			//TODO: add error handling if id is not found
			return _context.Newsletters.Find(id);
		}

		public List<Newsletter> GetAllNewsletters()
		{
			return _context.Newsletters.ToList();
		}
		public bool CreateNewsletter(Newsletter newsletter)
		{
			_context.Newsletters.Add(newsletter);
			return _context.SaveChanges() > 0;
		}

	}
}

