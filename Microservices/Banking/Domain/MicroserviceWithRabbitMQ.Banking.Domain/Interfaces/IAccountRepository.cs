using System.Collections.Generic;
using MicroserviceWithRabbitMQ.Banking.Domain.Models;

namespace MicroserviceWithRabbitMQ.Banking.Domain.Interfaces
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAccounts();
    }
}