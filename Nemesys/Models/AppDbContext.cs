using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Nemesys.Models
{
    public class AppDbContext : DbContext //: IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //This will pass any options passed in the constructor to the base class DbContext
        }
        
        public DbSet<Status> Status { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<TypeOfHasard> TypeOfHasard { get; set; }
        public DbSet<Investigation> Investigations { get; set; }
       
        /*
                protected override void OnModelCreating(ModelBuilder modelBuilder)
                {
                    modelBuilder.Entity<Status>().ToTable("Status");
                    modelBuilder.Entity<Investigation>().ToTable("Investigations");
                    modelBuilder.Entity<Report>().ToTable("Reports");
                    modelBuilder.Entity<TypeOfHasard>().ToTable("TypeOfHasard");
                }*/
    }
}
