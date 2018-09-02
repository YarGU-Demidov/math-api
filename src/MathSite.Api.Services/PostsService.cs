using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MathSite.Api.Core;
using MathSite.Api.Dto;
using MathSite.Api.Internal;
using MathSite.Api.Services.Infrastructure.Args;
using MathSite.Common.ApiServiceRequester.Abstractions;

namespace MathSite.Api.Services
{
    public class PostsService : CrudPagableBaseApiService<PostDto>
    {
        public PostsService(IApiRequester apiRequester) : base(apiRequester)
        {
        }

        protected override string ServiceName { get; } = ServiceNames.Posts;

        public Task<int> GetPagesCountAsync(PagesCountArgs pagesCountArgs)
        {
            var args = new MethodArgs
            {
                {nameof(pagesCountArgs.FrontPageStatus), pagesCountArgs.FrontPageStatus.ToString()},
                {nameof(pagesCountArgs.ItemAvailableStatus), pagesCountArgs.ItemAvailableStatus.ToString()},
                {nameof(pagesCountArgs.PublishStatus), pagesCountArgs.PublishStatus.ToString()},
                {nameof(pagesCountArgs.PerPage), pagesCountArgs.PerPage.ToString()},
                {nameof(pagesCountArgs.Category), pagesCountArgs.Category?.Id.ToString()},
                {nameof(pagesCountArgs.PostType), pagesCountArgs.PostType.Id.ToString()}
            };

            return PostRequestAsync<int>(MethodNames.Posts.GetPagesCount, args);
        }

        public async Task<PostDto> GetPostByUrlAndTypeAsync(string url, PostTypeDto postType)
        {
            var args = new MethodArgs
            {
                {nameof(url), url},
                {"postTypeId", postType.Id.ToString()}
            };

            return await PostRequestAsync<PostDto>(MethodNames.Posts.GetPostByUrlAndType, args);
        }

        public async Task<IEnumerable<PostDto>> GetPosts(PostsGetterArgs postsGetterArgs)
        {
            var args = new MethodArgs
            {
                {nameof(postsGetterArgs.CategoryId), postsGetterArgs.CategoryId.ToString()},
                {
                    nameof(postsGetterArgs.ExcludedCategories),
                    postsGetterArgs.ExcludedCategories.Select(dto => dto.Id.ToString())
                },
                {nameof(postsGetterArgs.Page), postsGetterArgs.Page.ToString()},
                {nameof(postsGetterArgs.PerPage), postsGetterArgs.PerPage.ToString()},
                {nameof(postsGetterArgs.SortByPublish), postsGetterArgs.SortByPublish.ToString()},
                {nameof(postsGetterArgs.FrontPageStatus), postsGetterArgs.FrontPageStatus.ToString()},
                {nameof(postsGetterArgs.ItemAvailableStatus), postsGetterArgs.ItemAvailableStatus.ToString()},
                {nameof(postsGetterArgs.PublishStatus), postsGetterArgs.PublishStatus.ToString()},
                {"PostTypeId", postsGetterArgs.PostType.Id.ToString()}
            };

            return await PostRequestAsync<IEnumerable<PostDto>>(MethodNames.Posts.GetPosts, args);
        }

        protected override MethodArgs EntityToArgs(PostDto post, ActionType action)
        {
            return new MethodArgs
            {
                {nameof(post.Title), post.Title},
                {nameof(post.Excerpt), post.Excerpt},
                {nameof(post.Content), post.Content},
                {nameof(post.PublishDate), post.PublishDate.ToString("O")},
                {nameof(post.Published), post.Published.ToString()},
                {nameof(post.Deleted), post.Deleted.ToString()},
                {nameof(post.PostTypeId), post.PostTypeId.ToString()},
                {nameof(post.AuthorId), post.AuthorId.ToString()},
                {nameof(post.PostSettingsId), post.PostSettingsId.ToString()},
                {nameof(post.PostSeoSettingsId), post.PostSeoSettingsId.ToString()},
                {nameof(post.PostCategories), ToStringEnumerable(post.PostCategories)},
                {nameof(post.PostOwners), ToStringEnumerable(post.PostOwners)},
                {nameof(post.UsersAllowed), ToStringEnumerable(post.UsersAllowed)},
                {nameof(post.PostRatings), ToStringEnumerable(post.PostRatings)},
                {nameof(post.PostAttachments), ToStringEnumerable(post.PostAttachments)},
                {nameof(post.GroupsAllowed), ToStringEnumerable(post.GroupsAllowed)}
            };
        }
    }
}