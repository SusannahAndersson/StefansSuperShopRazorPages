using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StefansSuperShop.Services;
using StefansSuperShop.ViewModels;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StefansSuperShop.Pages.Admin
{
    public class CreateNewsletterModel : PageModel
    {
        private readonly INewsletterService newsletterService;
        private readonly IMailService mail;

        public CreateNewsletterModel (INewsletterService newsletterService, IMailService mailService
            )
        {
            this.newsletterService = newsletterService;
            this.mail = mail;
        }
        public void OnPost()
        {
            var body = Request.Form["email-body"];
            var subject = Request.Form["email-subject"];

            var result = SendEmail(subject, body);
        }

        public async Task<IActionResult> SendEmail(string subject, string body)
        {
            List<string> subscribers = newsletterService.GetSubscriberEmails();

            var mailData = new MailData(subscribers, subject, body);

            var ct = new CancellationToken();

            bool result = await mail.SendAsync(mailData, ct);

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
