using System.Collections.Generic;
using MicroserviceWithRabbitMQ.Banking.Data.Contexts;
using MicroserviceWithRabbitMQ.Banking.Domain.Interfaces;
using MicroserviceWithRabbitMQ.Banking.Domain.Models;

namespace MicroserviceWithRabbitMQ.Banking.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BankingDbContext _bankingDbContext;
        public AccountRepository(BankingDbContext bankingDbContext)
        {
            _bankingDbContext = bankingDbContext ?? throw new System.ArgumentNullException(nameof(bankingDbContext));
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _bankingDbContext.Accounts;
        }
    }
}