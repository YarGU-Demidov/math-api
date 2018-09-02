using System;
using MathSite.Api.Core;

namespace MathSite.Api.Dto
{
    public class PersonDto : BaseEntity
    {
        /// <summary>
        ///     Имя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Фамилия.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        ///     Отчество.
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        ///     Телефонный номер.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        ///     Дополнительный телефонный номер.
        /// </summary>
        public string AdditionalPhone { get; set; }

        /// <summary>
        ///     Дата рождения.
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        ///     Идентификатор изображения личности.
        /// </summary>
        public Guid? PhotoId { get; set; }

        /// <summary>
        ///     Файл.
        /// </summary>
        public FileDto Photo { get; set; }

        /// <summary>
        ///     Пользователь.
        /// </summary>
        public UserDto User { get; set; }

        public ProfessorDto Professor { get; set; }
    }
}