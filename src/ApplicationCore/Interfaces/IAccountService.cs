using System.Linq;
using System.Threading.Tasks;
using BankTransaction.ApplicationCore.Entities.Structure;

namespace BankTransaction.ApplicationCore.Interfaces
{
    public interface IAccountService
    {
        IQueryable<Account> Get();
        Task<Account> GetById(string accountNumber);
    }
}
