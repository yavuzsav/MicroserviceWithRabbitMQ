using MicroserviceWithRabbitMQ.Domain.Core.Events;

namespace MicroserviceWithRabbitMQ.Transfer.Domain.Events
{
    public class TransferCreatedEvent : Event
    {
        public int From { get; private set; }

        public int To { get; private set; }

        public decimal Amount { get; private set; }

        public TransferCreatedEvent(decimal amount, int to, int @from)
        {
            Amount = amount;
            To = to;
            From = @from;
        }
    }
}
