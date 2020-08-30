using MicroserviceWithRabbitMQ.Domain.Core.Bus;
using MicroserviceWithRabbitMQ.Infrastructure.Bus;
using Microsoft.Extensions.DependencyInjection;

namespace MicroserviceWithRabbitMQ.Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void Register(IServiceCollection services)
        {
            // Domain Bus
            services.AddTransient<IEventBus, RabbitMQBus>();
        }
    }
}