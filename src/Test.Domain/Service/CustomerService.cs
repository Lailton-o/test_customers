using System.Collections.Generic;
using System.Threading.Tasks;
using Test.Domain.Interfaces.Repositories;
using Test.Domain.Interfaces.Services;
using Test.Shared.DTOs;

namespace Test.Domain.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<CustomersForAdmin>> GetCustomersAdminBy(FilterCustomer filter)
        {
            return await _customerRepository.GetCustomersAdmin(filter);
        }

        public async Task<IEnumerable<CustomersForSellers>> GetCustomersSellersBy(FilterCustomer filter)
        {
            return await _customerRepository.GetCustomersSellers(filter);
        }
    }
}
