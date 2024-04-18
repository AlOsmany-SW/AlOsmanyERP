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
                context.Users.Add(new User { UserName = "admin", Password = "123", FullName = "Admin", Role = UserRole.Admin });

                context.Users.Add(new User { UserName = "manager", Password = "123", FullName = "Manager", Role = UserRole.Manager });

                context.Users.Add(new User { UserName = "worker1", Password = "123", FullName = "Worker 1", Role = UserRole.Worker });
                context.Users.Add(new User { UserName = "worker2", Password = "123", FullName = "Worker 2", Role = UserRole.Worker });

                context.Users.Add(new User { UserName = "customer1", Password = "123", FullName = "Customer 1", Role = UserRole.Customer });
                context.Users.Add(new User { UserName = "customer2", Password = "123", FullName = "Customer 2", Role = UserRole.Customer });
                context.Users.Add(new User { UserName = "customer3", Password = "123", FullName = "Customer 3", Role = UserRole.Customer });

                context.SaveChanges();
            }

            if (!context.Services.Any())
            {
                context.Services.Add(new Service { Name = "Printing A4 - Black and White", Fees = 0.8, Notes = "A4"});
                context.Services.Add(new Service { Name = "Printing A4 - Color", Fees = 2.5, Notes = "A4" });
                
                context.Services.Add(new Service { Name = "Binding - Comb Binding", Fees = 5.5 });
                context.Services.Add(new Service { Name = "Binding - Thick Cover", Fees = 9.3 });
                
                context.Services.Add(new Service { Name = "Printing - Poster", Fees = 6, Notes = "A0, A1" });
                context.Services.Add(new Service { Name = "Printing - Poster", Fees = 3, Notes = "A2, A3" });

                context.SaveChanges();
            }
        }
    }
}