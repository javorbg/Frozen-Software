using Prism.Mvvm;
using System;

namespace FrozenSoftware.Models
{
    public abstract class EntityBase : BindableBase , IEquatable<EntityBase>
    {
        public int Id { get; set; }

        public bool Equals(EntityBase other)
        {
            if (this.Id == 0 || other.Id == 0)
                return object.ReferenceEquals(this, other);

            return Id == other.Id;
        }
    }
}
