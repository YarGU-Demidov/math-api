using System.Threading.Tasks;
using MathSite.Api.Core;
using MathSite.Api.Dto;
using MathSite.Api.Internal;
using MathSite.Common.ApiServiceRequester.Abstractions;

namespace MathSite.Api.Services
{
    public class DirectoriesService : CrudPagableBaseApiService<DirectoryDto>
    {
        public DirectoriesService(IApiRequester apiRequester) : base(apiRequester)
        {
        }

        public async Task<bool> MoveAllAsync(DirectoryDto from, DirectoryDto to)
        {
            var args = new MethodArgs
            {
                {"from", from.Id.ToString()},
                {"to", to.Id.ToString()},
            };

            return await PostRequestAsync<bool>(MethodNames.Directories.MoveDirectories, args);
        }


        public async Task<DirectoryDto> GetDirectoryWithPathAsync(string path)
        {
            var args = new MethodArgs
            {
                {nameof(path), path}
            };

            return await PostRequestAsync<DirectoryDto>(MethodNames.Directories.GetDirectoryWithPath, args);
        }

        protected override string ServiceName { get; } = ServiceNames.Directories;

        protected override MethodArgs EntityToArgs(DirectoryDto entity, ActionType action)
        {
            return new MethodArgs
            {
                {nameof(entity.RootDirectoryId), entity.RootDirectoryId.ToString()},
                {nameof(entity.Name), entity.Name}
            };
        }
    }
}