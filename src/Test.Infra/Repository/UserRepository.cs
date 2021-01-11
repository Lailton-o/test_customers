using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Test.Domain.Entities;
using Test.Domain.Interfaces.Repositories;
using Test.Infra.Context;

namespace Test.Infra.Repository
{
    public class UserRepository : IUserRepository
    {
        protected readonly TestContext Db;
        protected readonly DbSet<UserSys> Users;

        public UserRepository(TestContext db)
        {
            Db = db;
            Users = db.Users;
        }
        public async Task<UserSys> GetUserRoleByLogin(string login)
        {
            return await Users.Include(x => x.UserRole).AsNoTracking().FirstOrDefaultAsync(x => x.Login == login);
        }

        public async Task<IEnumerable<UserSys>> GetAllSellers()
        {
            return await Users.AsNoTracking().Where(x => x.UserRole.IsAdmin == false).OrderBy(x=> x.Email).ToListAsync();
        }

        public async Task<UserSys> Single(Expression<Func<UserSys, bool>> predicate)
        {
            return await Users.AsNoTracking().FirstOrDefaultAsync(predicate);
        }

        public async Task<UserSys> Login(string email, string password)
        {
            return await Users.AsNoTracking().Include(x => x.UserRole).FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
        }
    }
}
