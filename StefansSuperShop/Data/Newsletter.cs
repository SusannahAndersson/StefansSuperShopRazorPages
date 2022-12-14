using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StefansSuperShop.Data
{
	public class Newsletter
	{
		public Newsletter()
            {
                this.Subscribers = new HashSet<NewsletterSubscriber>();
            }

        [Key]
        [Column("NewsletterID")]
        public int NewsletterId { get; set; }
        [Required]
        [StringLength(150)]
        public string Title { get; set; }
        public string Body { get; set; }
        public virtual ICollection<NewsletterSubscriber> Subscribers { get; set; }
    }
}
