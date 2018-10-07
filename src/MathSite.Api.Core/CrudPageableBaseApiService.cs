using System;
using System.Threading.Tasks;
using MathSite.Api.Internal;
using MathSite.Common.ApiServiceRequester.Abstractions;

namespace MathSite.Api.Core
{
    public enum ActionType
    {
        Update,
        Create
    }

    public abstract class CrudPageableBaseApiService<T> : CrudPageableBaseApiService<T, Guid>
        where T : BaseEntity
    {
        protected CrudPageableBaseApiService(IApiRequester apiRequester) : base(apiRequester)
        {
        }
    }

    public abstract class CrudPageableBaseApiService<T, TPrimaryKey> : PageableBaseApiService<T, TPrimaryKey> 
        where T : BaseEntity<TPrimaryKey>
    {
        protected CrudPageableBaseApiService(IApiRequester apiRequester) : base(apiRequester)
        {
        }

        public virtual async Task<T> GetById(Guid id)
        {
            var args = new MethodArgs
            {
                {"id", id.ToString()}
            };

            return await GetRequestAsync<T>(MethodNames.Global.GetOne, args);
        }

        public virtual async Task<Guid> CreateAsync(T entity)
        {
            var args = EntityToArgs(entity, ActionType.Create);

            return await PostRequestAsync<Guid>(MethodNames.Global.Create, args);
        }

        public virtual async Task<Guid> UpdateAsync(T entity)
        {
            var args = EntityToArgs(entity, ActionType.Update);
            args.Add(nameof(entity.Id), entity.Id.ToString());

            return await PostRequestAsync<Guid>(MethodNames.Global.Update, args);
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            var args = new MethodArgs
            {
                {"id", id.ToString()}
            };

            await PostRequestAsync(MethodNames.Global.Delete, args);
        }

        protected abstract MethodArgs EntityToArgs(T entity, ActionType action);
    }
}