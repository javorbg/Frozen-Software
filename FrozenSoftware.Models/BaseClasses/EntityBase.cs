using PropertyChanged;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrozenSoftware.Models
{
    [ImplementPropertyChanged]
    public abstract class EntityBase : IEquatable<EntityBase>, IDataErrorInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public string Error { get; }

        public Guid? LockId { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        [NotMapped]
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
