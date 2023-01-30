using Microsoft.AspNetCore.Mvc.RazorPages;
using StefansSuperShop.Interfaces;
using StefansSuperShop.Services;

namespace StefansSuperShop.Pages.Admin
{
    public class EditNewsletterModel : PageModel
    {
        private readonly INewsletterService newsletterService;
        private readonly IMailService mailService;

        public EditNewsletterModel(INewsletterService newsletterService, IMailService mailService
            )
        {
            this.newsletterService = newsletterService;
            this.mailService = mailService;
        }

        public string EndMessage { get; set; }
        public int NewsletterId { get; set; }

        public void OnGet()
        {
            NewsletterId = int.Parse(Request.Form["newsletter-id"]);
        }
    }
}
