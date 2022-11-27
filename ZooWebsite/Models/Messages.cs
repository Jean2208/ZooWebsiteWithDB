using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace ZooWebsite.Models
{
    [Keyless]
    public class message_board
    {

        public string? message { get; set; }

        [DataType(DataType.Date)]
        public DateTime? message_date { get; set; }

    }
}
