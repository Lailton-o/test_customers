using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Test.Domain.Entities;

namespace Test.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<UserSys> Login(string email, string password);
        Task<UserSys> GetUserRoleByLogin(string login);
        Task<IEnumerable<UserSys>> GetAllSellers();
        Task<UserSys> Single(Expression<Func<UserSys, bool>> predicate);
    }
}
