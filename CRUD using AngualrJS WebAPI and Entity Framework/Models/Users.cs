﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AngualrJSWebAPIApp.Models
{
    public class Customer
    {
        public string id { get; set; }
        public string city { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string contactNo { get; set; }
        public string emailId { get; set; }
    }

    public class CustomerContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
    }
}