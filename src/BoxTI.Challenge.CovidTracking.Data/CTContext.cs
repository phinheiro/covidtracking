using System.Linq;
using System.Threading.Tasks;
using BoxTI.Challenge.CovidTracking.Core.Data;
using BoxTI.Challenge.CovidTracking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BoxTI.Challenge.CovidTracking.Data
{
    public class CTContext : DbContext, IUnitOfWork
    {
        public CTContext(DbContextOptions<CTContext> options) : base(options)
        {
        }
        public DbSet<Cases> Cases { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CTContext).Assembly);

            modelBuilder.Entity<Cases>().HasQueryFilter(c => c.Active);
        }

        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }
    }
}