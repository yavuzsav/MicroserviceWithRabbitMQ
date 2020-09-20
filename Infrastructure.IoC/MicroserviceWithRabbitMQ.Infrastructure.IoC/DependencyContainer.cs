using MediatR;
using MicroserviceWithRabbitMQ.Banking.Application.Interfaces;
using MicroserviceWithRabbitMQ.Banking.Application.Services;
using MicroserviceWithRabbitMQ.Banking.Data.Contexts;
using MicroserviceWithRabbitMQ.Banking.Data.Repositories;
using MicroserviceWithRabbitMQ.Banking.Domain.CommandHandlers;
using MicroserviceWithRabbitMQ.Banking.Domain.Commands;
using MicroserviceWithRabbitMQ.Banking.Domain.Interfaces;
using MicroserviceWithRabbitMQ.Domain.Core.Bus;
using MicroserviceWithRabbitMQ.Infrastructure.Bus;
using MicroserviceWithRabbitMQ.Transfer.Application.Interfaces;
using MicroserviceWithRabbitMQ.Transfer.Application.Services;
using MicroserviceWithRabbitMQ.Transfer.Data.Contexts;
using MicroserviceWithRabbitMQ.Transfer.Data.Repository;
using MicroserviceWithRabbitMQ.Transfer.Domain.EventHandlers;
using MicroserviceWithRabbitMQ.Transfer.Domain.Events;
using MicroserviceWithRabbitMQ.Transfer.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MicroserviceWithRabbitMQ.Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void Register(IServiceCollection services)
        {
            // Domain Bus
            services.AddSingleton<IEventBus, RabbitMQBus>(serviceProvider =>
            {
                var scopeFactory = serviceProvider.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(serviceProvider.GetService<IMediator>(), scopeFactory);
            });

            // Subscriptions
            services.AddTransient<TransferEventHandler>();

            // Domain Events
            services.AddTransient<IEventHandler<TransferCreatedEvent>, TransferEventHandler>();

            // Domain Banking Commands
            services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();

            // Application Services
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<ITransferService, TransferService>();

            // Data
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<ITransferRepository, TransferRepository>();
            services.AddTransient<BankingDbContext>();
            services.AddTransient<TransferDbContext>();
        }
    }
}
