using Microsoft.AspNetCore.Mvc.RazorPages;
using StefansSuperShop.Data;
using System.Collections.Generic;
using System.Linq;

namespace StefansSuperShop.Pages.Admin
{
    public class SavedNewslettersModel : PageModel
    {
        private readonly ApplicationDbContext context;
        public List<NewsletterRow> Newsletters { get; set; }

        public class NewsletterRow
        {
            public int Id { get; set; }
            public string Subject { get; set; }
            public string Body { get; set; }
        }

        SavedNewslettersModel(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void OnGet()
        {
            Newsletters = context.Newsletters.Where(e.)
                .Select(e => new NewsletterRow
            {
                Id = e.NewsletterId,
                Subject = e.Title,
                Body = e.Body
            }).ToList();

        }
    }
}
