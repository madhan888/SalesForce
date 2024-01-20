using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Trail.Models;
using System.Web.Mvc;

namespace ClassLibrary.Models
{
    [Table("tbl_customer_master")]
    public class customer_master
    {


        public long Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string customer_fname { get; set; }

        [Required]
        [MaxLength(100)]
        public string customer_lname { get; set; }

        [Required]
        [MaxLength(100)]
        public string customer_mobile { get; set; }

        [Required]
        [MaxLength(100)]
        public string customer_email { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Password:")]
        public string login_password { get; set; }

        [MaxLength(200)]
        public string customer_address { get; set; }

        public bool is_blocked { get; set; } = false;

        public bool is_active { get; set; } = true;

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime created_on { get; set; } = DateTime.Now;

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime updated_on { get; set; } = DateTime.Now;

        [MaxLength(200)]
        [Display(Name = "Select Security Question:")]
        public string security_questions_Code { get; set; }

        [MaxLength(100)]
        [Display(Name = "Security Answer:")]
        public string security_answer_code { get; set; }

        [MaxLength(50)]
        [Index(IsUnique = true)]
        public string account_no { get; set; }
        [NotMapped]
        public IList<SelectListItem> GetSecurityQuestions { get; set; }


    }
}




