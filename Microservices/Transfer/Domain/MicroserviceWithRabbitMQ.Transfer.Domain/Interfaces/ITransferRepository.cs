using MicroserviceWithRabbitMQ.Transfer.Domain.Models;
using System.Collections.Generic;

namespace MicroserviceWithRabbitMQ.Transfer.Domain.Interfaces
{
    public interface ITransferRepository
    {
        IEnumerable<TransferLog> GetTransferLogs();
        void Add(TransferLog transferLog);
    }
}
