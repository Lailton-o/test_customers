using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Domain.Entities;
using Test.Domain.Interfaces.Repositories;
using Test.Infra.Context;

namespace Test.Infra.Repository
{
    public class GenderRepository : IGenderRepository
    {
        protected readonly TestContext Db;
        protected readonly DbSet<Gender> Genders;

        public GenderRepository(TestContext db)
        {
            Db = db;
            Genders = db.Genders;
        }

        public async Task<IEnumerable<Gender>> GetAll()
        {
            return await Genders.AsNoTracking().OrderBy(x => x.Name).ToListAsync();
        }
    }
}
