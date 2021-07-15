using System;
using BankTransaction.ApplicationCore.Entities.Structure;
using BankTransaction.ApplicationCore.Enumeration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankTransaction.ApplicationCoreTests.Entities
{
    [TestClass]
    public class TransactionTests
    {
        [TestMethod]
        public void CreateEntity()
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

            Assert.IsNotNull(entity);
            Assert.AreEqual(1, entity.Id);
            Assert.AreEqual("000-1-2345-6789-0", entity.AccountNumber);
            Assert.AreEqual((int)TransactionTypeEnum.CheckBalance, entity.TransactionType);
            Assert.AreEqual(5000, entity.PreviousBalance);
            Assert.AreEqual(1300, entity.Amount);
            Assert.AreEqual(DateTime.Parse("07/14/2021 10:20 PM"), entity.TransactionDate);
        }
    }
}
