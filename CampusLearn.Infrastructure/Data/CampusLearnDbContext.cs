using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CampusLearn.Domain.Entities;

namespace CampusLearn.Infrastructure.Data
{
    internal class CampusLearnDbContext : DbContext
    {
        public CampusLearnDbContext(DbContextOptions<CampusLearnDbContext> options)
            : base(options)
        {
        }

        /* public DbSet<User> Users { get; set; }
         public DbSet<Course> Courses { get; set; }
         public DbSet<Topic> Topics { get; set; }
         public DbSet<Message> Messages { get; set; } */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Add entity configurations or constraints here if needed
        }
    }
}
