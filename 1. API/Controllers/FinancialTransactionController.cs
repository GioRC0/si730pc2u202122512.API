using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _1._API.Request;
using _1._API.Response;
using _2._Domain.finance.interfaces;
using _3._Data.model;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _1._API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancialTransactionController : ControllerBase
    {
        private IFinancialTransactionDomain _financialTransactionDomain;
        private IMapper _mapper;

        public FinancialTransactionController(IFinancialTransactionDomain financialTransaction, IMapper mapper)
        {
            _financialTransactionDomain = financialTransaction;
            _mapper = mapper;
        }
        /// <summary>
        /// Method to create a financial transaction
        /// </summary>
        /// <param name="request">Data of transaction</param>
        /// <returns>Transaction response</returns>
        /// <remarks>
        /// Author: [Giovanni Ramos Calderon]
        /// </remarks>
        // POST: api/v1/financial-transactions
        [HttpPost]
        public IActionResult Post([FromBody] FinancialTransactionRequest request)
        {
            if (ModelState.IsValid)
            {
                var financialTransaction = _mapper.Map<FinancialTransactionRequest, FinancialTransaction>(request);
                var financialTransactionData = _financialTransactionDomain.Create(financialTransaction);
                var response = _mapper.Map<FinancialTransaction, FinancialTransactionResponse>(financialTransactionData);
                return Created("", response);
            }
            return BadRequest();
        }
    }
}
