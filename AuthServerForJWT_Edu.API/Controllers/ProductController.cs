using AuthServerForJWT_Edu.Core.DTOs;
using AuthServerForJWT_Edu.Core.Models;
using AuthServerForJWT_Edu.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthServerForJWT_Edu.API.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ProductController : CustomBaseController
{
    private readonly IServiceGeneric<Product, ProductDto> _productService;

    public ProductController(IServiceGeneric<Product, ProductDto> productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        return ActionResultInstance(await _productService.GetAllAsync());
    }

    [HttpPost]
    public async Task<IActionResult> SaveProduct(ProductDto productDto)
    {
        return ActionResultInstance(await _productService.AddAsync(productDto));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct(ProductDto productDto)
    {
        return ActionResultInstance(await _productService.Update(productDto, productDto.Id));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        return ActionResultInstance(await _productService.Remove(id));
    }
}
