using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StefansSuperShop.Data
{
    public partial class Categories
    {
        public Categories()
        {
            Products = new HashSet<Products>();
        }

        [Key]
        [Column("CategoryID")]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Category name may only be a maximum of 20 characters")]
        public string CategoryName { get; set; }

        [StringLength(1000, ErrorMessage = "Description may only be a maximum of 1000 characters")]
        public string Description { get; set; }

        [StringLength(500, ErrorMessage = "Image path may only be a maximum of 500 characters")]
        public string ImageUrl { get; set; }

        [InverseProperty("Category")]
        public virtual ICollection<Products> Products { get; set; }
    }
}