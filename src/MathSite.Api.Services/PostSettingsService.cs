using System.Threading.Tasks;
using MathSite.Api.Core;
using MathSite.Api.Dto;
using MathSite.Api.Internal;
using MathSite.Common.ApiServiceRequester.Abstractions;

namespace MathSite.Api.Services
{
    public class PostSettingsService : CrudPageableBaseApiService<PostSettingDto>
    {
        public PostSettingsService(IApiRequester apiRequester) : base(apiRequester)
        {
        }

        protected override string ServiceName { get; } = ServiceNames.PostSettings;

        public async Task<PostSettingDto> GetByPostIdAsync(PostDto post)//TODO !!!!!!!
        {
            var args = new MethodArgs
            {
                {"postId", post.Id.ToString()}
            };

            return await GetRequestAsync<PostSettingDto>(MethodNames.PostSettings.GetByPostId, args);
        }

        protected override MethodArgs EntityToArgs(PostSettingDto setting, ActionType action)
        {
            return new MethodArgs
            {
                {nameof(setting.CanBeRated), setting.CanBeRated.ToString()},
                {nameof(setting.EventLocation), setting.EventLocation},
                {nameof(setting.EventTime), setting.EventTime.ToString()},
                {nameof(setting.IsCommentsAllowed), setting.IsCommentsAllowed.ToString()},
                {nameof(setting.Layout), setting.Layout},
                {nameof(setting.PostOnStartPage), setting.PostOnStartPage.ToString()},
                {nameof(setting.PreviewImageId), setting.PreviewImageId?.ToString()}
            };
        }
    }
}