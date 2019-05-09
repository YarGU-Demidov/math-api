using System;
using System.Collections.Generic;
using MathSite.Api.Dto;

namespace MathSite.Api.Services.Infrastructure.Args
{
    public class PostsGetterArgs : PostArgs
    {
        public PostsGetterArgs() { }
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

        public Guid? CategoryId { get; set; }
        public int Page { get; set; }
        public int PerPage { get; set; }
        public PostTypeDto PostType { get; set; }
        public IEnumerable<CategoryDto> ExcludedCategories { get; set; }
        public bool SortByPublish { get; set; }
    }
}