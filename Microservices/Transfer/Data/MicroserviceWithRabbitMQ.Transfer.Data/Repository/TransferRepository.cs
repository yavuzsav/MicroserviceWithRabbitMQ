using MicroserviceWithRabbitMQ.Transfer.Data.Contexts;
using MicroserviceWithRabbitMQ.Transfer.Domain.Interfaces;
using MicroserviceWithRabbitMQ.Transfer.Domain.Models;
using System;
using System.Collections.Generic;

namespace MicroserviceWithRabbitMQ.Transfer.Data.Repository
{
    public class TransferRepository : ITransferRepository
    {
        private readonly TransferDbContext _transferDbContext;

        public TransferRepository(TransferDbContext transferDbContext)
        {
            _transferDbContext = transferDbContext ?? throw new ArgumentNullException(nameof(transferDbContext));
        }

        public IEnumerable<TransferLog> GetTransferLogs()
        {
            return _transferDbContext.TransferLogs;
        }

        public void Add(TransferLog transferLog)
        {
            _transferDbContext.TransferLogs.Add(transferLog);
            _transferDbContext.SaveChanges();
        }
    }
}
