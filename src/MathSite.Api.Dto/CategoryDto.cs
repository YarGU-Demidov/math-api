using MathSite.Api.Core;

namespace MathSite.Api.Dto
{
    public class CategoryDto : BaseEntityWithAlias
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}