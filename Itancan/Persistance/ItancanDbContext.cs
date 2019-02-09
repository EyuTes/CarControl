using Itancan.Core.Models;
using Itancan.Persistance.EntityConfigration;
using System.Data.Entity;

namespace Itancan.Persistance
{
    public class ItancanDbContext : DbContext
    {
        public ItancanDbContext() : base("ItancanDbContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public virtual DbSet<UserAccount> UserAccounts { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserAccountConfigration());
            modelBuilder.Configurations.Add(new CarConfigration());

            base.OnModelCreating(modelBuilder);

        }
    }
}