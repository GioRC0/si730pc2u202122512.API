using _1._API.Response;
using _3._Data.model;
using AutoMapper;

namespace _1._API.Mapper;

public class ModelToAPI: Profile
{
    public ModelToAPI()
    {
        CreateMap<FinancialTransaction, FinancialTransactionResponse>();
    }
}