using Itancan.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace Itancan.Persistance.EntityConfigration
{
    public class UserAccountConfigration : EntityTypeConfiguration<UserAccount>
    {
        public UserAccountConfigration()
        {
            ToTable("tbl_user");
            HasKey(u => u.UserName);
            Property(u => u.Password)
               .IsRequired()
               .HasMaxLength(20);
            Property(u => u.UserName)
               .IsRequired()
               .HasMaxLength(20);

        }
    }
}