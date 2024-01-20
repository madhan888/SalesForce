using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Trail.Models
{
    [Table("tbl_customer_master")]
    public class customer_master
    {
        public long Id { get; set; }

        public string customer_fname { get; set; }

        public string customer_lname { get; set; }

        public string customer_mobile { get; set; }

        public string customer_email { get; set; }

        public string login_password { get; set; }

        public string customer_address { get; set; }

        public bool is_blocked { get; set; }

        public bool is_active { get; set; }

        public DateTime created_on { get; set; }

        public DateTime updated_on { get; set; }

        public string security_questions_Code { get; set; }

        public string security_answer_code { get; set; }

        public string account_no { get; set; }
    }
}