using System.Collections.Generic;
using System.Threading.Tasks;
using MathSite.Api.Core;
using MathSite.Api.Dto;
using MathSite.Api.Internal;
using MathSite.Common.ApiServiceRequester.Abstractions;

namespace MathSite.Api.Services
{
    public class GroupsService : CrudPageableWithAliasBaseApiService<GroupDto>
    {
        public GroupsService(IApiRequester apiRequester) : base(apiRequester)
        {
        }

        public async Task<IEnumerable<GroupDto>> GetGroupsByTypeAsync(string groupTypeAlias)
        {
            var args = new MethodArgs
            {
                {nameof(groupTypeAlias), groupTypeAlias}
            };

            return await GetRequestAsync<IEnumerable<GroupDto>>(MethodNames.Groups.GetGroupsByType, args);
        }

        public async Task<bool> HasRightAsync(string rightAlias)
        {
            var args = new MethodArgs
            {
                {nameof(rightAlias), rightAlias}
            };

            return await GetRequestAsync<bool>(MethodNames.Groups.GetGroupsByType, args);
        }

        protected override string ServiceName { get; } = ServiceNames.Groups;

        protected override MethodArgs EntityToArgs(GroupDto group, ActionType action)
        {
            var args = new MethodArgs
            {
                {nameof(group.Description), group.Description},
                {nameof(group.ChildGroups), ToStringEnumerable(group.ChildGroups)},
                {nameof(group.GroupTypeId), group.GroupTypeId.ToString()},
                {nameof(group.IsAdmin), group.IsAdmin.ToString()},
                {nameof(group.GroupsRights), ToStringEnumerable(group.GroupsRights)},
                {nameof(group.Name), group.Name},
                {nameof(group.ParentGroupId), group.ParentGroupId?.ToString()}
            };

            if (action == ActionType.Create)
                args.Add(nameof(group.Alias), group.Alias);

            return args;
        }
    }
}