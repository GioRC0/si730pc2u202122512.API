using _3._Data.context;

namespace _3._Data.model;

public class FinancialTransactionMySqlData: IFinancialTransactionData
{
    private FinTechDB _finTechDb;

    public FinancialTransactionMySqlData(FinTechDB finTechDb)
    {
        _finTechDb = finTechDb;
    }
    /// <summary>
    /// Method to store financial transaction in data base
    /// </summary>
    /// <param name="financialTransaction"></param>
    /// <returns>Id of the financial transaction</returns>
    /// <remarks>Author: [Giovanni Ramos Calderon]</remarks>
    public int Create(FinancialTransaction financialTransaction)
    {
        try
        {
            _finTechDb.FinancialTransactions.Add(financialTransaction);
            _finTechDb.SaveChanges();
            return financialTransaction.Id;
        }
        catch (Exception error)
        {
            return 0;
        }
    }

    /// <summary>
    /// Method to get financial transactions made today on specific username and receiver id 
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="receiverId"></param>
    /// <returns>A list of financial transactions</returns>
    /// <remarks>Author: [Giovanni Ramos Calderon]</remarks>
    public List<FinancialTransaction> GetFinancialTransactionsByUsernameAndReceiverId(string userName, int receiverId)
    {
        return _finTechDb.FinancialTransactions.Where(f => 
            f.UserName == userName && f.ReceiverId == receiverId && f.DateCreated.Date == DateTime.Now.Date).ToList();
    }

    public FinancialTransaction GetFinancialTransactionById(int id)
    {
        return _finTechDb.FinancialTransactions.Where(f => f.Id == id).FirstOrDefault();
    }
}