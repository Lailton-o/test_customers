using System;
using System.Linq.Expressions;
using Test.Domain.Entities;

namespace Test.Domain.Queries
{
    public static class CityQueries
    {
        public static Expression<Func<City, bool>> GetAllByRegion(int regionId)
        {
            return x => x.RegionId == regionId;
        }
    }
}
