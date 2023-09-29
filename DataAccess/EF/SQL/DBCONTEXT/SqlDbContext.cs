
using Microsoft.EntityFrameworkCore;
using $ext_safeprojectname$.DataAccess.EF;
using $ext_safeprojectname$.DataAccess.EF.Sql.DbContext.Configurations;
using $ext_safeprojectname$.DataAccess.EF.Sql.Entities;
namespace $ext_safeprojectname$.DataAccess.EF.Sql.DbContext
{
    internal partial class SqlDbContext : DbContextBase
    {
        public virtual DbSet<ArticleData> ArticleData { get; set; } = null!;
        public virtual DbSet<EpUsers> EpUsers { get; set; } = null!;
        public virtual DbSet<VsEpConfiguration> VsEpConfiguration { get; set; } = null!;
        public virtual DbSet<VwAllocationFeed> VwAllocationFeed { get; set; } = null!;

        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Configurations.ArticleDataConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.EpUsersConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.VsEpConfigurationConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.VwAllocationFeedConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
