namespace Itancan.Migrations
{
    using Itancan.Core.Models;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Itancan.Persistance.ItancanDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Itancan.Persistance.ItancanDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            /*
            var UserAccounts = new List<UserAccount>()
            {
                new UserAccount{UserName="eyuel@lnu.sse",Password="123456"},
                new UserAccount{UserName="jaff@lnu.se",Password="123456"},

            };

            UserAccounts.ForEach(s => context.UserAccounts.Add(s));//loop through and add the student to list of students
            context.SaveChanges();
            */
            var Cars = new List<Car>()
            {
                new Car{RegistrationNumber="VolvoBig123", CarModel="CAR95102",CarStatus=CarStatus.InTraffic},
                new Car{RegistrationNumber="VolvoMini123", CarModel="CAR120180",CarStatus=CarStatus.OutTraffic},
            };

            Cars.ForEach(s => context.Cars.Add(s));//loop through and add the student to list of students
            context.SaveChanges();
        }
    }
}
