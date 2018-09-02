using System.Collections.Generic;
using System.Threading.Tasks;
using MathSite.Api.Core;
using MathSite.Api.Dto;
using MathSite.Api.Internal;
using MathSite.Common.ApiServiceRequester.Abstractions;

namespace MathSite.Api.Services
{
    public class PersonsService : CrudPagableBaseApiService<PersonDto>
    {
        public PersonsService(IApiRequester apiRequester) : base(apiRequester)
        {
        }

        protected override string ServiceName { get; } = ServiceNames.Persons;

        public async Task<IEnumerable<PersonDto>> GetAllWithoutUsersAsync()
        {
            return await GetRequestAsync<IEnumerable<PersonDto>>(MethodNames.Persons.GetAllWithoutUsers);
        }

        public async Task<IEnumerable<PersonDto>> GetAllWithoutProfessorsAsync()
        {
            return await GetRequestAsync<IEnumerable<PersonDto>>(MethodNames.Persons.GetAllWithoutProfessors);
        }

        protected override MethodArgs EntityToArgs(PersonDto person, ActionType action)
        {
            return new MethodArgs
            {
                {nameof(person.Name), person.Name},
                {nameof(person.MiddleName), person.MiddleName},
                {nameof(person.Surname), person.Surname},
                {nameof(person.Phone), person.Phone},
                {nameof(person.AdditionalPhone), person.AdditionalPhone},
                {nameof(person.Birthday), person.Birthday.ToString("O")},
                {nameof(person.PhotoId), person.PhotoId?.ToString()}
            };
        }
    }
}