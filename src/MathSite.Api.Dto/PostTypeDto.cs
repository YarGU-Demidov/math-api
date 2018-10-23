using System;
using MathSite.Api.Core;

namespace MathSite.Api.Dto
{
    public class PostTypeDto : BaseEntityWithAlias
    {
        public string Name { get; set; }
        public Guid DefaultPostsSettingsId { get; set; }
        public PostSettingDto DefaultPostsSettings { get; set; }
    }
}