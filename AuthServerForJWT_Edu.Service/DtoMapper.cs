using AuthServerForJWT_Edu.Core.DTOs;
using AuthServerForJWT_Edu.Core.Models;
using AutoMapper;

namespace AuthServerForJWT_Edu.Service;

internal class DtoMapper : Profile
{
    public DtoMapper()
    {
        CreateMap<ProductDto, Product>().ReverseMap();
        CreateMap<UserAppDto, UserApp>().ReverseMap();
    }
}