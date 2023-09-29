using Microsoft.EntityFrameworkCore;

namespace $ext_safeprojectname$.DataAccess.EF
{
    public class DbContextBase : DbContext
    {
        protected DbContextBase() : base()
        {

        }
        protected DbContextBase(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
    }
}
