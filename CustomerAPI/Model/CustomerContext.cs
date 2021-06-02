using System;
using Microsoft.EntityFrameworkCore;
using Utilities.Model;
namespace CustomerAPI.Model
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options)
            : base(options)
        {
        }
        

        public DbSet<Customer> CustomerItems { get; set; }
    }
}
