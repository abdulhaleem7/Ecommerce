using Ecommerce.DTOs;
using Ecommerce.Interface.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers;
[Authorize(Roles = "SuperAdmin,Manager")]
public  class UserController(IUserService userService) : Controller
{
    private readonly IUserService _userService = userService;
    // GET
    public  async Task<IActionResult> Index()
    {
       var users = await _userService.GetAllUser();
       return View(users);
    }
    [HttpPost("User/Create")]
    public async Task<IActionResult> Create(UserRequestModel requestModel)
    {
        var createUser = await _userService.CreateUser(requestModel);
        return RedirectToAction("Index");

    }
    
    [HttpGet]
    public  async Task<IActionResult> CreateUser()
    {
        return View();
    }
    [HttpPost("User/Update/{userName}")]
    public async Task<IActionResult> Update(UserUpdateModel updateModel, [FromRoute]string userName)
    {
        var updateUser = await _userService.UpdateUser(updateModel, userName);
        return RedirectToAction("Index");
    }
    [HttpGet("User/UpdateUser/{userName}")]
    public async Task<IActionResult> UpdateUser([FromRoute]string userName)
    {
        var getUser = await _userService.GetUser(userName);
        return View(getUser.Data);
    }
}
