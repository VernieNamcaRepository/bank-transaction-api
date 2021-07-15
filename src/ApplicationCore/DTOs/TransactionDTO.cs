using System;
using System.Collections.Generic;
using System.Text;

namespace BankTransaction.ApplicationCore.DTOs
{
    public class TransactionDTO
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public int TransactionType { get; set; }
        public decimal PreviousBalance { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
