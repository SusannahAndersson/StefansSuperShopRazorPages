using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace StefansSuperShop.Data
{
    public class DataInitializer
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public DataInitializer(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public void SeedData()
        {
            _dbContext.Database.Migrate();
            SeedRoles();
            SeedUsers();
            SeedCategories();
            SeedProducts();
        }

        private void SeedProducts()
        {
            addProduct("Beverages", "Chai", 18, 39, "Fantastic");
            addProduct("Beverages", "Chang", 19, 17, "Fantastic");
            addProduct("Condiments", "Aniseed Syrup", 10, 13, "Fantastic");
            addProduct("Condiments", "Chef Anton's Cajun Seasoning", 22, 53, "Fantastic");
            addProduct("Condiments", "Chef Anton's Gumbo Mix", 21, 0, "Fantastic");
            addProduct("Condiments", "Grandma's Boysenberry Spread", 25, 120, "Fantastic");
            addProduct("Produce", "Uncle Bob's Organic Dried Pears", 30, 15, "Fantastic");
            addProduct("Condiments", "Northwoods Cranberry Sauce", 40, 6, "Fantastic");
            addProduct("Meat/Poultry", "Mishi Kobe Niku", 97, 29, "Fantastic");
            addProduct("Seafood", "Ikura", 31, 31, "Fantastic");
            addProduct("Dairy Products", "Queso Cabrales", 21, 22, "Fantastic");
            addProduct("Dairy Products", "Queso Manchego La Pastora", 38, 86, "Fantastic");
            addProduct("Seafood", "Konbu", 6, 24, "Fantastic");
            addProduct("Produce", "Tofu", 23, 35, "Fantastic");
            addProduct("Condiments", "Genen Shouyu", 16, 39, "Fantastic");
            addProduct("Confections", "Pavlova", 17, 29, "Fantastic");
            addProduct("Meat/Poultry", "Alice Mutton", 39, 0, "Fantastic");
            addProduct("Seafood", "Carnarvon Tigers", 63, 42, "Fantastic");
            addProduct("Confections", "Teatime Chocolate Biscuits", 9, 25, "Fantastic");
            addProduct("Confections", "Sir Rodney's Marmalade", 81, 40, "Fantastic");
            addProduct("Confections", "Sir Rodney's Scones", 10, 3, "Fantastic");
            addProduct("Grains/Cereals", "Gustaf's Knäckebröd", 21, 104, "Fantastic");
            addProduct("Grains/Cereals", "Tunnbröd", 9, 61, "Fantastic");
            addProduct("Beverages", "Guaraná Fantástica", 5, 20, "Fantastic");
            addProduct("Confections", "NuNuCa Nuß-Nougat-Creme", 14, 76, "Fantastic");
            addProduct("Confections", "Gumbär Gummibärchen", 31, 15, "Fantastic");
            addProduct("Confections", "Schoggi Schokolade", 44, 49, "Fantastic");
            addProduct("Produce", "Rössle Sauerkraut", 46, 26, "Fantastic");
            addProduct("Meat/Poultry", "Thüringer Rostbratwurst", 124, 0, "Fantastic");
            addProduct("Seafood", "Nord-Ost Matjeshering", 26, 10, "Fantastic");
            addProduct("Dairy Products", "Gorgonzola Telino", 13, 0, "Fantastic");
            addProduct("Dairy Products", "Mascarpone Fabioli", 32, 9, "Fantastic");
            addProduct("Dairy Products", "Geitost", 3, 112, "Fantastic");
            addProduct("Beverages", "Sasquatch Ale", 14, 111, "Fantastic");
            addProduct("Beverages", "Steeleye Stout", 18, 20, "Fantastic");
            addProduct("Seafood", "Inlagd Sill", 19, 112, "Fantastic");
            addProduct("Seafood", "Gravad lax", 26, 11, "Fantastic");
            addProduct("Beverages", "Côte de Blaye", 264, 17, "Fantastic");
            addProduct("Beverages", "Chartreuse verte", 18, 69, "Fantastic");
            addProduct("Seafood", "Boston Crab Meat", 18, 123, "Fantastic");
            addProduct("Seafood", "Jack's New England Clam Chowder", 10, 85, "Fantastic");
            addProduct("Grains/Cereals", "Singaporean Hokkien Fried Mee", 14, 26, "Fantastic");
            addProduct("Beverages", "Ipoh Coffee", 46, 17, "Fantastic");
            addProduct("Condiments", "Gula Malacca", 19, 27, "Fantastic");
            addProduct("Seafood", "Rogede sild", 10, 5, "Fantastic");
            addProduct("Seafood", "Spegesild", 12, 95, "Fantastic");
            addProduct("Confections", "Zaanse koeken", 10, 36, "Fantastic");
            addProduct("Confections", "Chocolade", 13, 15, "Fantastic");
            addProduct("Confections", "Maxilaku", 20, 10, "Fantastic");
            addProduct("Confections", "Valkoinen suklaa", 16, 65, "Fantastic");
            addProduct("Produce", "Manjimup Dried Apples", 53, 20, "Fantastic");
            addProduct("Grains/Cereals", "Filo Mix", 7, 38, "Fantastic");
            addProduct("Meat/Poultry", "Perth Pasties", 33, 0, "Fantastic");
            addProduct("Meat/Poultry", "Tourtière", 7, 21, "Fantastic");
            addProduct("Meat/Poultry", "Pâté chinois", 24, 115, "Fantastic");
            addProduct("Grains/Cereals", "Gnocchi di nonna Alice", 38, 21, "Fantastic");
            addProduct("Grains/Cereals", "Ravioli Angelo", 20, 36, "Fantastic");
            addProduct("Seafood", "Escargots de Bourgogne", 13, 62, "Fantastic");
            addProduct("Dairy Products", "Raclette Courdavault", 55, 79, "Fantastic");
            addProduct("Dairy Products", "Camembert Pierrot", 34, 19, "Fantastic");
            addProduct("Condiments", "Sirop d'érable", 29, 113, "Fantastic");
            addProduct("Confections", "Tarte au sucre", 49, 17, "Fantastic");
            addProduct("Condiments", "Vegie-spread", 44, 24, "Fantastic");
            addProduct("Grains/Cereals", "Wimmers gute Semmelknödel", 33, 22, "Fantastic");
            addProduct("Condiments", "Louisiana Fiery Hot Pepper Sauce", 21, 76, "Fantastic");
            addProduct("Condiments", "Louisiana Hot Spiced Okra", 17, 4, "Fantastic");
            addProduct("Beverages", "Laughing Lumberjack Lager", 14, 52, "Fantastic");
            addProduct("Confections", "Scottish Longbreads", 13, 6, "Fantastic");
            addProduct("Dairy Products", "Gudbrandsdalsost", 36, 26, "Fantastic");
            addProduct("Beverages", "Outback Lager", 15, 15, "Fantastic");
            addProduct("Dairy Products", "Flotemysost", 22, 26, "Fantastic");
            addProduct("Dairy Products", "Mozzarella di Giovanni", 35, 14, "Fantastic");
            addProduct("Seafood", "Röd Kaviar", 15, 101, "Fantastic");
            addProduct("Produce", "Longlife Tofu", 10, 4, "Fantastic");
            addProduct("Beverages", "Rhönbräu Klosterbier", 8, 125, "Fantastic");
            addProduct("Beverages", "Lakkalikööri", 18, 57, "Fantastic");
            addProduct("Condiments", "Original Frankfurter grüne Soße", 13, 32, "Fantastic");
            _dbContext.SaveChanges();
        }

        private void addProduct(string category, string name, int pris, int stocklevel, string description)
        {
            if (_dbContext.Products.Any(e => e.ProductName == name)) return;
            _dbContext.Products.Add(new Products
            {
                ProductName = name,
                Category = _dbContext.Categories.First(c => c.CategoryName == category),
                UnitsInStock = Convert.ToInt16(stocklevel),
                UnitPrice = pris,
                Discontinued = false,
            });
        }

        private void SeedCategories()
        {
            AddCategoryIfNotExists("Beverages", "Soft drinks, coffees, teas, beers, and ales", "/img/categories/1.jpg");
            AddCategoryIfNotExists("Condiments", "Sweet and savory sauces, relishes, spreads, and seasonings", "/img/categories/2.jpg");
            AddCategoryIfNotExists("Confections", "Desserts, candies, and sweet breads", "/img/categories/3.jpg");
            AddCategoryIfNotExists("Dairy Products", "Cheeses", "/img/categories/4.jpg");
            AddCategoryIfNotExists("Grains/Cereals", "Breads, crackers, pasta, and cereal", "/img/categories/5.jpg");
            AddCategoryIfNotExists("Meat/Poultry", "Prepared meats", "/img/categories/6.jpg");
            AddCategoryIfNotExists("Produce", "Dried fruit and bean curd", "/img/categories/7.jpg");
            AddCategoryIfNotExists("Seafood", "Seaweed and fish", "/img/categories/8.jpg");
            _dbContext.SaveChanges();
        }

        private void AddCategoryIfNotExists(string name, string description, string image)
        {
            if (_dbContext.Categories.Any(e => e.CategoryName == name)) return;
            _dbContext.Categories.Add(new Categories
            {
                CategoryName = name,
                Description = description,
                ImageUrl = image
            });
        }

        private void SeedRoles()
        {
            var role = _dbContext.Roles.FirstOrDefault(r => r.Name == "Admin");
            if (role == null)
            {
                _dbContext.Roles.Add(new IdentityRole { Name = "Admin", NormalizedName = "Admin" });
            }
            role = _dbContext.Roles.FirstOrDefault(r => r.Name == "Customer");
            if (role == null)
            {
                _dbContext.Roles.Add(new IdentityRole { Name = "Customer", NormalizedName = "Customer" });
            }
            _dbContext.SaveChanges();
        }

        private void SeedUsers()
        {
            AddUserIfNotExists("stefan.holmberg@systementor.se", "Hejsan123#", new string[] { "Admin" });
            AddUserIfNotExists("stefan.holmberg@customer.systementor.se", "Hejsan123#", new string[] { "Customer" });
        }

        private void AddUserIfNotExists(string userName, string password, string[] roles)
        {
            if (_userManager.FindByEmailAsync(userName).Result != null) return;

            var user = new IdentityUser
            {
                UserName = userName,
                Email = userName,
                EmailConfirmed = true
            };
            var result = _userManager.CreateAsync(user, password).Result;
            var r = _userManager.AddToRolesAsync(user, roles).Result;
        }
    }
}