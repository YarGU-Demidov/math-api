using System.Collections.Generic;
using MathSite.Api.Core;

namespace MathSite.Api.Dto
{
    public class GroupTypeDto : BaseEntityWithAlias
    {
        public string Name { get; set; }

        /// <summary>
        ///     Описание типа группы.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     Список групп этого типа.
        /// </summary>
        public ICollection<GroupDto> Groups { get; set; } = new List<GroupDto>();
    }
}