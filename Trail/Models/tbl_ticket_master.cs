using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Trail.Models
{
    [Table("tbl_ticket_master")]
    public class ticket_master
    {

        public long Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }

        public string Problem { get; set; }

        public string Description { get; set; }

        public string StatusCode { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        public long UserId { get; set; }

        public DateTime? ResolvedOn { get; set; }

        public string Resolution { get; set; }
    }
}