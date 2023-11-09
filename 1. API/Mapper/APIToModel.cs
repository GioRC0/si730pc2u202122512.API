using _1._API.Request;
using _3._Data.model;
using AutoMapper;

namespace _1._API.Mapper;

public class APIToModel: Profile
{
    public APIToModel()
    {
        CreateMap<FinancialTransactionRequest, FinancialTransaction>();
    }
}