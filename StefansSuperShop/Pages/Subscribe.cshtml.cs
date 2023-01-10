using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StefansSuperShop.Services;

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
        public void OnGet()
        {
        }
        [ValidateAntiForgeryToken()]
        public IActionResult OnPost()
        {
            if (ModelState.IsValid && !_newsletterService.IsEmailSubscriber(Email))
            {
                _newsletterService.AddSubscriber(Email);   
            }
            return Page();
        }
    }
}
