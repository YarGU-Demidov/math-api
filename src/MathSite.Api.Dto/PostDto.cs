using System;
using System.Collections.Generic;
using MathSite.Api.Core;

namespace MathSite.Api.Dto
{
    public class PostDto : BaseEntity
    {
        /// <summary>
        ///     Заголовок поста.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///     Первые предложения или очень краткое содержание поста.
        /// </summary>
        public string Excerpt { get; set; }

        /// <summary>
        ///     Содержимое поста.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        ///     Состояние публикации (true - опубликовано, false - нет).
        /// </summary>
        public bool Published { get; set; }

        /// <summary>
        ///     Удален ли пост.
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        ///     Дата публикации поста.
        /// </summary>
        public DateTime PublishDate { get; set; }

        /// <summary>
        ///     Идентификатор типа поста.
        /// </summary>
        public Guid PostTypeId { get; set; }

        /// <summary>
        ///     Идентификатор автора поста.
        /// </summary>
        public Guid AuthorId { get; set; }

        /// <summary>
        ///     Автор поста.
        /// </summary>
        public UserDto Author { get; set; }

        /// <summary>
        ///     Тип поста.
        /// </summary>
        public PostTypeDto PostType { get; set; }

        /// <summary>
        ///     Идентификатор настроек поста.
        /// </summary>
        public Guid? PostSettingsId { get; set; }

        /// <summary>
        ///     Настройки поста.
        /// </summary>
        public PostSettingDto PostSettings { get; set; }

        /// <summary>
        ///     Идентификатор SEO настроек поста.
        /// </summary>
        public Guid PostSeoSettingsId { get; set; }

        /// <summary>
        ///     SEO настройки поста.
        /// </summary>
        public PostSeoSettingDto PostSeoSetting { get; set; }

        /// <summary>
        ///     Список категорий поста.
        /// </summary>
        public ICollection<CategoryDto> PostCategories { get; set; } = new List<CategoryDto>();

        /// <summary>
        ///     Список владельцев поста.
        /// </summary>
        public ICollection<UserDto> PostOwners { get; set; } = new List<UserDto>();

        /// <summary>
        ///     Список пользователей, которым точно разрешен доступ к посту.
        /// </summary>
        public ICollection<UserDto> UsersAllowed { get; set; } = new List<UserDto>();

        /// <summary>
        ///     Список оценок от пользователей.
        /// </summary>
        public ICollection<PostRatingDto> PostRatings { get; set; } = new List<PostRatingDto>();

        /// <summary>
        ///     Список приложений к посту.
        /// </summary>
        public ICollection<AttachmentDto> PostAttachments { get; set; } = new List<AttachmentDto>();

        /// <summary>
        ///     Список групп, которым разрешен доступ к посту.
        /// </summary>
        public ICollection<GroupDto> GroupsAllowed { get; set; } = new List<GroupDto>();
    }
}