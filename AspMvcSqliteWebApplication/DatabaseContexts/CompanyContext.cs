
using AspMvcSqliteWebApplication.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspMvcSqliteWebApplication.DatabaseContexts
{
    public class CompanyContext : DbContext
    {
        private string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // Console.WriteLine("Path :: " + path);
            // options.UseSqlite($"Data Source={Path.Join(path, "CompanySqliteDatabase.db")}");
            // options.UseSqlite($"Data Source={"/Users/venkat/Library/Application/CompanySqliteDatabase.db"}");
            options.UseSqlite($"Data Source={"/Users/venkat/.local/share/CompanySqliteDatabase.db"}");
            options.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
            options.EnableSensitiveDataLogging(); // Optional: This logs parameter values
        }
    }
}
