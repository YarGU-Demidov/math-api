using System;

namespace MathSite.Api.Core
{
    public class BaseEntityWithAlias : BaseEntityWithAlias<Guid>
    {
    }

    public class BaseEntityWithAlias<TPrimaryKey> : BaseEntity<TPrimaryKey>
    {
        public string Alias { get; set; }
    }
}