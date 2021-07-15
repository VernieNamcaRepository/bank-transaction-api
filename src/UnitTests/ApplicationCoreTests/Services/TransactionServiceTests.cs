using System;
using BankTransaction.ApplicationCore.Entities.Structure;
using BankTransaction.ApplicationCore.Enumeration;
using BankTransaction.ApplicationCore.Interfaces;
using BankTransaction.ApplicationCore.Services;
using BankTransaction.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApplicationCoreTests.Services
{
    [TestClass]
    public class TransactionServiceTests
    {
        private ITransactionRepository _transactionRepository;
        private IAccountRepository _accountRepository;
        private ITransactionService _service;
        private BankTransactionContext _context;

        private DbContextOptionsBuilder<BankTransactionContext> _builder;

        [TestInitialize]
        public void Initialize()
        {
            _builder = new DbContextOptionsBuilder<BankTransactionContext>();
            _builder.UseInMemoryDatabase("TestDB" + Guid.NewGuid().ToString());

            _context = new BankTransactionContext(_builder.Options);
            _transactionRepository = new TransactionRepository(_context);
            _accountRepository = new AccountRepository(_context);
            _service = new TransactionService(_transactionRepository, _accountRepository);
        }

        [TestMethod]
        public void CreateRepository()
        {
            Assert.IsNotNull(_service);
            Assert.IsInstanceOfType(_service, typeof(ITransactionService));
        }

        [TestMethod]
        public void Get()
        {
            var report = CreateTransaction();

            var result = _transactionRepository.Add(report).Result;

            Assert.IsNotNull(result);
        }

        private Transaction CreateTransaction()
        {
            var entity = new Transaction()
            {
                Id = 1,
                AccountNumber = "000-1-2345-6789-0",
                TransactionType = (int)TransactionTypeEnum.CheckBalance,
                PreviousBalance = 5000,
                Amount = 1300,
                TransactionDate = DateTime.Parse("07/14/2021 10:20 PM")
            };

            return entity;
        }
    }
}
