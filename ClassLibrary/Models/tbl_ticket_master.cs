using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Trail.Models
{
    [Table("tbl_ticket_master")]
    public class ticket_master
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(int.MaxValue)]
        public string Name { get; set; }

        [Required]
        [StringLength(int.MaxValue)]
        public string Email { get; set; }

        [Required]
        [StringLength(int.MaxValue)]
        public string Mobile { get; set; }

        [Required]
        [StringLength(int.MaxValue)]
        public string Problem { get; set; }

        [Required]
        [StringLength(int.MaxValue)]
        public string Description { get; set; }

        [Required]
        [StringLength(int.MaxValue)]
        public string StatusCode { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public DateTime UpdatedOn { get; set; } = DateTime.Now;

        public long UserId { get; set; } = 0;

        public DateTime? ResolvedOn { get; set; }

        [StringLength(int.MaxValue)]
        public string Resolution { get; set; }
    }
}