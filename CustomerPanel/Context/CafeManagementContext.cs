using CustomerPanel.Models;
using System.Data.Entity;

namespace CustomerPanel.Context
{
    public class CafeManagementContext: DbContext
    {
        public CafeManagementContext(): base("CustomerContext")
        {

        }

        public DbSet<Cafe> Cafes { get; set; }

        public DbSet<Customer> Customers { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }

    }
}