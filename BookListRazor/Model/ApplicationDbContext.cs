using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseMaster.Model
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext( DbContextOptions <ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<DailyTransaction> DailyTransaction { get; set; }

        public DbSet<Transaction> Transaction { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<Vendor> Vendor { get; set; }

    }

}
