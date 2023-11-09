using System.Net;
using _2._Domain.finance.interfaces;
using _3._Data;

namespace _2._Domain.finance.model;

public class FinancialTransactionDomain: IFinancialTransactionDomain
{
    private IFinancialTransactionData _financialTransactionData;

    public FinancialTransactionDomain(IFinancialTransactionData financialTransactionData)
    {
        _financialTransactionData = financialTransactionData;
    }
    /// <summary>
    /// Method to create a financial transaction
    /// </summary>
    /// <param name="financialTransaction"></param>
    /// <returns>Financial Transaction</returns>
    /// <exception cref="NotImplementedException"></exception>
    /// <remarks>Author: [Giovanni Ramos Calderon]</remarks>
    public _3._Data.model.FinancialTransaction Create(_3._Data.model.FinancialTransaction financialTransaction)
    {
        var financialTransactionWithSameDate =
            _financialTransactionData.GetFinancialTransactionsByUsernameAndReceiverId(
                financialTransaction.UserName, financialTransaction.ReceiverId);
        if (financialTransactionWithSameDate.Count < 3)
        {
            var financialTransactionId = _financialTransactionData.Create(financialTransaction);
            return _financialTransactionData.GetFinancialTransactionById(financialTransactionId);
        }
        throw new InvalidOperationException("You have reach the limit of transactions for " +
                                            financialTransaction.UserName + " and " +
                                            financialTransaction.ReceiverId);
    }
}