using System;
using BankTransaction.ApplicationCore.Entities.Structure;
using BankTransaction.ApplicationCore.Interfaces;
using BankTransaction.ApplicationCore.Services;
using BankTransaction.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApplicationCoreTests.Services
{
    [TestClass]
    public class AccountServiceTests
    {
        private IAccountRepository _repository;
        private IAccountService _service;
        private BankTransactionContext _context;

        private DbContextOptionsBuilder<BankTransactionContext> _builder;

        [TestInitialize]
        public void Initialize()
        {
            _builder = new DbContextOptionsBuilder<BankTransactionContext>();
            _builder.UseInMemoryDatabase("TestDB" + Guid.NewGuid().ToString());

            _context = new BankTransactionContext(_builder.Options);
            _repository = new AccountRepository(_context);
            _service = new AccountService(_repository);
        }

        [TestMethod]
        public void CreateServices()
        {
            Assert.IsNotNull(_service);
            Assert.IsInstanceOfType(_service, typeof(IAccountService));
        }

        [TestMethod]
        public void Get()
        {
            var account = CreateAccount();

            var result = _repository.Add(account).Result;

            Assert.IsNotNull(result);
        }

        private Account CreateAccount()
        {
            var entity = new Account()
            {
                AccountNumber = "000-1-2345-6789-0",
                AccountName = "Anne Santos",
                CurrentBalance = 5000,
                DateCreated = DateTime.Parse("07/14/2021 9:19 PM")
            };

            return entity;
        }
    }
}
