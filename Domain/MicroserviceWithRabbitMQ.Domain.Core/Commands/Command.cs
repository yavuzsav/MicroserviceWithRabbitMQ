using System;
using MicroserviceWithRabbitMQ.Domain.Core.Events;

namespace MicroserviceWithRabbitMQ.Domain.Core.Commands
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; protected set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }
    }
}