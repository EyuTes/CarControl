using Itancan.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itancan.Core.Repositories
{
    public interface IUserAccountRespository : IRepository<UserAccount>
    {
        UserAccount GetUser(string username);
    }
}
