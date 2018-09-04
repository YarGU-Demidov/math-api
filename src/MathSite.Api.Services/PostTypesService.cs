using System.Threading.Tasks;
using MathSite.Api.Core;
using MathSite.Api.Dto;
using MathSite.Api.Internal;
using MathSite.Common.ApiServiceRequester.Abstractions;

namespace MathSite.Api.Services
{
    public class PostTypesService : CrudPageableBaseApiService<PostTypeDto>
    {
        public PostTypesService(IApiRequester apiRequester) : base(apiRequester)
        {
        }

        protected override string ServiceName { get; } = ServiceNames.PostTypes;

        public async Task<PostTypeDto> GetByPostIdAsync(PostDto post)
        {
            var args = new MethodArgs
            {
                {"postId", post.Id.ToString()}
            };

            return await GetRequestAsync<PostTypeDto>(MethodNames.PostTypes.GetByPostId, args);
        }

        public async Task<PostTypeDto> GetByAliasAsync(string alias)
        {
            var args = new MethodArgs
            {
                {nameof(alias), alias}
            };

            return await GetRequestAsync<PostTypeDto>(MethodNames.PostTypes.GetByAlias, args);
        }

        protected override MethodArgs EntityToArgs(PostTypeDto postType, ActionType action)
        {
            return new MethodArgs
            {
                {nameof(postType.DefaultPostsSettingsId), postType.DefaultPostsSettingsId.ToString()}
            };
        }
    }
}