using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace OnlineShoppingApp.UI.Models
{
    public class Category
    {
        [Key, HiddenInput]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string CategoryName { get; set; }
        [MaxLength(150)]
        public string Description { get; set; }
        [HiddenInput]
        public virtual ICollection<Product> Products { get; set; }
    }
}