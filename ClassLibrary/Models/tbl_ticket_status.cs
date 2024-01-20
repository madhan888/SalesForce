using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    [Table("tbl_ticket_status")]
 
        public class TicketStatus
        {
            [Key]
            public long Id { get; set; }

            [Required]
            [StringLength(100)]
            public string Name { get; set; }

            [Required]
            [StringLength(100)]
            public string Code { get; set; }

            public string TextBox1 { get; set; }
            public string TextBox2 { get; set; }
            public string TextBox3 { get; set; }
            public string TextBox4 { get; set; }
    }
    
}
