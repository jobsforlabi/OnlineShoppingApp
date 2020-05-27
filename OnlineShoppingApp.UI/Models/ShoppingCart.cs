using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace OnlineShoppingApp.UI.Models
{
    public class ShoppingCart
    {
        [Key, HiddenInput]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int Quantity { get; set; }
        [ForeignKey("Product")]
        [Required]
        public int ProductId { get; set; }
        [ForeignKey("User")]
        [Required]
        public int UserId { get; set; }
        public DateTime DateCreated { get; set; }
        [HiddenInput]
        public virtual Product Product { get; set; }
        [HiddenInput]
        public virtual User User { get; set; }
    }
}