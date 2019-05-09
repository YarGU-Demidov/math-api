using System.Threading.Tasks;
using MathSite.Api.Core;
using MathSite.Api.Dto;
using MathSite.Api.Internal;
using MathSite.Common.ApiServiceRequester.Abstractions;

namespace MathSite.Api.Services
{
    public class PostSeoSettingsService : CrudPageableBaseApiService<PostSeoSettingDto>
    {
        public PostSeoSettingsService(IApiRequester apiRequester) : base(apiRequester)
        {
        }

        protected override string ServiceName { get; } = ServiceNames.PostSeoSettings;

        public async Task<PostSeoSettingDto> GetByPostIdAsync(PostDto post)//TODO CHANGED
        {
            var args = new MethodArgs
            {
                {"postId", post.Id.ToString()}
            };

            return await GetRequestAsync<PostSeoSettingDto>(MethodNames.PostSeoSettings.GetByPostId, args);
        }

        protected override MethodArgs EntityToArgs(PostSeoSettingDto setting, ActionType action)
        {
            return new MethodArgs
            {
                {nameof(setting.Url), setting.Url},
                {nameof(setting.Description), setting.Description},
                {nameof(setting.Keywords), ToStringEnumerable(setting.Keywords)},
                {nameof(setting.Title), setting.Title}
            };
        }
    }
}