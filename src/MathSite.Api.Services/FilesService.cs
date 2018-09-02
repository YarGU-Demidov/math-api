using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using MathSite.Api.Core;
using MathSite.Api.Dto;
using MathSite.Api.Internal;
using MathSite.Common.ApiServiceRequester.Abstractions;

namespace MathSite.Api.Services
{
    public class FilesService : CrudPagableBaseApiService<FileDto>
    {
        public FilesService(IApiRequester apiRequester) : base(apiRequester)
        {
        }

        protected override string ServiceName { get; } = ServiceNames.Files;

        public async Task<IEnumerable<FileDto>> GetFilesByExtensionsAsync(IEnumerable<string> extensions)
        {
            var args = new MethodArgs
            {
                {nameof(extensions), extensions}
            };

            return await PostRequestAsync<IEnumerable<FileDto>>(MethodNames.Files.GetFilesByExtensions, args);
        }

        public async Task<Stream> GetFileStreamByIdAsync(Guid id)
        {
            var args = new MethodArgs
            {
                {nameof(id), id.ToString()}
            };

            return await PostRequestAsync<Stream>(MethodNames.Files.GetFileById, args);
        }

        public async Task<Guid> PutFileAsync(DirectoryDto directory, string fileName, Stream file)
        {
            var args = new MethodArgs
            {
                {"FileName", fileName},
                {"DirectoryId", directory.Id.ToString()}
            };

            return await PostRequestAsync<Guid>(
                MethodNames.Files.PutFile, 
                args,
                new Dictionary<string, IEnumerable<Stream>> {{"File", new[] {file}}}
            );
        }

        protected override MethodArgs EntityToArgs(FileDto entity, ActionType action)
        {
            return new MethodArgs
            {
                {nameof(entity.Name),entity.Name},
                {nameof(entity.Path),entity.Path},
                {nameof(entity.DirectoryId),entity.DirectoryId.ToString()},
                {nameof(entity.Extension),entity.Extension},
                {nameof(entity.Hash),entity.Hash},
            };
        }
    }
}