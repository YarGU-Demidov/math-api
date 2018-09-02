using System;
using System.Collections.Generic;
using MathSite.Api.Core;

namespace MathSite.Api.Dto
{
    public class DirectoryDto : BaseEntity
    {
        public string Name { get; set; }
        public Guid? RootDirectoryId { get; set; }
        public DirectoryDto RootDirectory { get; set; }

        public ICollection<FileDto> Files { get; set; } = new List<FileDto>();
        public ICollection<DirectoryDto> Directories { get; set; } = new List<DirectoryDto>();
    }
}