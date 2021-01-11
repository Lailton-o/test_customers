using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Domain.Entities;
using Test.Domain.Interfaces.Repositories;
using Test.Domain.Queries;
using Test.Infra.Context;

namespace Test.Infra.Repository
{
    public class CityRepository : ICityRepository
    {
        protected readonly TestContext Db;
        protected readonly DbSet<City> Cities;

        public CityRepository(TestContext db)
        {
            Db = db;
            Cities = Db.Cities;
        }

        public async Task<IEnumerable<City>> GetAllByRegion(Region region)
        {
            return await Cities.AsNoTracking().Where(CityQueries.GetAllByRegion(region.Id)).OrderBy(x => x.Name).ToListAsync();
        }
    }
}
