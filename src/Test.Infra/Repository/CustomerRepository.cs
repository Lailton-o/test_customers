using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Domain.Entities;
using Test.Domain.Interfaces.Repositories;
using Test.Infra.Context;
using Test.Shared.DTOs;

namespace Test.Infra.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        protected readonly TestContext Db;
        protected readonly DbSet<Customer> Customers;

        public CustomerRepository(TestContext context)
        {
            Customers = context.Customers;
            Db = context;
        }
        public async Task<IEnumerable<CustomersForAdmin>> GetCustomersAdmin(FilterCustomer filter)
        {
            var result = Customers.AsNoTracking();

            if (!string.IsNullOrEmpty(filter.Name))
                result = result.Where(p => p.Name.Contains(filter.Name));

            if (filter.City.HasValue)
                result = result.Where(p => p.CityId == filter.City);

            if (filter.City.HasValue && filter.Region.HasValue)
                result = result.Where(p => p.City.RegionId == filter.Region);

            if (filter.LastPurchaseBegins.HasValue && filter.LastPurchaseEnds.HasValue)
                result = result.Where(p => p.LastPurchase.Value >= filter.LastPurchaseBegins.Value && p.LastPurchase <= filter.LastPurchaseEnds.Value);

            if (filter.Classification.HasValue)
                result = result.Where(p => p.ClassificationId == filter.Classification);

            if (filter.Seller.HasValue)
                result = result.Where(p => p.UserId == filter.Seller);

            return await result.Select(x => new CustomersForAdmin
            {
                Name = x.Name,
                City = x.City.Name,
                Classification = x.Classification.Name,
                Gender = x.Gender.Name,
                LastPurcharse = x.LastPurchase.Value.ToShortDateString(),
                Phone = x.Phone,
                Seller = x.User.Login,
                Region = x.Region.Name
            }).ToListAsync();

        }

        public async Task<IEnumerable<CustomersForSellers>> GetCustomersSellers(FilterCustomer filter)
        {
            var result = Customers.AsNoTracking();

            if (!string.IsNullOrEmpty(filter.Name))
                result = result.Where(p => p.Name.Contains(filter.Name));

            if (filter.City.HasValue)
                result = result.Where(p => p.CityId == filter.City);

            if (filter.City.HasValue && filter.Region.HasValue)
                result = result.Where(p => p.City.RegionId == filter.Region);

            if (filter.LastPurchaseBegins.HasValue && filter.LastPurchaseEnds.HasValue)
                result = result.Where(p => p.LastPurchase.Value >= filter.LastPurchaseBegins.Value && p.LastPurchase <= filter.LastPurchaseEnds.Value);

            if (filter.Classification.HasValue)
                result = result.Where(p => p.ClassificationId == filter.Classification);

            if (filter.Seller.HasValue)
                result = result.Where(p => p.UserId == filter.Seller);

            return await result.Select(x => new CustomersForSellers
            {
                Name = x.Name,
                City = x.City.Name,
                Classification = x.Classification.Name,
                Gender = x.Gender.Name,
                LastPurcharse = x.LastPurchase.Value.ToShortDateString(),
                Phone = x.Phone,
                Region = x.Region.Name
            }).ToListAsync();
        }
    }
}
