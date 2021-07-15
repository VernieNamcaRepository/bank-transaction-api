using System.Linq;
using System.Threading.Tasks;
using BankTransaction.ApplicationCore.Entities.Structure;
using BankTransaction.ApplicationCore.Interfaces;

namespace BankTransaction.ApplicationCore.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repository;

        public AccountService(IAccountRepository repository)
        {
            _repository = repository;
        }

        public IQueryable<Account> Get()
        {
            return _repository.Get();
        }

        public async Task<Account> GetById(string accountNumber)
        {
            return await _repository.GetById(accountNumber);
        }
    }
}
