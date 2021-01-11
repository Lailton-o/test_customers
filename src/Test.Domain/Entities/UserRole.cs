using Test.Shared.Entities;

namespace Test.Domain.Entities
{
    public class UserRole : Entity
    {
        public string Name { get; set; }
        public bool IsAdmin { get; set; }
    }
}
