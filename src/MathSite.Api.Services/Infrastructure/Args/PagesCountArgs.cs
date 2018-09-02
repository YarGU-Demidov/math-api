using MathSite.Api.Dto;

namespace MathSite.Api.Services.Infrastructure.Args
{
    public class PagesCountArgs : PostArgs
    {
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

        public PostTypeDto PostType { get; }
        public CategoryDto Category { get; }
        public int PerPage { get; }
    }
}