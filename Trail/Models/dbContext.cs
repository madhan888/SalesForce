﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace Trail.Models
{
    public class dbContext : DbContext
    {
        public dbContext() : base("CricketerDBContext") {
        }

        public DbSet<customer_master> Customers { get; set; }
        // Add other DbSet properties for your other entities
    }
}