using MathSite.Api.Core;
using MathSite.Api.Dto;
using MathSite.Api.Internal;
using MathSite.Common.ApiServiceRequester.Abstractions;

namespace MathSite.Api.Services
{
    public class ProfessorsService : CrudPagableBaseApiService<ProfessorDto>
    {
        public ProfessorsService(IApiRequester apiRequester) : base(apiRequester)
        {
        }

        protected override string ServiceName { get; } = ServiceNames.Professors;

        protected override MethodArgs EntityToArgs(ProfessorDto professor, ActionType action)
        {
            return new MethodArgs
            {
                {nameof(professor.PersonId), professor.PersonId},
                {nameof(professor.Department), professor.Department},
                {nameof(professor.Description), professor.Description},
                {nameof(professor.Faculty), professor.Faculty},
                {nameof(professor.MathNetLink), professor.MathNetLink},
                {nameof(professor.ScientificTitle), professor.ScientificTitle},
                {nameof(professor.Status), professor.Status},
                {nameof(professor.BibliographicIndexOfWorks), professor.BibliographicIndexOfWorks},
                {nameof(professor.Graduated), professor.Graduated},
                {nameof(professor.TermPapers), professor.TermPapers},
                {nameof(professor.Theses), professor.Theses}
            };
        }
    }
}