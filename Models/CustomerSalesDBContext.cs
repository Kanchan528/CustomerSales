using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSales.Models
{
    public class CustomerSalesDBContext: DbContext
    {
        public CustomerSalesDBContext(DbContextOptions<CustomerSalesDBContext> options) : base(options)
        {

        }
        public DbSet<ECustomer> ECustomers{ get; set; }
        public DbSet<EItem> EItems{ get; set; }
        public DbSet<ESales> ESales{ get; set; }
        public DbSet<ESalesDetail> ESalesDetails { get; set; }

    }
}
