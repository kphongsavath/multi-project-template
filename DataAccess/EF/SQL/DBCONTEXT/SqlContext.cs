
using Microsoft.EntityFrameworkCore;
using $ext_safeprojectname$.DataAccess.EF;
using $ext_safeprojectname$.DataAccess.EF.Sql.DbContext.Configurations;
using $ext_safeprojectname$.DataAccess.EF.Sql.Entities;
namespace $ext_safeprojectname$.DataAccess.EF.Sql.DbContext
{
    internal partial class SqlContext : DbContextBase
    {
        public virtual DbSet<EpUsers> EpUsers { get; set; } = null!;
        public virtual DbSet<VsEpConfiguration> VsEpConfiguration { get; set; } = null!;
        public virtual DbSet<VwAllocationFeed> VwAllocationFeed { get; set; } = null!;

        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Configurations.EpUsersConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.VsEpConfigurationConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.VwAllocationFeedConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
