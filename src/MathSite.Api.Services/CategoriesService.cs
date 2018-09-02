using System.Threading.Tasks;
using MathSite.Api.Core;
using MathSite.Api.Dto;
using MathSite.Api.Internal;
using MathSite.Common.ApiServiceRequester.Abstractions;

namespace MathSite.Api.Services
{
    public class CategoriesService : CrudPagableBaseApiService<CategoryDto>
    {
        public CategoriesService(IApiRequester apiRequester) : base(apiRequester)
        {
        }
        
        public async Task<bool> GetCategoryByAliasAsync(string alias)
        {
            var args = new MethodArgs
            {
                {"Alias", alias}
            };

            return await PostRequestAsync<bool>(MethodNames.Categories.GetCategoryByAlias, args);
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