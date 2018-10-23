using System.Threading.Tasks;
using MathSite.Api.Core;
using MathSite.Api.Dto;
using MathSite.Api.Internal;
using MathSite.Common.ApiServiceRequester.Abstractions;

namespace MathSite.Api.Services
{
    public class PostTypesService : CrudPageableWithAliasBaseApiService<PostTypeDto>
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

        protected override MethodArgs EntityToArgs(PostTypeDto postType, ActionType action)
        {
            return new MethodArgs
            {
                {nameof(postType.DefaultPostsSettingsId), postType.DefaultPostsSettingsId.ToString()}
            };
        }
    }
}