using GlobalAzure.RestContract.Client;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddCommand<TCommand>(this IServiceCollection services, string name)
            where TCommand : class, ICommand
        {
            services.AddSingleton<ICommandInfo>(new CommandInfo<TCommand>(name));
            services.AddScoped<TCommand>();

            return services;
        }

        public static ICommand GetCommand(this IServiceProvider services, string name)
        {
            var info = services.GetServices<ICommandInfo>().Where(p => p.Command == name).FirstOrDefault();

            if (info != null)
            {
                return info.Create(services);
            }

            return null;
        }
    }
}
