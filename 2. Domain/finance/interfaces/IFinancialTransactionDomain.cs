using _3._Data.model;

namespace _2._Domain.finance.interfaces;

public interface IFinancialTransactionDomain
{
    public FinancialTransaction Create(FinancialTransaction financialTransaction);
}