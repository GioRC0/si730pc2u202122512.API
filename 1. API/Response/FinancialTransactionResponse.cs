namespace _1._API.Response;

public class FinancialTransactionResponse
{
    public int Id { get; set; }
    public String UserName { get; set; }
    public int ReceiverId { get; set; }
    public int Amount { get; set; }
    public String? Comments { get; set; }
}