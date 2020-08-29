using System.Threading.Tasks;
using MicroserviceWithRabbitMQ.Domain.Core.Events;

namespace MicroserviceWithRabbitMQ.Domain.Core.Bus
{
    public interface IEventHandler<in TEvent> : IEventHandler where TEvent : Event
    {
        Task Handle(TEvent @event);
    }

    public interface IEventHandler
    {
    }
}