using AuthServerForJWT_Edu.Core.DTOs;
using SharedLibrary.Dtos;

namespace AuthServerForJWT_Edu.Core.Services;

public interface IAuthenticationService
{
    Task<Response<TokenDto>> CreateTokenAsync(LoginDto loginDto);

    Task<Response<TokenDto>> CreateTokenByRefreshToken(string refreshToken);

    Task<Response<NoDataDto>> RevokeRefreshToken(string refreshToken);

    Response<ClientTokenDto> CreateTokenByClient(ClientLoginDto clientLoginDto);
}
