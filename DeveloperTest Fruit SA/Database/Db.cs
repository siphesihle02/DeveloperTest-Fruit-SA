using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using DeveloperTest_Fruit_SA.Models;

namespace DeveloperTest_Fruit_SA.Database
{
    public class Db :DbContext
    {
        public Db() : base("productsDatabase")
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}