﻿using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using StefansSuperShop.Data;
using System.Collections.Generic;
using System.Linq;
using StefansSuperShop.Services;

namespace StefansSuperShop.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _context;
        private readonly INewsletterService _newsletterService;

        public class TrendingCategory
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public List<TrendingCategory> TrendingCategories { get; set; }

        public List<Product> NewProducts { get; set; }

        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context, INewsletterService newsletterService)
        {
            _logger = logger;
            _context = context;
            _newsletterService = newsletterService;
        }

        public void OnGet()
        {
            TrendingCategories = _context.Categories.Take(3).Select(c =>
                new TrendingCategory { Id = c.CategoryId, Name = c.CategoryName }
            ).ToList();
        }

        public void OnPost()
        {
            if(Request.Form["email"].Count > 0)
            {
                _newsletterService.AddSubscriber(Request.Form["email"]);
            }


        }
    }
}