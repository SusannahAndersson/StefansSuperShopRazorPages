using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StefansSuperShop.Data
{
    public class NewsletterSubscriber 
    {
        public NewsletterSubscriber() 
        {
            Newsletters = new HashSet<Newsletter>();
        }

        [Key]
        [Column("NewsletterSubscriberID")]
        public int NewsletterSubscriberId { get; set; }

        [Required]
        [StringLength(150)]
        public string Mail { get; set; }//TODO: email adress?
        public virtual ICollection<Newsletter> Newsletters { get; set; } 
    }
}

