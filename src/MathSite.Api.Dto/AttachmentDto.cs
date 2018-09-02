using System;
using MathSite.Api.Core;

namespace MathSite.Api.Dto
{
    public class AttachmentDto : BaseEntity
    {
        public bool Allowed { get; set; }
        public Guid PostId { get; set; }
        public PostDto Post { get; set; }
        public Guid FileId { get; set; }
        public FileDto File { get; set; }
    }
}