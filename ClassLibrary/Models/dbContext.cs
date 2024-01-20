using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace ClassLibrary.Models
{
    public class dbContext : DbContext
    {
        public dbContext() : base("CricketerDBContext") {
        }

        public DbSet<customer_master> Customers { get; set; }
        
    }
}