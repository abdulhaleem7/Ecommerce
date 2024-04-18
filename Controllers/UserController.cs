using Ecommerce.Interface.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers;

public  class UserController(IUserService userService) : Controller
{
    private readonly IUserService _userService = userService;
    // GET
    public  async Task<IActionResult> Index()
    {
       var users = await _userService.GetAllUser();
        return View(users.Data);
    }
}