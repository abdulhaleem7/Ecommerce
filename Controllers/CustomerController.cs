using Ecommerce.Implementation.Services;
using Ecommerce.Interface.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers;

public class CustomerController(ICustomerService customerService) : Controller
{
    private readonly ICustomerService _customerService = customerService;
    // GET
    // public IActionResult Index()
    // {
    //     return View();
    // }

    
}