using MicroserviceWithRabbitMQ.Domain.Core.Bus;
using MicroserviceWithRabbitMQ.Transfer.Application.Interfaces;
using MicroserviceWithRabbitMQ.Transfer.Domain.Interfaces;
using MicroserviceWithRabbitMQ.Transfer.Domain.Models;
using System;
using System.Collections.Generic;

namespace MicroserviceWithRabbitMQ.Transfer.Application.Services
{
    public class TransferService : ITransferService
    {
        private readonly ITransferRepository _transferRepository;
        private readonly IEventBus _eventBus;

        public TransferService(ITransferRepository transferRepository, IEventBus eventBus)
        {
            _transferRepository = transferRepository ?? throw new ArgumentNullException(nameof(transferRepository));
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
        }

        public IEnumerable<TransferLog> GetTransferLogs()
        {
            return _transferRepository.GetTransferLogs();
        }
    }
}