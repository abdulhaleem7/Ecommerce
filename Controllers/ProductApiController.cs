using Ecommerce.Interface.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers;

public class ProductApiController(IProductService productService) : ControllerBase
{
    private readonly IProductService _productService = productService;

    [HttpGet("GetProduct")]
    public async Task<IActionResult> GetProduct()
    {
        var product = await _productService.GetAllProduct();
        return Ok(product);
    }
}