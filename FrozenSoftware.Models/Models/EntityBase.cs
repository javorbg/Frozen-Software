using PropertyChanged;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FrozenSoftware.Models
{
    [ImplementPropertyChanged]
    public abstract class EntityBase : IEquatable<EntityBase>, IDataErrorInfo
    {
        [Key]
        public int Id { get; set; }

        public string Error { get; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

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
