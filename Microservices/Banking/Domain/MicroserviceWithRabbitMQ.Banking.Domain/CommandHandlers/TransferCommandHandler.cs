using MediatR;
using MicroserviceWithRabbitMQ.Banking.Domain.Commands;
using MicroserviceWithRabbitMQ.Banking.Domain.Events;
using MicroserviceWithRabbitMQ.Domain.Core.Bus;
using System.Threading;
using System.Threading.Tasks;

namespace MicroserviceWithRabbitMQ.Banking.Domain.CommandHandlers
{
    public class TransferCommandHandler : IRequestHandler<CreateTransferCommand, bool>
    {
        private readonly IEventBus _eventBus;

        public TransferCommandHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public Task<bool> Handle(CreateTransferCommand request, CancellationToken cancellationToken)
        {
            // publish event to RabbitMQ
            _eventBus.Publish(new TransferCreatedEvent(request.From, request.To, request.Amount));

            return Task.FromResult(true);
        }
    }
}