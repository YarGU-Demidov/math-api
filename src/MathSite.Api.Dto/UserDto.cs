using System;
using MathSite.Api.Core;

namespace MathSite.Api.Dto
{
    public class UserDto : BaseEntity
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public Guid PersonId { get; set; }
        public PersonDto Person { get; set; }

        public string GroupId { get; set; }
        public GroupDto Group { get; set; }
    }
}