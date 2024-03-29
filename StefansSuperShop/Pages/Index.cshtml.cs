﻿using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using StefansSuperShop.Data;
using StefansSuperShop.Services;
using StefansSuperShop.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace StefansSuperShop.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IKrisInfoService _krisInfoService;

        public List<TrendingCategory> TrendingCategories { get; set; }
        public List<Product> NewProducts { get; set; }
        public List<KrisInfo> KrisInformation { get; set; }

        public class TrendingCategory
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context, IKrisInfoService krisInfoService)
        {
            _logger = logger;
            _context = context;
            _krisInfoService = krisInfoService;
        }

        public async void OnGet()
        {
            TrendingCategories = _context.Categories.Take(3).Select(c =>
                new TrendingCategory { Id = c.CategoryId, Name = c.CategoryName }
            ).ToList();
        }
    }
}