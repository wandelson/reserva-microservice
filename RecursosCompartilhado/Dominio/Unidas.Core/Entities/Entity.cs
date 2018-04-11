using System;
using System.Collections.Generic;
using System.Text;
using Unidas.Core.Interfaces;

namespace Unidas.Core.Entities
{
    public class Entity : IEntity
    {
        public Entity()
        {
            this.Id = Guid.NewGuid();
        }

        public Entity(Guid id)
        {
            this.Id = id;
        }

        public virtual Guid Id { get; protected set; }
    }
}
