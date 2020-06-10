using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace OnlineShoppingApp.UI.Models
{
    public class OrderDetail
    {
        [HiddenInput]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Order")]
        [Required]
        public int OrderId { get; set; }
        [ForeignKey("Product")]
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal UnitCost { get; set; }
        [HiddenInput]
        public virtual Order Order { get; set; }
        [HiddenInput]
        public virtual Product Product { get; set; }
    }
}