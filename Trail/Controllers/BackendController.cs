using ClassLibrary;
using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using System.Web.UI;
using Trail.Models;

namespace Trail.Controllers
{


    public class BackendController : Controller
    {

       
            private readonly Interface1 _repository;
            private readonly Class1 _context;

        public BackendController()
            {
            _context = new Class1();
            _repository = new RegisterCustomer(new Class1());
            }
        

            public ActionResult Login()
            {
                return View(new customer_master());
            }

            [HttpPost]
            public ActionResult Login(customer_master model)
            {
                bool isValidLogin = _repository.ValidateLogin(model.customer_fname, model.login_password);

                if (isValidLogin)
                {
                Session["UserId"] = model.customer_fname;
                ViewBag.SuccessMessage = "Successfull Login";
               
                return RedirectToAction("DashBoard");
                }
                else
                {
                    
                    ViewBag.ErrorMessage = "Invalid credentials";
                    return View("Login");
            }
                if (ModelState.IsValid)
                    {
                    
                    }

                // If the model is not valid, return to the login view with error messages
                return View(model);
            }

        public ActionResult RegistrationPage()
        {
            var securityQuestions = _repository.GetSecurityQuestions();

            var model = new customer_master();
            model.GetSecurityQuestions = securityQuestions
                .Select(sq => new SelectListItem { Text = sq.Name, Value = sq.Code })
                .ToList();
            model.GetSecurityQuestions.Insert(0, new SelectListItem { Text = "--Select--", Value = "0" });

            return View(model);
        }

        [HttpPost]
        public ActionResult RegistrationPage(customer_master model)
        {
            bool checkRegistration = _repository.registration(
                model.customer_fname, model.customer_lname, model.customer_mobile,
                model.customer_email, model.customer_address, model.account_no,
                model.security_questions_Code, model.security_answer_code, model.login_password
            );

            if (checkRegistration)
            {
                ViewBag.SuccessMessage = "Successfully entered";
                return RedirectToAction("Login" , "Backend");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid credentials";
            }

           
            model.GetSecurityQuestions = _repository.GetSecurityQuestions()
                .Select(sq => new SelectListItem { Text = sq.Name, Value = sq.Code })
                .ToList();
            model.GetSecurityQuestions.Insert(0, new SelectListItem { Text = "--Select--", Value = "0" });

            return View(model);
        }

        //public ActionResult RegistrationPage()
        //{
        //    var securityQuestions = _repository.GetSecurityQuestions();

        //    var model = new customer_master();
        //    var dropdowndata = _context.SecurityQuestions.ToList();
        //    model.GetSecurityQuestions.Add(new SelectListItem { Text = "--Select--", Value = "0" });
        //    foreach (var item in dropdowndata)
        //    {
        //        model.GetSecurityQuestions.Add(new SelectListItem {  Text = item.Name, Value = item.Code });
        //    }



        //    return View(securityQuestions);
        //}

        //[HttpPost]
        //public ActionResult RegistrationPage(customer_master model)
        //{
        //    bool checkRegistration = _repository.registration(model.customer_fname, model.customer_lname, model.customer_mobile, model.customer_email, model.customer_address, model.account_no, model.security_questions_Code, model.security_answer_code, model.login_password);

        //    if (checkRegistration)
        //    {
        //        ViewBag.SuccessMessage = "Successfully entered";
        //        return View("RegistrationPage");
        //    }
        //    else
        //    {

        //        ViewBag.ErrorMessage = "Invalid credentials";
        //    }

        //    return View(model);
        //}

        /*    public ActionResult RegistrationPage()
            {

                return View(new customer_master());
            }

            [HttpPost]
        public ActionResult RegistrationPage(customer_master model)
        {

                bool checkRegistration = _repository.registration(model.customer_fname, model.customer_lname, model.customer_mobile, model.customer_email, model.customer_address,model.account_no, model.security_questions_Code, model.security_answer_code , model.login_password);


                if (checkRegistration)
                {

                    ViewBag.SuccessMessage = "Successfully entered";
                    return View("RegistrationPage");
                }
                else
                {
                    // Failed login logic
                    ViewBag.ErrorMessage = "Invalid credentials";
                }



                // Redirect to a success page or display a success message

                return View(model);

            }*/

        public ActionResult PasswordReset()
        {
            var securityQuestions = _repository.GetSecurityQuestions();

            var model = new customer_master();
            model.GetSecurityQuestions =   securityQuestions
                .Select(sq => new SelectListItem { Text = sq.Name, Value = sq.Code })
                .ToList();
            model.GetSecurityQuestions.Insert(0, new SelectListItem { Text = "--Select--", Value = "0" });

            return View(model);
        }

