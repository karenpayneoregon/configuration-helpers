using System.IO;
using System.Threading.Tasks;
using ConsoleDemoAppConfig1.Data.Configurations;
using ConsoleDemoAppConfig1.Models;
using Microsoft.EntityFrameworkCore;
using static System.Configuration.ConfigurationManager;

#nullable disable

namespace ConsoleDemoAppConfig1.Data
{
    public partial class SchoolContext : DbContext
    {

        public SchoolContext()
        {

        }

        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        public virtual DbSet<Person> Person { get; set; }

        /*
         * Change the file name as desired along with a path if the file should be
         * in another location than the application executable path.
         */
        private readonly StreamWriter _logStream = new StreamWriter("ef-log.txt", append: true);
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var environment = "";

#if Dev
                environment = "DevConnection";
#elif Staging
                environment = "StagingConnection";
#else
                environment = "ProductionConnection";
#endif
                var connectionString = AppSettings[environment];
                /*
                 * Here is a case for having unhandled exception handling in the application
                 */
                if (connectionString != null) optionsBuilder.UseSqlServer(connectionString);
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        #region Takes care of disposing stream used for logging
        public override void Dispose()
        {
            base.Dispose();
            _logStream.Dispose();
        }

        public override async ValueTask DisposeAsync()
        {
            await base.DisposeAsync();
            await _logStream.DisposeAsync();
        }
        #endregion        
    }
}
