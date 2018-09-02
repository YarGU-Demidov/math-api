using System;
using MathSite.Api.Core;

namespace MathSite.Api.Dto
{
    public class PostTypeDto : BaseEntity
    {
        public Guid DefaultPostsSettingsId { get; set; }
        public PostSettingDto DefaultPostsSettings { get; set; }
    }
}