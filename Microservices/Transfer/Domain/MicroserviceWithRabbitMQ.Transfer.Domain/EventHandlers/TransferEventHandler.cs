using System.Threading.Tasks;
using MicroserviceWithRabbitMQ.Domain.Core.Bus;
using MicroserviceWithRabbitMQ.Transfer.Domain.Events;
using MicroserviceWithRabbitMQ.Transfer.Domain.Interfaces;
using MicroserviceWithRabbitMQ.Transfer.Domain.Models;

namespace MicroserviceWithRabbitMQ.Transfer.Domain.EventHandlers
{
    public class TransferEventHandler : IEventHandler<TransferCreatedEvent>
    {
        private readonly ITransferRepository _transferRepository;

        public TransferEventHandler(ITransferRepository transferRepository)
        {
            _transferRepository = transferRepository;
        }

        public Task Handle(TransferCreatedEvent @event)
        {
            _transferRepository.Add(new TransferLog()
            {
                FromAccount = @event.From,
                ToAccount = @event.To,
                TransferAmount = @event.Amount
            });

            return Task.CompletedTask;
        }
    }
}
