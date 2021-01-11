using Test.Shared.Entities;

namespace Test.Domain.Entities
{
    public class City : Entity
    {
        public City()
        {
                
        }
        public string Name { get; set; }
        public int RegionId { get; set; }

        public virtual Region Region { get; set; }
    }
}
