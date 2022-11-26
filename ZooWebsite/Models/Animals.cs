using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooWebsite.Models
{
    public class animals
    {

        public int id { get; set; }



        [Required(ErrorMessage = "Your animal must have a name.")]
        [StringLength(50, ErrorMessage = "Maximum length is 50.")]
        public string? animal_name { get; set; }



        [Required(ErrorMessage = "Every animal has a scientific name.")]
        [StringLength(50, ErrorMessage = "Maximum length is 50.")]
        public string? scientific_name { get; set; }


        
        [Required(ErrorMessage = "Your animal is missing a description.")]
        [StringLength(500, ErrorMessage = "Maximum length is 500.")]
        public string? description { get; set; }

        [Required]
        public string? sex { get; set; }



        [Required(ErrorMessage = "Your animal must have age.")]
        [Range(0, 100, ErrorMessage = "Age must be between 0 and 100.")]
        public int age { get; set; }

        [Required]
        public int habitat_id { get; set; }



        public TimeSpan? meal_time { get; set; }


        [StringLength(100, ErrorMessage = "Maximum length is 100.")]
        public string? meal_type { get; set; }


        [StringLength(100, ErrorMessage = "Maximum length is 100.")]
        public string? place_of_origin { get; set; }


        [StringLength(100, ErrorMessage = "Maximum length is 100.")]
        public string? health_records { get; set; }

        public string? image_path { get; set; }

        [NotMapped]
        public IFormFile? animal_image  { get; set; }



        /*public byte[]? Image { get; set; }*/


    }
}
