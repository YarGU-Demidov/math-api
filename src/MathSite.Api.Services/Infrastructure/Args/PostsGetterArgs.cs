using System;
using System.Collections.Generic;
using MathSite.Api.Dto;

namespace MathSite.Api.Services.Infrastructure.Args
{
    public class PostsGetterArgs : PostArgs
    {
        public PostsGetterArgs(
            Guid? categoryId,
            int page,
            int perPage,
            PostTypeDto postType,
            IEnumerable<CategoryDto> excludedCategories = null,
            bool sortByPublish = true,
            PublishStatus publishStatus = PublishStatus.Any,
            FrontPageStatus frontPageStatus = FrontPageStatus.Any,
            ItemAvailableStatus itemAvailableStatus = ItemAvailableStatus.Any
        ) : base(publishStatus, frontPageStatus, itemAvailableStatus)
        {
            CategoryId = categoryId;
            Page = page;
            PerPage = perPage;
            PostType = postType;
            ExcludedCategories = excludedCategories;
            SortByPublish = sortByPublish;
        }

        public Guid? CategoryId { get; }
        public int Page { get; }
        public int PerPage { get; }
        public PostTypeDto PostType { get; }
        public IEnumerable<CategoryDto> ExcludedCategories { get; }
        public bool SortByPublish { get; }
    }
}