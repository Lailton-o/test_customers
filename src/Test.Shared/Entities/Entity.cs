namespace Test.Shared.Entities
{
    public abstract class Entity
    {
        public Entity()
        {

        }
        public Entity(int id)
        {
            Id = id;
        }
        public int Id { get; private set; }
    }
}
