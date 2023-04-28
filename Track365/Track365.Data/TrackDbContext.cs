using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using Track365.Models;

namespace Track365.Data
{
    public class TrackDbContext : IdentityDbContext
    {
        public TrackDbContext(DbContextOptions<TrackDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<HabitCategory> HabitCategories { get; set; }

        public DbSet<Habit> Habits { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Reminder> Reminders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<HabitCategory>().HasMany(h => h.Habits).WithOne(c => c.HabitCategory).HasForeignKey(h => h.HabitCategoryId);
            builder.Entity<User>().HasMany(p => p.Habits).WithOne(p => p.User);
            builder.Entity<User>().HasMany(u => u.Friends);
            builder.Entity<Reminder>().HasOne(h => h.Habit).WithOne(r => r.Reminder).HasForeignKey<Reminder>(r => r.HabitId);
        }
    }
}
