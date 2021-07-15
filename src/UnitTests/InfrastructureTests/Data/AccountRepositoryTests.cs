using BankTransaction.ApplicationCore.Entities.Structure;
using BankTransaction.ApplicationCore.Interfaces;
using BankTransaction.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace InfrastructureTests.Data
{
    [TestClass]
    public class AccountRepositoryTests
    {
        private IAccountRepository _repository;
        private BankTransactionContext _context;
        private DbContextOptionsBuilder<BankTransactionContext> _builder;

        [TestInitialize]
        public void Initialize()
        {
            _builder = new DbContextOptionsBuilder<BankTransactionContext>();
            _builder.UseInMemoryDatabase("TestDB" + Guid.NewGuid().ToString());

            _context = new BankTransactionContext(_builder.Options);
            _repository = new AccountRepository(_context);
        }

        [TestMethod]
        public void CreateRepository()
        {
            Assert.IsNotNull(_repository);
            Assert.IsInstanceOfType(_repository, typeof(IAccountRepository));
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
            var entity = new Account() {
                AccountNumber = "000-1-2345-6789-0",
                AccountName = "Anne Santos",
                CurrentBalance = 5000,
                DateCreated = DateTime.Parse("07/14/2021 9:19 PM")
            };

            return entity;
        }
    }
}
