using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankTransaction.ApplicationCore.DTOs;
using BankTransaction.ApplicationCore.Entities.Structure;

namespace BankTransaction.ApplicationCore.Interfaces
{
    public interface ITransactionRepository
    {
        Task<Transaction> Add(Transaction transaction);
        IQueryable<Transaction> Get();
    }
}
