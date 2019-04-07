using Prism.Mvvm;
using System;
using System.ComponentModel;

namespace FrozenSoftware.Models
{
    public abstract class EntityBase : BindableBase, IEquatable<EntityBase> , IDataErrorInfo
    {
        public int Id { get; set; }

        public string Error { get; }

        public virtual string this[string columnName]
        {
            get
            {
                return null;
            }
        }

        public bool Equals(EntityBase other)
        {
            if (this.Id == 0 || other.Id == 0)
                return object.ReferenceEquals(this, other);

            return this.Id == other.Id;
        }
    }
}
