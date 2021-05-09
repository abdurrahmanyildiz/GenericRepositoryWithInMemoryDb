using Microsoft.EntityFrameworkCore;
using MockDBExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockDBExample.Repos
{
    public class MockDbContext : DbContext
    {
        public MockDbContext() { }
        public MockDbContext(DbContextOptions<MockDbContext> opts) : base(opts)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("TestDb");
                base.OnConfiguring(optionsBuilder);
            }
        }

        public DbSet<User> Users { get; set; }

    }
}
