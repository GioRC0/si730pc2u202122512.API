using System.ComponentModel.DataAnnotations;

namespace _1._API.Request;

public class FinancialTransactionRequest
{
    [Required]
    public String UserName { get; set; }
    [Required]
    public int ReceiverId { get; set; }
    [Required]
    [Range(1,500, ErrorMessage = "Amount value is between 1 and 500")]
    public int Amount { get; set; }
    public String? Comments { get; set; }
}