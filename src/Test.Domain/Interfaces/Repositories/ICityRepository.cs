using System.Collections.Generic;
using System.Threading.Tasks;
using Test.Domain.Entities;

namespace Test.Domain.Interfaces.Repositories
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetAllByRegion(Region region);
    }
}
