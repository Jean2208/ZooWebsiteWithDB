using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace ZooWebsite.Models
{
    public class ZooLogin
    {
        [Key]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        
        
        [Required(ErrorMessage = "Password is required")]

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
