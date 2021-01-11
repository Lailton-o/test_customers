using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Domain.Entities;
using Test.Domain.Interfaces.Repositories;
using Test.Infra.Context;

namespace Test.Infra.Repository
{
    public class RegionRepository : IRegionRepository
    {
        protected readonly TestContext Db;
        protected readonly DbSet<Region> Regions;

        public RegionRepository(TestContext db)
        {
            Db = db;
            Regions = db.Regions;
        }

        public async Task<IEnumerable<Region>> GetAll()
        {
            return await Regions.AsNoTracking().OrderBy(x=>x.Name).ToListAsync();
        }
    }
}
