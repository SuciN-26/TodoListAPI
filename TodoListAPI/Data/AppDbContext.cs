using Microsoft.EntityFrameworkCore;
using TodoListAPI.Model;

namespace TodoListAPI.Data
{
    public class AppDbContext : DbContext
    {
        private readonly IHostEnvironment _env;

        public AppDbContext(DbContextOptions<AppDbContext> options, IHostEnvironment env) : base(options)
        {
            _env = env;
        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<Checklist> Checklists { get; set; }
        public DbSet<ChecklistItem> ChecklistItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>()
               .Property(a => a.Id)
               .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Checklist>()
               .Property(a => a.Id)
               .ValueGeneratedOnAdd();

            modelBuilder.Entity<ChecklistItem>()
                .Property(a => a.Id)
                .ValueGeneratedNever();
            
            modelBuilder
                .Entity<Checklist>()
                .HasMany(a => a.ChecklistItems)
                .WithOne(b => b.Checklist)
                .HasForeignKey(b => b.ChecklistId);

            modelBuilder
                .Entity<AppUser>()
                .HasMany(a => a.Checklists)
                .WithOne(b => b.User)
                .HasForeignKey(b => b.UserId);

            modelBuilder
                .Entity<AppUser>()
                .HasMany(a => a.ChecklistItems)
                .WithOne(b => b.User)
                .HasForeignKey(b => b.UserId);
        }
    }
}
