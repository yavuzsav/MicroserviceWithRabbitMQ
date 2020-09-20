using System;
using System.Collections.Generic;
using MicroserviceWithRabbitMQ.Banking.Application.Interfaces;
using MicroserviceWithRabbitMQ.Banking.Application.Models;
using MicroserviceWithRabbitMQ.Banking.Domain.Commands;
using MicroserviceWithRabbitMQ.Banking.Domain.Interfaces;
using MicroserviceWithRabbitMQ.Banking.Domain.Models;
using MicroserviceWithRabbitMQ.Domain.Core.Bus;

namespace MicroserviceWithRabbitMQ.Banking.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IEventBus _eventBus;

        public AccountService(IAccountRepository accountRepository, IEventBus eventBus)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _accountRepository.GetAccounts();
        }

        public void Transfer(AccountTransfer accountTransfer)
        {
            var createTransferCommand = new CreateTransferCommand(
                accountTransfer.FromAccount,
                accountTransfer.ToAccount,
                accountTransfer.TransferAmount
                );

            _eventBus.SendCommand(createTransferCommand);
        }
    }
}