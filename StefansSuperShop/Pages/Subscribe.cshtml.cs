using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StefansSuperShop.Services;
using System.ComponentModel.DataAnnotations;

namespace StefansSuperShop.Pages
{
    [BindProperties]
    public class SubscribeModel : PageModel
    {

        private readonly INewsletterService _newsletterService;

        public SubscribeModel(INewsletterService newsletterService)
        {
            _newsletterService = newsletterService;
        }

        [EmailAddress]
        [Required]
        public string Email { get; set; }
        public bool AlreadySignedUp { get; set; } = false;
        public void OnGet()
        {
        }
        [ValidateAntiForgeryToken()]
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (_newsletterService.IsEmailSubscriber(Email))
                {
                    AlreadySignedUp = true;
                }
                else
                {
                    _newsletterService.AddSubscriber(Email);
                }
            }
            return Page();
        }
    }
}
