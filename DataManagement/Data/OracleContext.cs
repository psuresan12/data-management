using DataManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataManagement.Data
{
    public class OracleContext :DbContext
    {

        public OracleContext(DbContextOptions<OracleContext> options)
         : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<CustomerPost> CustomerPosts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerPost>()
                .HasOne(cp => cp.Sender)
                .WithMany(s => s.CustomerPosts)
                .HasForeignKey(cp => cp.Sender_ID);

        }
    }
}
