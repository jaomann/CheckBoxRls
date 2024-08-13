using CheckBox.Core.Contracts.entities;
using CheckBox.Core.Contracts.repositories;
using CheckBox.Data.Repositories;
using CheckBox.Services;
using Microsoft.Extensions.DependencyInjection;
namespace CheckBox.DependencyInjection
{
    public static class DependencyInjectionExtension
    {
        public static void AddServicesDependency(this IServiceCollection services)
        {
            services.AddScoped<INoteService, NoteService>();
            services.AddScoped<IUserService, UserService>();
            
        }
        public static void AddRepositoryDependency(this IServiceCollection services)
        {
            services.AddScoped<INoteRepository, NoteRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
