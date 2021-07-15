using System.Linq;
using System.Threading.Tasks;
using BankTransaction.ApplicationCore.Entities.Structure;

namespace BankTransaction.ApplicationCore.Interfaces
{
    public interface IAccountRepository
    {
        Task<Account> Add(Account page);
        Task<Account> Update(Account page);
        IQueryable<Account> Get();
        Task<Account> GetById(string accountNumber);
    }
}
