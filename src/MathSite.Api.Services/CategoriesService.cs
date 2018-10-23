using System.Threading.Tasks;
using MathSite.Api.Core;
using MathSite.Api.Dto;
using MathSite.Api.Internal;
using MathSite.Common.ApiServiceRequester.Abstractions;

namespace MathSite.Api.Services
{
    public class CategoriesService : CrudPageableWithAliasBaseApiService<CategoryDto>
    {
        public CategoriesService(IApiRequester apiRequester) : base(apiRequester)
        {
        }

        protected override string ServiceName { get; } = ServiceNames.Categories;

        protected override MethodArgs EntityToArgs(CategoryDto category, ActionType action)
        {
            var args = new MethodArgs
            {
                {nameof(category.Name), category.Name},
                {nameof(category.Alias), category.Alias},
                {nameof(category.Description), category.Description}
            };

            if (action == ActionType.Create)
                args.Add(nameof(category.Alias), category.Alias);

            return args;
        }
    }
}