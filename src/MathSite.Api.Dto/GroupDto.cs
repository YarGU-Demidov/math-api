using System;
using System.Collections.Generic;
using MathSite.Api.Core;

namespace MathSite.Api.Dto
{
    public class GroupDto : BaseEntity
    {
        public string Name { get; set; }
        public string Alias { get; set; }

        /// <summary>
        ///     Описание.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     Идентификатор родительской группы.
        /// </summary>
        public Guid? ParentGroupId { get; set; }

        /// <summary>
        ///     Родительская группа.
        /// </summary>
        public GroupDto ParentGroup { get; set; }

        /// <summary>
        ///     Идентификатор типа группы.
        /// </summary>
        public Guid GroupTypeId { get; set; }

        /// <summary>
        ///     Тип группы.
        /// </summary>
        public GroupTypeDto GroupType { get; set; }

        /// <summary>
        ///     Является ли группа администраторской.
        ///     ОСТОРОЖНО! Позволяет делать всё!
        /// </summary>
        public bool IsAdmin { get; set; }

        /// <summary>
        ///     Перечень прав группы.
        /// </summary>
        public ICollection<RightDto> GroupsRights { get; set; } = new List<RightDto>();

        /// <summary>
        ///     Перечень пользователей.
        /// </summary>
        public ICollection<UserDto> Users { get; set; } = new List<UserDto>();

        /// <summary>
        ///     Перечень групп-детей.
        /// </summary>
        public ICollection<GroupDto> ChildGroups { get; set; } = new List<GroupDto>();
    }
}