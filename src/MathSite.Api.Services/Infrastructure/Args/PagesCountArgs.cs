using MathSite.Api.Dto;

namespace MathSite.Api.Services.Infrastructure.Args
{
    public class PagesCountArgs : PostArgs
    {
        public PagesCountArgs() { }
        public PagesCountArgs(
            PostTypeDto postType,
            int perPage,
            PublishStatus publishStatus = PublishStatus.Any,
            FrontPageStatus frontPageStatus = FrontPageStatus.Any,
            ItemAvailableStatus itemAvailableStatus = ItemAvailableStatus.Any
        ) : this(postType, null, perPage, publishStatus, frontPageStatus, itemAvailableStatus)
        {
        }

        public PagesCountArgs(
            PostTypeDto postType,
            CategoryDto category,
            int perPage,
            PublishStatus publishStatus = PublishStatus.Any,
            FrontPageStatus frontPageStatus = FrontPageStatus.Any,
            ItemAvailableStatus itemAvailableStatus = ItemAvailableStatus.Any
        ) : base(publishStatus, frontPageStatus, itemAvailableStatus)
        {
            PostType = postType;
            Category = category;
            PerPage = perPage;
        }

        public PostTypeDto PostType {get; set; }
        public CategoryDto Category { get; set; }
        public int PerPage { get; set; }
    }
}