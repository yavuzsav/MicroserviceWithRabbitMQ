using System.Threading.Tasks;
using MicroserviceWithRabbitMQ.Domain.Core.Commands;
using MicroserviceWithRabbitMQ.Domain.Core.Events;

namespace MicroserviceWithRabbitMQ.Domain.Core.Bus
{
    public interface IEventBus
    {
        Task SendCommand<T>(T command) where T : Command;
        void Publish<T>(T @event) where T : Event;
        void Subscribe<T, TH>() where T : Event where TH : IEventHandler<T>;
    }
}