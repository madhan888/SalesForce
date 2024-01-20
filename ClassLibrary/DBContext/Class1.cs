using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trail.Models;

namespace ClassLibrary.Models
{
    public class Class1 : DbContext
    {
        public Class1() : base("CricketerDBContext")
        {
            Database.SetInitializer<Class1>(null);
        }

        public DbSet<customer_master> Customers { get; set; }
        public DbSet<SecurityQuestion> SecurityQuestions { get; set; }
        public DbSet<TicketStatus> TicketStatuses { get; set; }
        public DbSet<ticket_master> Tickets { get; set; }

        





       
    }
}
