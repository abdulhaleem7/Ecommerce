using Ecommerce.DTOs;
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
       return View(users);
    }
    [HttpPost("Create")]
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
    [HttpPost("Update")]
    public async Task<IActionResult> Update(UserUpdateModel updateModel, [FromRoute]string userName)
    {
        var updateUser = await _userService.UpdateUser(updateModel, userName);
        return RedirectToAction("Index");
    }
    [HttpGet("UpdateUser/{userName}")]
    public async Task<IActionResult> UpdateUser([FromRoute]string userName)
    {
        var getUser = await _userService.GetUser(userName);
        return View(getUser.Data);
    }
}
