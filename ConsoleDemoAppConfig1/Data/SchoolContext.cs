
using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Threading.Tasks;
using ConsoleDemoAppConfig1.Data.Configurations;
using ConsoleDemoAppConfig1.Models;
using static System.Configuration.ConfigurationManager;

#nullable disable

namespace EntityLibrary.Data
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
                optionsBuilder.UseSqlServer(AppSettings[environment]);

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
