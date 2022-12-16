using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StefansSuperShop.Data;
using System.Threading.Tasks;

namespace StefansSuperShop.Pages.Admin.Category
{
    public class DetailsModel : PageModel
    {
        private readonly StefansSuperShop.Data.ApplicationDbContext _context;

        public DetailsModel(StefansSuperShop.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Categories Categories { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Categories = await _context.Categories.FirstOrDefaultAsync(m => m.CategoryId == id);

            if (Categories == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}