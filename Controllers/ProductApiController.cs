using Ecommerce.Interface.Services;
using Ecommerce.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductApiController(IProductService productService) : ControllerBase
{
    private readonly IProductService _productService = productService;

    [HttpGet("GetAllProduct")]
    public async Task<IActionResult> GetAllProductAsync(int page , int pageSize)
    {
        var product = await _productService.GetPaginatedProduct(page,pageSize);

		return Ok(new
		{
			Products = product.Data,
			TotalPages = product.TotalPage,
			CurrentPage = page,
            totalCount = product.TotalCount,
        });
    }
}