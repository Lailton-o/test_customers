using System.Collections.Generic;
using System.Threading.Tasks;
using Test.Domain.Entities;

namespace Test.Domain.Interfaces.Repositories
{
    public interface IClassificationRepository
    {
        Task<IEnumerable<Classification>> GetAll();
    }
}
