using System;
using Test.Shared.Entities;

namespace Test.Domain.Entities
{
    public class Customer : Entity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public int GenderId { get; set; }
        public int? CityId { get; set; }
        public int? RegionId { get; set; }
        public DateTime? LastPurchase { get; set; }
        public int? ClassificationId { get; set; }
        public int? UserId { get; set; }

        public virtual Gender Gender { get; set; }
        public virtual City City { get; set; }
        public virtual Region Region { get; set; }
        public virtual UserSys User { get; set; }
        public virtual Classification Classification { get; set; }
    }
}
