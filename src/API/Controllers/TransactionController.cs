using System;
using System.Threading.Tasks;
using BankTransaction.API.Models;
using BankTransaction.ApplicationCore.Entities.Structure;
using BankTransaction.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankTransaction.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _service;
        
        public TransactionController(ITransactionService service)
        {
            _service = service;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Withdraw([FromBody] TransactionModel transactionModel)
        {
            try
            {
                var transaction = await _service.Withdraw(transactionModel.Transaction);

                return Ok(new { transaction });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Deposit([FromBody] TransactionModel transactionModel)
        {
            try
            {
                var transaction = await _service.Deposit(transactionModel.Transaction);

                return Ok(new { transaction });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<Account>> GetBalance([FromQuery] string accountNumber)
        {
            try
            {
                var account = await _service.GetBalance(accountNumber);

                return Ok(new { account });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}