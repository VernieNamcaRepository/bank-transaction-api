using BankTransaction.ApplicationCore.Entities.Structure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BankTransaction.ApplicationCoreTests.Entities
{
    [TestClass]
    public class AccountTests
    {
        [TestMethod]
        public void CreateEntity()
        {
            var entity = new Account()
            {
                AccountNumber = "000-1-2345-6789-0",
                AccountName = "Anne Santos",
                CurrentBalance = 5000,
                DateCreated = DateTime.Parse("07/14/2021 9:19 PM")
            };

            Assert.IsNotNull(entity);
            Assert.AreEqual("000-1-2345-6789-0", entity.AccountNumber);
            Assert.AreEqual("Anne Santos", entity.AccountName);
            Assert.AreEqual(DateTime.Parse("07/14/2021 9:19 PM"), entity.DateCreated);
        }
    }
}
