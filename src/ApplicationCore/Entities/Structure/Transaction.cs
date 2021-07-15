using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BankTransaction.ApplicationCore.Entities.Structure
{
    public class Transaction : BaseEntity<int>
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string AccountNumber { get; set; }

        [DataMember]
        public int TransactionType { get; set; }

        [DataMember]
        public decimal PreviousBalance { get; set; }

        [DataMember]
        public decimal Amount { get; set; }

        [DataMember]
        public DateTime TransactionDate { get; set; }
    }
}
