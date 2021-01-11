using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Domain.Entities;
using Test.Domain.Interfaces.Repositories;
using Test.Infra.Context;

namespace Test.Infra.Repository
{
    public class ClassificationRepository : IClassificationRepository
    {
        protected readonly TestContext Db;
        protected readonly DbSet<Classification> Classifications;

        public ClassificationRepository(TestContext db)
        {
            Db = db;
            Classifications = db.Classifications;
        }

        public async Task<IEnumerable<Classification>> GetAll()
        {
            return await Classifications.AsNoTracking().OrderBy(x => x.Name).ToListAsync();
        }
    }
}
