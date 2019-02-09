using Itancan.Core.Models;
using Itancan.Core.Repositories;

namespace Itancan.Persistance.Repositories
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        public CarRepository(ItancanDbContext context) : base(context)
        {

        }
        public ItancanDbContext ItancanDbContext
        {
            get { return Context as ItancanDbContext; }
        }
    }
}