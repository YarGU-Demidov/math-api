using System;
using MathSite.Api.Core;

namespace MathSite.Api.Dto
{
    public class PostSettingDto : BaseEntity
    {
        public bool IsCommentsAllowed { get; set; }
        public bool CanBeRated { get; set; }
        public bool PostOnStartPage { get; set; }
        public string Layout { get; set; }

        public Guid? PreviewImageId { get; set; }
        public FileDto PreviewImage { get; set; }

        public DateTime? EventTime { get; set; }
        public string EventLocation { get; set; }
    }
}