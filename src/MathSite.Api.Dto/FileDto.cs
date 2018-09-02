using System;
using MathSite.Api.Core;

namespace MathSite.Api.Dto
{
    public class FileDto : BaseEntity
    {
        public string Name { get; set; }

        /// <summary>
        ///     Путь к файлу в файловой системе.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        ///     Расширение файла
        /// </summary>
        public string Extension { get; set; }

        /// <summary>
        ///     Хэш файла.
        /// </summary>
        public string Hash { get; set; }

        /// <summary>
        ///     Id папки этого файла.
        /// </summary>
        public Guid? DirectoryId { get; set; }

        /// <summary>
        ///     Папка этого файла.
        /// </summary>
        public DirectoryDto Directory { get; set; }
    }
}