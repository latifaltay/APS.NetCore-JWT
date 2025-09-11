﻿using AuthServerForJWT_Edu.Core.DTOs;
using AuthServerForJWT_Edu.Core.Models;
using AuthServerForJWT_Edu.Core.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using SharedLibrary.Dtos;

namespace AuthServerForJWT_Edu.Service.Services;

public class UserService : IUserService
{
    private readonly UserManager<UserApp> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public UserService(UserManager<UserApp> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<Response<UserAppDto>> CreateUserAsync(CreateUserDto createUserDto)
    {
        var user = new UserApp { Email = createUserDto.Email, UserName = createUserDto.UserName };

        var result = await _userManager.CreateAsync(user, createUserDto.Password);

        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(x => x.Description).ToList();

            return Response<UserAppDto>.Fail(new ErrorDto(errors, true), 400);
        }
        return Response<UserAppDto>.Success(ObjectMapper.Mapper.Map<UserAppDto>(user), 200);
    }

    public async Task<Response<NoContent>> CreateUserRoles(string userName)
    {
        if (!await _roleManager.RoleExistsAsync("admin"))
        {
            await _roleManager.CreateAsync(new() { Name = "admin" });
            await _roleManager.CreateAsync(new() { Name = "manager" });
        }

        var user = await _userManager.FindByNameAsync(userName);

        await _userManager.AddToRoleAsync(user, "admin");
        await _userManager.AddToRoleAsync(user, "manager");

        return Response<NoContent>.Success(statusCode:201);
    }

    public async Task<Response<UserAppDto>> GetUserByNameAsync(string userName)
    {
        var user = await _userManager.FindByNameAsync(userName);

        if (user == null)
        {
            return Response<UserAppDto>.Fail("UserName not found", 404, true);
        }

        return Response<UserAppDto>.Success(ObjectMapper.Mapper.Map<UserAppDto>(user), 200);
    }
}