using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MathSite.Api.Core;
using MathSite.Api.Dto;
using MathSite.Api.Internal;
using MathSite.Common.ApiServiceRequester.Abstractions;

namespace MathSite.Api.Services
{
    public class UsersService : CrudPageableBaseApiService<UserDto>
    {
        public UsersService(IApiRequester apiRequester)
            : base(apiRequester)
        {
        }

        protected override string ServiceName { get; } = ServiceNames.Users;

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            return await GetRequestAsync<IEnumerable<UserDto>>(MethodNames.Users.GetAll);
        }

        public async Task<UserDto> GetByLogin(string login)
        {
            var args = new MethodArgs
            {
                {nameof(login), login}
            };

            return await GetRequestAsync<UserDto>(MethodNames.Users.GetByLogin, args);
        }

        public async Task<bool> UserHasRightAsync(Guid userId, string rightAlias)
        {
            var args = new MethodArgs
            {
                {nameof(userId), userId.ToString()},
                {nameof(rightAlias), rightAlias}
            };

            return await GetRequestAsync<bool>(MethodNames.Users.HasRight, args);
        }

        public async Task<UserDto> GetByLoginAndPasswordAsync(string login, string password)
        {
            var args = new MethodArgs
            {
                {nameof(login), login},
                {nameof(password), password}
            };

            return await PostRequestAsync<UserDto>(MethodNames.Users.GetByLoginAndPassword, args);
        }

        protected override MethodArgs EntityToArgs(UserDto user, ActionType action)
        {
            return new MethodArgs
            {
                {nameof(user.Login), user.Login},
                {nameof(user.Password), user.Password},
                {nameof(user.GroupId), user.GroupId}
            };
        }
    }
}