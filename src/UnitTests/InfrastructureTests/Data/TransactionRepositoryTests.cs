using BankTransaction.ApplicationCore.Entities.Structure;
using BankTransaction.ApplicationCore.Enumeration;
using BankTransaction.ApplicationCore.Interfaces;
using BankTransaction.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace InfrastructureTests.Data
{
    [TestClass]
    public class TransactionRepositoryTests
    {
        private ITransactionRepository _repository;
        private BankTransactionContext _context;
        private DbContextOptionsBuilder<BankTransactionContext> _builder;

        [TestInitialize]
        public void Initialize()
        {
            _builder = new DbContextOptionsBuilder<BankTransactionContext>();
            _builder.UseInMemoryDatabase("TestDB" + Guid.NewGuid().ToString());

            _context = new BankTransactionContext(_builder.Options);
            _repository = new TransactionRepository(_context);
        }

        [TestMethod]
        public void CreateRepository()
        {
            Assert.IsNotNull(_repository);
            Assert.IsInstanceOfType(_repository, typeof(ITransactionRepository));
        }

        [TestMethod]
        public void Get()
        {
            var transaction = CreateTransaction();

            var result = _repository.Add(transaction).Result;

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
