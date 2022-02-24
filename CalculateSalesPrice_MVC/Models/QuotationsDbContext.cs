using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CalculateSalesPrice_MVC.Models
{
    public class QuotationsDbContext : DbContext
    {

        public DbSet<Quotation> Quotations { get; set; }

        public QuotationsDbContext() : base("QuotationConnection_21")
        {
            Database.SetInitializer<QuotationsDbContext>(new DropCreateDatabaseIfModelChanges<QuotationsDbContext>());  
        }
    }
}