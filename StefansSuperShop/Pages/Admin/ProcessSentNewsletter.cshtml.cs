using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StefansSuperShop.Data;
using System.Collections.Generic;
using StefansSuperShop.Services;

namespace StefansSuperShop.Pages.Admin
{
    public class ProcessSentNewsletterModel : PageModel
    {
        private readonly ApplicationDbContext context;
        private readonly NewsletterService newsletterService;

        public ProcessSentNewsletterModel(ApplicationDbContext context, NewsletterService newsletterService)
        {
            this.context = context;
            this.newsletterService = newsletterService;
        }

        public List<string> SubscriberEmails { get; set; }

        public void OnGet()
        {
            SubscriberEmails = newsletterService.GetSubscriberEmails();
        }
    }
}
