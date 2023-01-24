using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StefansSuperShop.Services;

namespace StefansSuperShop.Pages
{
	public class ContactUsModel : PageModel
    {
        private readonly IMailService _mailService;

        public ContactUsModel(IMailService mailService)
        {
            _mailService = mailService;
        }

        public async Task OnPostSend()
        {
            var name = Request.Form["name"];
            var email = Request.Form["email"];
            var subject = Request.Form["subject"];

            var rawBody = Request.Form["body"];
            var body = $"From: {name}\nEmail: {email}\nMessage: {rawBody}";


            await _mailService.SendContactUsAsync(
                new ViewModels.MailData { Subject = subject, Body = body });
        }

        public void OnGet()
        {
        }
    }
}
