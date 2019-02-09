using Itancan.Core.Models;
using Itancan.Core.Repositories;

namespace Itancan.Persistance.Repositories
{
    public class UserAccountRespository : Repository<UserAccount>, IUserAccountRespository
    {
        public UserAccountRespository(ItancanDbContext context) : base(context)
        {

        }
        public ItancanDbContext ItancanDbContext
        {
            get { return Context as ItancanDbContext; }
        }
        public UserAccount GetUser(string username)
        {
            return null;
        }
    }
}