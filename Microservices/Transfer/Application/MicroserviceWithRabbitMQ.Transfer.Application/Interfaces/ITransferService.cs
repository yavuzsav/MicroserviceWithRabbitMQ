using MicroserviceWithRabbitMQ.Transfer.Domain.Models;
using System.Collections.Generic;

namespace MicroserviceWithRabbitMQ.Transfer.Application.Interfaces
{
    public interface ITransferService
    {
        IEnumerable<TransferLog> GetTransferLogs();
    }
}