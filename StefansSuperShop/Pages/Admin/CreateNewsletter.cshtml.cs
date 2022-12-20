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
        private readonly IMailService mailService;

        public CreateNewsletterModel (INewsletterService newsletterService, IMailService mailService
            )
        {
            this.newsletterService = newsletterService;
            this.mailService = mailService;
        }

        public bool emailFailed = false;
        public bool emailSucceeded = false;

        public async Task OnPost()
        {
            var body = Request.Form["email-body"];
            var subject = Request.Form["email-subject"];

            var statusCode = await SendEmail(subject, body);

            //TODO: alt injecera html koden? hur... vill helst också ta bort form... dvs skicka till ny sida, men det gick ej
            if (statusCode)
                emailSucceeded = true;
            else
                emailFailed = true;
        }

        public async Task<bool> SendEmail(string subject, string body)
        {
            //List<string> subscribers = newsletterService.GetSubscriberEmails();
            //TODO: fix so subscribers get seeded
            List<string> subscribers = new();
            subscribers.Add("brenna.mills@ethereal.email");

            var mailData = new MailData(subscribers, subject, body);

            bool result = await mailService.SendAsync(mailData, new CancellationToken());

            return result;

            //TODO: this doesn't work bc the returned statuscode can't be checked with iscompletedsuccessfully when calling
            //method is async (returned type becomes iactionresult instead of task<iactionresult>
            //if (result)
            //{
            //    return StatusCode(StatusCodes.Status200OK, "Mail has successfully been sent.");
            //}
            //else
            //{
            //    return StatusCode(StatusCodes.Status500InternalServerError, "An error occured. The Mail could not be sent.");
            //}
        }
    }
}
