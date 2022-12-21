using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StefansSuperShop.Data;
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

        public string endMessage;

        public async Task OnPost()
        {
            var body = Request.Form["email-body"];
            var subject = Request.Form["email-subject"];
            List<string> subscribers = newsletterService.GetSubscriberEmails();

            var emailResult = await SendEmail(subject, body, subscribers);

            //TODO: alt injecera html koden? hur... vill helst ocks� ta bort form... dvs skicka till ny sida, men det gick ej
            if (emailResult)
            {
                Newsletter newsletter = newsletterService.CreateNewsletter(subject, body);
                var dbResult = newsletterService.AddNewsletter(newsletter);

                if (dbResult)
                    endMessage = "The newsletter was sent out successfully.";
                else
                    endMessage = "The newsletter was sent, but the database could not be updated.";
            }

            else
                endMessage = "The email was not sent.";      
        }

        public async Task<bool> SendEmail(string subject, string body, List<string> subscribers)
        {
            var mailData = new MailData(subscribers, subject, body);

            bool result = await mailService.SendAsync(mailData, new CancellationToken());

            return result;
        }
    }
}
