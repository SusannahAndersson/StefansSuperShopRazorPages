using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StefansSuperShop.Data;
using StefansSuperShop.ViewModels;
using StefansSuperShop.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.AspNetCore.Http;

namespace StefansSuperShop.Pages.Admin
{
    public class ProcessSentNewsletterModel : PageModel
    {
        private readonly ApplicationDbContext context;
        private readonly INewsletterService newsletterService;
        private readonly IMailService mail;

        public ProcessSentNewsletterModel(ApplicationDbContext context, NewsletterService newsletterService,
            IMailService mail)
        {
            this.context = context;
            this.newsletterService = newsletterService;
            this.mail = mail;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> SendEmail(string subject, string body)
        {
            List<string> subscribers = newsletterService.GetSubscriberEmails();
            
            MailData mailData = new(subscribers, subject, body);

            bool result = await mail.SendAsync(mailData, new CancellationToken());

            if (result)
            {
                return StatusCode(StatusCodes.Status200OK, "Mail has successfully been sent.");
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured. The Mail could not be sent.");
            }
        }
    }
}
