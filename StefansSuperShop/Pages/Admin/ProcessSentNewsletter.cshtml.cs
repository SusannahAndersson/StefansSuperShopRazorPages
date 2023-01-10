using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StefansSuperShop.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StefansSuperShop.Pages.Admin
{
    public class ProcessSentNewsletterModel : PageModel
    {
        //private readonly INewsletterService newsletterService;
        //private readonly IMailService mail;

        public ProcessSentNewsletterModel(
            )
        {
            //this.newsletterService = newsletterService;
            //this.mail = mail;
        }

        public void OnPost()
        {

        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> SendEmail(string subject, string body)
        {
            List<string> subscribers = new();

            MailData mailData = new(subscribers, subject, body);

            //bool result = await mail.SendAsync(mailData, new CancellationToken());

            if (true)
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
