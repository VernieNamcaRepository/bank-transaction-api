using System;

namespace BankTransaction.ApplicationCore.DTOs
{
    public class AccountDTO
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string CurrentBalance { get; set; }
        public string DateCreated { get; set; }
    }
}
