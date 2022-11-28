using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooWebsite.Models
{
   
    public class sales
    {
        [Key]
        public int sale_id { get; set; }

        public int item_id { get; set; }

        public int item_price { get; set; }

        public int quantity { get; set; }

        public string? customer_fname { get; set; }

        public string? customer_lname { get; set; }

        public string? customer_address { get; set; }

        public int sale_date { get; set; }

    }
}
