using System.Collections.Generic;
using MicroserviceWithRabbitMQ.Banking.Domain.Models;

namespace MicroserviceWithRabbitMQ.Banking.Application.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAccounts();
    }
}