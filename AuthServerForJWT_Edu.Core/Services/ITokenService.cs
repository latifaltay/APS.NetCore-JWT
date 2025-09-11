using AuthServerForJWT_Edu.Core.Configuration;
using AuthServerForJWT_Edu.Core.DTOs;
using AuthServerForJWT_Edu.Core.Models;

namespace AuthServerForJWT_Edu.Core.Services;

public interface ITokenService
{
    Task<TokenDto> CreateToken(UserApp userApp);
    ClientTokenDto CreateTokenByClient(Client client);
}