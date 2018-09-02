using System;
using MathSite.Api.Core;

namespace MathSite.Api.Dto
{
    public class PostRatingDto : BaseEntity
    {
        public bool? Value { get; set; }

        public Guid PostId { get; set; }

        public PostDto Post { get; set; }

        public Guid UserId { get; set; }

        public UserDto User { get; set; }
    }
}