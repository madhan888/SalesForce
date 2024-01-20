using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Trail.Models;

namespace ClassLibrary
{
    public class RegisterCustomer: Interface1
    {
        private readonly Class1 _context;
        Class1 db=new Class1();
        public RegisterCustomer()
        {
            _context = new Class1();
        }

        public RegisterCustomer(Class1 context)
        {
            _context=context;
        }
        public void login(string username, string password) {
            var newCustomer = new customer_master
            {
                customer_fname = username,
                login_password = password,
            };
            db.Customers.Add(newCustomer);
            db.SaveChanges();
        }
        
           

       public void passwordRecovery(String username, String email) {
            var newCustomer = new customer_master
            {
                customer_fname = username,
                login_password = email
            };

            db.Customers.Add(newCustomer);
            db.SaveChanges();
        }

        public bool ValidateLogin(string username, string password)
        {
            var customer = _context.Customers.SingleOrDefault(c=>c.customer_fname == username && c.login_password == password);
            if(customer != null)
            {
                return true;
            }
            else
            {

                return false;
            }
            
        }

        public bool registration(string firstName, string lastName, string mobile, string email, string address, string accountNo, string security, string answer, string password)
        {
            
            var existingCustomer = _context.Customers.SingleOrDefault(c => c.customer_fname == firstName);

           
            if (existingCustomer != null)
            {
                return false;
            }

            
            var newCustomer = new customer_master
            {
                customer_fname = firstName,
                customer_lname = lastName,
                customer_mobile = mobile,
                customer_email = email,
                customer_address = address,
                account_no = accountNo,
                security_questions_Code = security,
                security_answer_code = answer,
                login_password = password,
     
                
                
            };

            
            _context.Customers.Add(newCustomer);
            var check = _context.SaveChanges();
            if(check>0)
            {
                return true;
            }
           
            return true;
        }


     public bool passwordRecovery(string securityQuestion, string securityAnswer, string mobile, string newPassword)
        {
           
            var customer = _context.Customers.SingleOrDefault(c => c.customer_mobile == mobile && c.security_questions_Code == securityQuestion);

            if (customer != null)
            {
              
                if (customer.security_answer_code == securityAnswer)
                {
                  
                    customer.login_password = newPassword;
                    _context.SaveChanges();
                    return true; 
                }
            }

            return false; 
        }

        public List<SecurityQuestion> GetSecurityQuestions()
        {
            return _context.SecurityQuestions.ToList();
        }

      

        

        //public SelectList GetSecurityQuestions1()
        ////{
        ////    var securityQuestions = db.SecurityQuestions
        ////        .Select(sq => new SelectListItem { Text = sq.Name, Value = sq.Code })
        ////        .ToList();
        //     customer
        //    securityQuestions.Insert(0, new SelectListItem { Text = "--Select--", Value = "0" });
        //    List<string> securityQuestions = new List<string>();
        //    return new SelectList(securityQuestions, "Value", "Text");

        //}

    }

}
