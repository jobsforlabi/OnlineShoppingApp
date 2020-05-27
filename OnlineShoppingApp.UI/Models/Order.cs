using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingApp.UI.Models
{
    public class Order
    {
        [Key, HiddenInput]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        public DateTime ShipDate { get; set; }
        [HiddenInput]
        public virtual User User { get; set; }
        [HiddenInput]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}