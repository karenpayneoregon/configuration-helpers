using System.IO;
using ConfigurationHelper;
using EntityLibrary.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using EntityLibrary.Models;
using System.Threading.Tasks;

#nullable disable

namespace EntityLibrary.Data
{
    public partial class SchoolContext : DbContext
    {
        /// <summary>
        /// Connection string to interact with the database
        /// </summary>
        private static string _connectionString;
        public SchoolContext()
        {
            _connectionString = Helper.GetConnectionString();
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
                if (Helper.UseLogging())
                {

                    optionsBuilder.UseSqlServer(_connectionString)
                        .EnableSensitiveDataLogging()
                        .EnableDetailedErrors()
                        .LogTo(_logStream.WriteLine);
                    
                }
                else
                {
                    
                    optionsBuilder.UseSqlServer(_connectionString);
                    
                }
                
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
