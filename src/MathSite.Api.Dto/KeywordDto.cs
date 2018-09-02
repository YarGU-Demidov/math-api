using System.Collections.Generic;
using MathSite.Api.Core;

namespace MathSite.Api.Dto
{
    public class KeywordDto : BaseEntity
    {
        public string Name { get; set; }
        public string Alias { get; set; }

        /// <summary>
        ///     Список постов, содержащих это ключевое слово.
        /// </summary>
        public ICollection<PostDto> Posts { get; set; } = new List<PostDto>();
    }
}