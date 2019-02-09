using Itancan.Core;
using Itancan.Core.Repositories;
using Itancan.Persistance.Repositories;

namespace Itancan.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ItancanDbContext _context;

        public UnitOfWork(ItancanDbContext context)
        {
            _context = context;
            UserAccounts = new UserAccountRespository(_context);
            Cars = new CarRepository(_context);

        }
        public IUserAccountRespository UserAccounts { get; set; }

        public ICarRepository Cars { get; set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}