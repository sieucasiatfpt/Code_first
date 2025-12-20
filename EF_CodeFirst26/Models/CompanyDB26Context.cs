using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace EF_CodeFirst26.Models
{
    public class CompanyDB26Context : DbContext
    {
        public CompanyDB26Context() : base("CompanyDB26Context") { }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}