using System.Collections.Generic;
using System.Threading.Tasks;
using Test.Domain.Entities;

namespace Test.Domain.Interfaces.Repositories
{
    public interface IGenderRepository
    {
        Task<IEnumerable<Gender>> GetAll();
    }
}
