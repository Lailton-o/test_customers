using Test.Shared.Entities;

namespace Test.Domain.Entities
{
    public class Region : Entity
    {
        public Region()
        {

        }

        public Region(int id) : base(id)
        {

        }
        public string Name { get; set; }
    }
}
