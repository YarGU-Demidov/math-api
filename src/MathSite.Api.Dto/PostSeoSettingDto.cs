using System.Collections.Generic;
using MathSite.Api.Core;

namespace MathSite.Api.Dto
{
    public class PostSeoSettingDto : BaseEntity
    {
        /// <summary>
        ///     URL поста.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        ///     Заголовок поста.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///     Описание поста.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     Ключевые слова поста.
        /// </summary>
        public ICollection<KeywordDto> Keywords { get; set; } = new List<KeywordDto>();
    }
}