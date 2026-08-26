using Application.Conversations.ProcessIncomingMessage;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services)
        {
            services.AddScoped<ProcessIncomingMessageHandler>();

            return services;
        }
    }
}