using Itancan.Core.Models;
using System.Data.Entity.ModelConfiguration;
namespace Itancan.Persistance.EntityConfigration
{
    public class CarConfigration : EntityTypeConfiguration<Car>
    {
        public CarConfigration()
        {
            ToTable("tbl_car");
            HasKey(c => c.Id);
            Property(c => c.RegistrationNumber)
               .IsRequired()
               .HasMaxLength(25);
            Property(c => c.CarModel)
               .IsRequired()
               .HasMaxLength(25);

        }
    }
}