using System;
using System.Collections.Generic;
using System.Text;

namespace DestekPaneli.Domain.Common
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            Id = Guid.CreateVersion7();
        }
        public Guid Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
    }
}
