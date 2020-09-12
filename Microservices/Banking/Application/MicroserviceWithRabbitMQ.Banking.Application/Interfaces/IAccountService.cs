using System.Collections.Generic;
using MicroserviceWithRabbitMQ.Banking.Application.Models;
using MicroserviceWithRabbitMQ.Banking.Domain.Models;

namespace MicroserviceWithRabbitMQ.Banking.Application.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAccounts();
        void Transfer(AccountTransfer accountTransfer);
    }
}