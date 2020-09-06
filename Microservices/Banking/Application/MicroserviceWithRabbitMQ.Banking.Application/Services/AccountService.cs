using System.Collections.Generic;
using MicroserviceWithRabbitMQ.Banking.Application.Interfaces;
using MicroserviceWithRabbitMQ.Banking.Domain.Interfaces;
using MicroserviceWithRabbitMQ.Banking.Domain.Models;

namespace MicroserviceWithRabbitMQ.Banking.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository ?? throw new System.ArgumentNullException(nameof(accountRepository));
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _accountRepository.GetAccounts();
        }
    }
}