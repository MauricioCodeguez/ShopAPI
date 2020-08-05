using System;

namespace Shop.Shared.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; private set; }
        public DateTime? Updated { get; set; }

        public Entity()
        {
            Id = Guid.NewGuid();
            Updated = DateTime.Now;
        }
    }
}