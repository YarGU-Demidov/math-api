using MathSite.Api.Core;

namespace MathSite.Api.Dto
{
    public class RightDto : BaseEntity
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
    }
}