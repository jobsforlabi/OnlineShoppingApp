using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace OnlineShoppingApp.UI.Models
{
    public class Role
    {
        [Key, HiddenInput]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(25)]
        [Index("IX_RoleName", IsUnique = true)]
        public string RoleName { get; set; }
        [MaxLength(150)]
        public string Description { get; set; }
        [HiddenInput]
        public virtual ICollection<User> Users { get; set; }
    }
}