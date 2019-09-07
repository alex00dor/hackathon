using hachathon.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace hachathon.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<Plan> Plan { get; set; }
        public DbSet<Phone> Phone { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Document> Document { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .HasOne(pt => pt.Plan)
                .WithMany(p => p.Users)
                .HasForeignKey(pt => pt.PlanId);
            
            builder.Entity<User>()
                .HasOne(pt => pt.Status)
                .WithMany(p => p.Users)
                .HasForeignKey(pt => pt.StatusId);

            builder.Entity<User>()
                .HasOne(pt => pt.Phone)
                .WithOne(p => p.User);

            builder.Entity<Document>()
                .HasOne(pt => pt.User)
                .WithMany(p => p.Documents)
                .HasForeignKey(pt => pt.UserId);
            
            builder.Entity<Status>().HasData(
                new Status {Id = 1, Name = "In Progress"},
                new Status {Id = 2, Name = "Approved"},
                new Status {Id = 3, Name = "Rejected"}
            );

            builder.Entity<Plan>().HasData(
                new Plan {Id = 1, Name = "Start Kit", Price = 10.99M, Description = "Plan for a every body"},
                new Plan {Id = 2, Name = "Unlimited Kit", Price = 20.10M, Description = "Unlimited data, calls, messages"},
                new Plan {Id = 3, Name = "Gold Kit", Price = 40.22M, Description = "Special service."}
            );

            builder.Entity<Phone>()
                .Property(p => p.Available)
                .HasDefaultValue(true);

            builder.Entity<Phone>().HasData(
                new Phone {Id = 15, Number = "114-532-9991"},
                new Phone {Id = 1, Number = "212-532-9991"},
                new Phone {Id = 2, Number = "312-532-9911"},
                new Phone {Id = 3, Number = "402-552-9291"},
                new Phone {Id = 4, Number = "502-532-9991"},
                new Phone {Id = 5, Number = "612-532-9991"},
                new Phone {Id = 6, Number = "702-532-9991"},
                new Phone {Id = 7, Number = "812-532-9991"},
                new Phone {Id = 8, Number = "912-532-9991"},
                new Phone {Id = 9, Number = "112-532-9991"},
                new Phone {Id = 10, Number = "222-532-9991"},
                new Phone {Id = 11, Number = "332-532-9991"},
                new Phone {Id = 12, Number = "442-552-9991"},
                new Phone {Id = 13, Number = "552-532-9191"},
                new Phone {Id = 14, Number = "662-555-9551"}
            );

        }
    }
}