        [HttpPost]
        public ActionResult PasswordReset(customer_master model)
        {
            bool checkRecovery = _repository.passwordRecovery(model.security_questions_Code, model.security_answer_code, model.customer_mobile, model.login_password);


            if (checkRecovery)
            {


                return RedirectToAction("Login", "Backend");
            }
            else
            {
                
                ViewBag.ErrorMessage = "Invalid credentials";
                var securityQuestions = _repository.GetSecurityQuestions();
                model.GetSecurityQuestions = securityQuestions
                .Select(sq => new SelectListItem { Text = sq.Name, Value = sq.Code })
                .ToList();
                model.GetSecurityQuestions.Insert(0, new SelectListItem { Text = "--Select--", Value = "0" });
            }



         

            return View(model);
        }

        public ActionResult RaiseTicket()
        {
            return View(new ticket_master());

        }



        [HttpPost]
        public ActionResult RaiseTicket(ticket_master model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                  
                    model.CreatedOn = DateTime.Now;
                    model.UpdatedOn = DateTime.Now;
                    model.ResolvedOn = DateTime.Now;
                    model.UserId = 0;

                   
                    _context.Tickets.Add(model);
                    _context.SaveChanges();

                    ViewBag.SuccessMessageOne = "Successfully created ticket!";
                    ViewBag.SuccessMessageTwo = "Thank you for raising the ticket";

                    string ticketNumber = GenerateRandomTicketNumber();
                    ViewBag.SuccessMessageThree = "Your Ticket Number is: " + ticketNumber;

                    return RedirectToAction("DashBoard","Backend");
                }
                else
                {
                    
                    return View("RaiseTicket", model);
                }
            }
            catch (Exception ex)
            {
                
                ViewBag.ErrorMessage = "An error occurred while saving the data. Please try again.";
                return View("RaiseTicket", model);
            }
        }




        private string GenerateRandomTicketNumber()
            {
                Random random = new Random();
                const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

              
                string randomAlphabets = new string(Enumerable.Repeat(alphabet, 1)
                                            .SelectMany(s => s.OrderBy(_ => random.Next()))
                                            .Take(3)
                                            .ToArray());



                int remainingDigits = 9; 
                string randomDigits = new string(Enumerable.Range(0, remainingDigits)
                                                            .Select(_ => random.Next(10).ToString()[0])
                                                            .ToArray());

                return randomAlphabets + randomDigits;
            }

        //public ActionResult TicketHistory()
        //{
        //    var model = new ticket_master();
        //    var data = _context.Tickets.ToList;
        //    ViewBag.Initial = data;
        //    return View(model);
        //}
        public ActionResult TicketHistory()
        {
           
            var data = _context.Tickets.ToList();

            ViewBag.Initial = data;

            return View(new ticket_master());
        }


        public ActionResult DashBoard()
        {
            var statusCounts = _context.Tickets
                .GroupBy(ticket => ticket.StatusCode)
                .Select(group => new { StatusCode = group.Key, Count = group.Count() })
                .ToList();

            ViewBag.StatusCounts = statusCounts;

            return View(new ticket_master());
        }

        public ActionResult TicketDetail(int id)
        {
            var ticket = _context.Tickets.Find(id);
            if (ticket == null)
            {
               
                return HttpNotFound();
            }

            return View("TicketDetail", ticket);
        }

        [HttpPost]
        public ActionResult UpdateStatus(ticket_master model)
        {
            try
            {
             
                var existingTicket = _context.Tickets.Find(model.Id);

                if (existingTicket != null)
                {
                  
                    existingTicket.StatusCode = model.StatusCode;

                  
                    _context.SaveChanges();

                    ViewBag.SuccessMessage = "Status updated successfully!";
                }
                else
                {
                    ViewBag.ErrorMessage = "Ticket not found!";
                }

              
                return View("TicketDetail", model);
            }
            catch (Exception ex)
            {
                
                ViewBag.ErrorMessage = "An error occurred while updating the status. Please try again.";
                return View("TicketDetail", model);
            }
        }



        /*[HttpPost]
         public ActionResult TicketHistory(ticket_master model)
        {
            bool isValidLogin = _repository.ValidateLogin(model.customer_fname, model.login_password);

            if (isValidLogin)
            {
                ViewBag.SuccessMessage = "Successfull Login";
                // Successful login logic
                return View("Login");
            }
            else
            {
                // Failed login logic
                ViewBag.ErrorMessage = "Invalid credentials";
            }
            if (ModelState.IsValid)
            {

            }

            // If the model is not valid, return to the login view with error messages
            return View(model);
        }*/

    }

}



    
