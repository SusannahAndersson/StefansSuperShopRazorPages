using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StefansSuperShop.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StefansSuperShop.Pages.Admin.Category
{
    public class IndexModel : PageModel
    {
        private readonly StefansSuperShop.Data.ApplicationDbContext _context;

        public IndexModel(StefansSuperShop.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Categories> Categories { get; set; }

        public async Task OnGetAsync()
        {
            Categories = await _context.Categories.ToListAsync();
        }
    }
}