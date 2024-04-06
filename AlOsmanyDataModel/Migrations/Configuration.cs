using AlOsmanyDataModel.Models;
using System.Data.Entity.Migrations;
using System.Linq;

namespace AlOsmanyDataModel.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<AlOsmanyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(AlOsmanyDbContext context)
        {
            if (!context.Users.Any())
            {
                context.Users.AddOrUpdate(new User { UserName = "admin", Password = "123", FullName = "Admin", Role = UserRole.Admin });

                context.Users.AddOrUpdate(new User { UserName = "manager", Password = "123", FullName = "Manager", Role = UserRole.Manager });

                context.Users.AddOrUpdate(new User { UserName = "worker1", Password = "123", FullName = "Worker 1", Role = UserRole.Worker });
                context.Users.AddOrUpdate(new User { UserName = "worker2", Password = "123", FullName = "Worker 2", Role = UserRole.Worker });

                context.Users.AddOrUpdate(new User { UserName = "customer1", Password = "123", FullName = "Customer 1", Role = UserRole.Customer });
                context.Users.AddOrUpdate(new User { UserName = "customer2", Password = "123", FullName = "Customer 2", Role = UserRole.Customer });
                context.Users.AddOrUpdate(new User { UserName = "customer3", Password = "123", FullName = "Customer 3", Role = UserRole.Customer });

                context.SaveChanges();
            }
        }
    }
}