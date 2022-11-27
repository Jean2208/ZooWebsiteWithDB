using System.ComponentModel.DataAnnotations;

namespace ZooWebsite.Models
{
    public class employees
    {
        public int id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(50, ErrorMessage = "Maximum length is 50.")]
        public string? first_name { get; set; }


        [StringLength(50, ErrorMessage = "Maximum length is 50.")]
        public string? middle_name { get; set; }


        [Required(ErrorMessage = "This field is required")]
        [StringLength(50, ErrorMessage = "Maximum length is 50.")]
        public string? last_name { get; set; }


        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Date)]
        public DateTime birth_date { get; set; }



        [Required]
        public string? sex { get; set; } //drop down menu



        [Required(ErrorMessage = "This field is required")]
        [StringLength(50, ErrorMessage = "Maximum length is 50.")]
        public string? address_1 { get; set; }



        [StringLength(50, ErrorMessage = "Maximum length is 50.")]
        public string? address_2 { get; set; }


        [Required(ErrorMessage = "This field is required")]
        [StringLength(50, ErrorMessage = "Maximum length is 50.")]
        public string? city { get; set; }



        [Required]
        public string? state { get; set; } //drop down menu.



        [Required(ErrorMessage = "This field is required")]
        public int? zip { get; set; }

        
        [DataType(DataType.PhoneNumber)]
        
        public string? phone { get; set; }


        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.EmailAddress)]
        public string? email { get; set; }



        [StringLength(50, ErrorMessage = "Maximum length is 50.")]
        public string? job { get; set; }









        // get every attribute from employees table, we want to make use of all the data.

    }
}
