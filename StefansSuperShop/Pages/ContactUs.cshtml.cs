using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StefansSuperShop.Interfaces;
using System.Threading.Tasks;

namespace StefansSuperShop.Pages
{
    public class ContactUsModel : PageModel
    {
        private readonly IMailService _mailService;

        public string resultsMessage;

        public ContactUsModel(IMailService mailService)
        {
            _mailService = mailService;
        }

        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Subject { get; set; }
        [BindProperty]
        public string Body { get; set; }

        public async Task OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return;
            }

            var body = $"From: {Name}\nEmail: {Email}\nMessage: {Body}";


            if (await _mailService.SendContactUsAsync(
                new ViewModels.MailData { Subject = Subject, Body = body }))
            {
                resultsMessage = "Message was successfully sent";
            }
            else
            {
                resultsMessage = "Something went wrong, please try again later";
            }

        }

        public IActionResult OnGet()
        {
            return Page();
        }
    }
}
