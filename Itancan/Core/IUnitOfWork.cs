using Itancan.Core.Repositories;
using System;

namespace Itancan.Core
{
    /* 
     * The class simulate the job of the DbSet
     */
    public interface IUnitOfWork : IDisposable
    {
        IUserAccountRespository UserAccounts { get; }
        ICarRepository Cars { get; }
        int SaveChanges();
    }
}
