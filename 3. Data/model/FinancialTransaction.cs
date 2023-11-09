using _3._Data.shared;

namespace _3._Data.model;

public class FinancialTransaction: ModelBase
{
    public String UserName { get; set; }
    public int ReceiverId { get; set; }
    public int Amount { get; set; }
    public String? Comments { get; set; }
}