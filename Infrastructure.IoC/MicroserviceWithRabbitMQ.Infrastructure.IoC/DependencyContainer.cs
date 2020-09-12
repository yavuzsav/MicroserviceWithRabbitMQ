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
using Microsoft.Extensions.DependencyInjection;

namespace MicroserviceWithRabbitMQ.Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void Register(IServiceCollection services)
        {
            // Domain Bus
            services.AddTransient<IEventBus, RabbitMQBus>();

            // Domain Banking Commands
            services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();

            // Application Services
            services.AddTransient<IAccountService, AccountService>();

            // Data
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<BankingDbContext>();
        }
    }
}