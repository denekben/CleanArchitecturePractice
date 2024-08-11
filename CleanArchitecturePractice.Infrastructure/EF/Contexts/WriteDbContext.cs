using CleanArchitecturePractice.Domain.Entities;
using CleanArchitecturePractice.Domain.ValueObjects;
using CleanArchitecturePractice.Infrastructure.EF.Config;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecturePractice.Infrastructure.EF.Contexts
{
    internal sealed class WriteDbContext : DbContext
    {
        public DbSet<PackingList> PackingLists { get; set; }

        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("packing");

            var configuration = new WriteConfiguration();
            modelBuilder.ApplyConfiguration<PackingList>(configuration);
            modelBuilder.ApplyConfiguration<PackingItem>(configuration);
        }
    }
}
