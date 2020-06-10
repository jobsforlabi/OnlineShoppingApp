using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace OnlineShoppingApp.UI.Models
{
    public class User
    {
        [HiddenInput]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(15)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(15)]
        public string LastName { get; set; }
        [Required, DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
        [Required, HiddenInput]
        [MaxLength(25)]
        public string Salt { get; set; }
        [NotMapped]
        [Required]
        [MaxLength(50)]
        [System.ComponentModel.DataAnnotations.Compare("Password")]
        public string MatchPassword { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        [HiddenInput]
        public virtual Role Role { get; set; }
    }
}