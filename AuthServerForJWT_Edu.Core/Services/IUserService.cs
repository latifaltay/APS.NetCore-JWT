using AuthServerForJWT_Edu.Core.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using SharedLibrary.Dtos;

namespace AuthServerForJWT_Edu.Core.Services;

public interface IUserService
{
    Task<Response<UserAppDto>> CreateUserAsync(CreateUserDto createUserDto);

    Task<Response<UserAppDto>> GetUserByNameAsync(string userName);

    Task<Response<NoContent>> CreateUserRoles(string userName);
}