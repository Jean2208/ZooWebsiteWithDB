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

        public int quantity { get; set; }

        public int sale_date { get; set; }

    }
}
