using System.Collections.Generic;
using System.Threading.Tasks;
using Test.Shared.DTOs;

namespace Test.Domain.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<CustomersForAdmin>> GetCustomersAdmin(FilterCustomer filter);
        Task<IEnumerable<CustomersForSellers>> GetCustomersSellers(FilterCustomer filter);
    }
}
