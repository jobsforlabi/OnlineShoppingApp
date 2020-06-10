using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace OnlineShoppingApp.UI.Models
{
    public class Product
    {
        [HiddenInput]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("ProductCategory")]
        [Required]
        public int CategoryId { get; set; }
        [MaxLength(20)]
        [Required]
        public string ModelNumber { get; set; }
        [MaxLength(50)]
        [Required]
        public string ModelName { get; set; }
        [Column(TypeName = "image")]
        public byte[] ProductImage { get; set; }
        [Required]
        public decimal UnitCost { get; set; }
        [MaxLength(150)]
        public string Description { get; set; }
        [HiddenInput]
        public virtual Category ProductCategory { get; set; }
        [HiddenInput]
        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}