using System;
using System.Collections.Generic;
using System.Linq;
using MathSite.Api.Core;

namespace MathSite.Api.Services.Infrastructure
{
    public class MathServices
    {
        private readonly BaseApiService[] _services;

        public MathServices(IEnumerable<BaseApiService> services)
        {
            _services = services.ToArray();
        }

        public UsersService Users => GetService<UsersService>();
        public SiteSettingsService SiteSettings => GetService<SiteSettingsService>();
        public ProfessorsService Professors => GetService<ProfessorsService>();
        public PersonsService Persons => GetService<PersonsService>();
        public PostTypesService PostTypes => GetService<PostTypesService>();
        public PostSettingsService PostSettings => GetService<PostSettingsService>();
        public PostSeoSettingsService PostSeoSettings => GetService<PostSeoSettingsService>();
        public PostsService Posts => GetService<PostsService>();
        public GroupsService Groups => GetService<GroupsService>();
        public DirectoriesService Directories => GetService<DirectoriesService>();
        public FilesService Files => GetService<FilesService>();
        public CategoriesService Categories => GetService<CategoriesService>();

        private T GetService<T>() where T : BaseApiService
        {
            return (T) _services.First(service => service is T);
        }

        private BaseApiService GetService(Type type)
        {
            return _services.First(service => service.GetType() == type);
        }
    }
}