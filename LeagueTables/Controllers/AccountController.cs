using LeagueTables.Data.Entities;
using LeagueTables.Models.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LeagueTables.Controllers;

public class AccountController(SignInManager<UserEntity> signInManager) : Controller
{
    public const string RegisterErrorName = "RegisterError";
    public const string LoginErrorName = "LoginError";

    private readonly SignInManager<UserEntity> _signInManager = signInManager;
    private readonly UserManager<UserEntity> _userManager = signInManager.UserManager;

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Register([FromQuery] string? returnUrl)
    {
        ViewBag.ReturnUrl = returnUrl;
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [AllowAnonymous]
    public async Task<IActionResult> Register(RegisterModel model, [FromQuery] string? returnUrl)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        var newUser = new UserEntity()
        {
            UserName = model.Email,
            Email = model.Email
        };

        var result = await _userManager.CreateAsync(newUser, model.Password);

        if (!result.Succeeded)
        {
            ModelState.AddModelError(RegisterErrorName,
                string.Join(", ",
                result.Errors
                    .Where(x => x.Code != "DuplicateUserName")
                    .Select(x => x.Description)));

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        result = await _userManager.AddToRoleAsync(newUser, IdentityRolesNames.User);

        if (!result.Succeeded)
        {
            await _userManager.DeleteAsync(newUser);

            ModelState.AddModelError(RegisterErrorName, "An unknown failure has occured.");

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        await _signInManager.SignInAsync(newUser, false);

        return RedirectToLocal(returnUrl);
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Login([FromQuery] string? returnUrl)
    {
        ViewBag.ReturnUrl = returnUrl;
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginModel model, [FromQuery] string? returnUrl)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

        if (!result.Succeeded)
        {
            ModelState.AddModelError(LoginErrorName, "Invalid email or password.");

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        return RedirectToLocal(returnUrl);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize]
    public async Task<IActionResult> Logout([FromQuery] string? returnUrl)
    {
        await _signInManager.SignOutAsync();

        return RedirectToLocal(returnUrl);
    }

    private IActionResult RedirectToLocal(string? returnUrl)
    {
        if (Url.IsLocalUrl(returnUrl))
        {
            return Redirect(returnUrl);
        }
        else
        {
            return NotFound();
        }
    }
}
