using BankTransaction.ApplicationCore.Entities.Structure;
using BankTransaction.ApplicationCore.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace BankTransaction.Infrastructure.Data
{
    public class TransactionRepository : EFRepository<Transaction, int>, ITransactionRepository
    {
        public TransactionRepository(BankTransactionContext context) : base(context)
        {
        }

        public async Task<Transaction> Add(Transaction transaction)
        {
            return await AddAsync(transaction);
        }

        public IQueryable<Transaction> Get()
        {
            return _dbContext.Transactions;
        }
    }
}
