using System.Security.Claims;
using Ecommerce.DTOs;
using Ecommerce.Interface.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;


namespace Ecommerce.Controllers;

public class AuthController(IAuthService authenticationService ) : Controller
{
    private readonly IAuthService _authenticationService = authenticationService;
    // GET
    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> LoginUser(LoginRequestModel requestModel)
    {
        var login = await _authenticationService.Login(requestModel);
        if (login.Status.Equals(false))
        {
            return RedirectToAction("Login");
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, login.Data.UserId.ToString()),
            new Claim(ClaimTypes.Name, $"{login.Data.FirstName}{login.Data.LastName}"),
            new Claim(ClaimTypes.Email, login.Data.Email),
            new Claim(ClaimTypes.Role, login.Data.Role.ToString()),
            new Claim("UserName", login.Data.UserName),

        };
        var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var authenticationProperty = new AuthenticationProperties();
        var principal = new ClaimsPrincipal(claimIdentity);
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authenticationProperty);
        if(login.Data.Role != Models.Enums.Role.Customer)
        {
			return RedirectToAction("AdminDashboard");
		}
        return RedirectToAction("Index","User");
        
    }

	public IActionResult AdminDashboard()
	{
		return View();
	}
}