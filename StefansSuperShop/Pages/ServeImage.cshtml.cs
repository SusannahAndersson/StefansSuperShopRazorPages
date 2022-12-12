using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using StefansSuperShop.Data;
using System;

namespace StefansSuperShop.Pages
{
    public class ServeImageModel : PageModel
    {
        private readonly ILogger<ServeImageModel> _logger;
        private readonly ApplicationDbContext _context;

        public ServeImageModel(ILogger<ServeImageModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
        }

        public IActionResult OnGetCategoryImage(int id)
        {
            var offset = 78;
            var imageData = _context.Categories.Find(id).Picture;

            var bytes = new byte[imageData.Length - offset];

            Array.Copy(imageData, offset, bytes, 0, bytes.Length);

            return File(bytes, "image/png");
        }
    }
}