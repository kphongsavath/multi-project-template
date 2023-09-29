
using Microsoft.EntityFrameworkCore;
using $ext_safeprojectname$.DataAccess.EF;
using $ext_safeprojectname$.DataAccess.EF.Oracle.DbContext.Configurations;
using $ext_safeprojectname$.DataAccess.EF.Oracle.Entities;
namespace $ext_safeprojectname$.DataAccess.EF.Oracle.DbContext
{
    internal partial class OracleDbContext : DbContextBase
    {
        public virtual DbSet<SapMara> SapMara { get; set; } = null!;

        public OracleDbContext(DbContextOptions<OracleDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("MPA_MASTER")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.ApplyConfiguration(new Configurations.SapMaraConfiguration());
            modelBuilder.HasSequence("ERROR_LOG_SEQ");

            modelBuilder.HasSequence("INTEGRATIONS_SEQ");

            modelBuilder.HasSequence("PIHUB_EXPORT_LOG_SEQ");

            modelBuilder.HasSequence("PUBLISH_CONFIG_SEQ");

            modelBuilder.HasSequence("SF_SEASONS_SEQ");

            modelBuilder.HasSequence("SF_SIZEBUCKETS_SEQ");

            modelBuilder.HasSequence("SIZEPROFILES_SEQ");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
