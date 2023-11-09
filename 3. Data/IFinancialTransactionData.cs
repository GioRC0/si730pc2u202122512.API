using _3._Data.model;

namespace _3._Data;

public interface IFinancialTransactionData
{
    int Create(FinancialTransaction financialTransaction);

    List<FinancialTransaction> GetFinancialTransactionsByUsernameAndReceiverId(String userName, int receiverId);
    FinancialTransaction GetFinancialTransactionById(int id);
}