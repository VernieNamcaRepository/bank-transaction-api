using System;
using System.Threading.Tasks;
using BankTransaction.ApplicationCore.DTOs;
using BankTransaction.ApplicationCore.Entities.Structure;
using BankTransaction.ApplicationCore.Enumeration;
using BankTransaction.ApplicationCore.Interfaces;

namespace BankTransaction.ApplicationCore.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IAccountRepository _accountRepository;

        public TransactionService(ITransactionRepository transactionRepository, IAccountRepository accountRepository)
        {
            _transactionRepository = transactionRepository;
            _accountRepository = accountRepository;
        }

        public async Task<Transaction> Withdraw(TransactionDTO transactionDTO)
        {
            var account = await _accountRepository.GetById(transactionDTO.AccountNumber);

            var transaction = new Transaction
            {
                AccountNumber = transactionDTO.AccountNumber,
                TransactionType = (int)TransactionTypeEnum.Withdrawal,
                PreviousBalance = account.CurrentBalance,
                Amount = transactionDTO.Amount,
                TransactionDate = DateTime.Now
            };

            try
            {
                account.CurrentBalance -= transaction.Amount;

                await _accountRepository.Update(account);

                return await _transactionRepository.Add(transaction);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Transaction> Deposit(TransactionDTO transactionDTO)
        {
            var account = await _accountRepository.GetById(transactionDTO.AccountNumber);

            var transaction = new Transaction
            {
                AccountNumber = transactionDTO.AccountNumber,
                TransactionType = (int)TransactionTypeEnum.Deposit,
                PreviousBalance = account.CurrentBalance,
                Amount = transactionDTO.Amount,
                TransactionDate = DateTime.Now
            };

            try
            {
                account.CurrentBalance += transaction.Amount;

                await _accountRepository.Update(account);

                return await _transactionRepository.Add(transaction);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Account> GetBalance(string accountNumber)
        {
            return await _accountRepository.GetById(accountNumber);
        }
    }
}
