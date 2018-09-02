using System;

namespace MathSite.Api.Core
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
    }
}