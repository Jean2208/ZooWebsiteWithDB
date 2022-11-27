using System.ComponentModel.DataAnnotations;

namespace ZooWebsite.Models
{
    public class habitats
    {

        public int id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(100, ErrorMessage = "Maximum length is 50.")]
        public string? habitat_name { get; set; }

        public string? description { get; set; }

        public string? type { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public double daily_maintenance_costs { get; set; }
    }
}
