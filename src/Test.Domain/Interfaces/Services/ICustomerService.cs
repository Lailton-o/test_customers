using System.Collections.Generic;
using System.Threading.Tasks;
using Test.Shared.DTOs;

namespace Test.Domain.Interfaces.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomersForAdmin>> GetCustomersAdminBy(FilterCustomer filter);
        Task<IEnumerable<CustomersForSellers>> GetCustomersSellersBy(FilterCustomer filter);
    }
}
