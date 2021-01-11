using Test.Shared.Entities;

namespace Test.Domain.Entities
{
    public class UserSys : Entity
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserRoleId { get; set; }

        public virtual UserRole UserRole { get; set; }
    }
}
