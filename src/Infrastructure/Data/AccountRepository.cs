using System.Linq;
using System.Threading.Tasks;
using BankTransaction.ApplicationCore.Entities.Structure;
using BankTransaction.ApplicationCore.Interfaces;

namespace BankTransaction.Infrastructure.Data
{
    public class AccountRepository : EFRepository<Account, int>, IAccountRepository
    {
        public AccountRepository(BankTransactionContext context) : base(context)
        {
        }

        public async Task<Account> Add(Account account)
        {
            return await AddAsync(account);
        }

        public async Task<Account> Update(Account account)
        {
            return await UpdateAsync(account);
        }

        public IQueryable<Account> Get()
        {
            return _dbContext.Accounts;
        }

        public async Task<Account> GetById(string accountNumber)
        {
            return await _dbContext.Accounts.FindAsync(accountNumber);
        }
    }
}
