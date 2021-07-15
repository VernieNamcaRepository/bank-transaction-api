using System.Threading.Tasks;
using BankTransaction.ApplicationCore.DTOs;
using BankTransaction.ApplicationCore.Entities.Structure;

namespace BankTransaction.ApplicationCore.Interfaces
{
    public interface ITransactionService
    {
        Task<Transaction> Withdraw(TransactionDTO transactionDTO);
        Task<Transaction> Deposit(TransactionDTO transactionDTO);
        Task<Account> GetBalance(string accountNumber);
    }
}
