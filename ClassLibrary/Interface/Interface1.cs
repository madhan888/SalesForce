using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Trail.Models;

namespace ClassLibrary
{
    public interface Interface1
    {

         void login(string username, string password);

        bool registration(string firstName, string lastName, string mobile, string email, string address, string accountNo, string security, string answer, string password);

        List<SecurityQuestion> GetSecurityQuestions();
   
        bool passwordRecovery(string securityQuestion, string securityAnswer, string mobile, string newPassword);

        bool ValidateLogin(string username, string password);

      
    }
}
