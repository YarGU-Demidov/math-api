using System;

namespace MathSite.Api.Core
{
    public class BaseEntity : BaseEntity<Guid>
    {
    }

    public class BaseEntity<TPrimaryKey>
    {
        public TPrimaryKey Id { get; set; }
        public DateTime CreationDate { get; set; }
    }
}