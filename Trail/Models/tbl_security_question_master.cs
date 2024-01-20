using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Trail.Models
{
    [Table("tbl_security_question_master")]
    public class tbl_security
    {
        public long Id { get; set; }

        public string name { get; set; }

        public string code { get; set; }

        public bool is_active { get; set; }
    }

}