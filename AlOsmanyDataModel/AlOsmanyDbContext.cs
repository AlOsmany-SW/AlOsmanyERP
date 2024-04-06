using AlOsmanyDataModel.Migrations;
using AlOsmanyDataModel.Models;
using System.Data.Entity;

namespace AlOsmanyDataModel
{
    public class AlOsmanyDbContext : DbContext
    {
        public AlOsmanyDbContext() : base("Server=.;Database=AlOsmany;Trusted_Connection=True;")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AlOsmanyDbContext, Configuration>());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<RequestedService> RequestedServices { get; set; }
    }
}