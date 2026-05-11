using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

public class AuthController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public AuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    // LOGIN GET
    public IActionResult Login() => View();

    // LOGIN POST
    [HttpPost]
    public async Task<IActionResult> Login(string email, string password)
    {
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            ViewBag.Error = "Email and password are required.";
            return View();
        }

        var user = await _userManager.FindByEmailAsync(email);

        if (user == null)
        {
            ViewBag.Error = "User not found.";
            return View();
        }

        var result = await _signInManager.PasswordSignInAsync(user.UserName, password, true, false);

        if (result.Succeeded)
            return RedirectToAction("Index", "Home");

        ViewBag.Error = "Invalid login attempt.";
        return View();
    }

    // REGISTER GET
    public IActionResult Register() => View();

    // REGISTER POST
    [HttpPost]
    public async Task<IActionResult> Register(string email, string password)
    {
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            ViewBag.Error = "Email and password are required.";
            return View();
        }

        var user = new IdentityUser
        {
            UserName = email,
            Email = email
        };

        var result = await _userManager.CreateAsync(user, password);

        if (result.Succeeded)
        {
            await _signInManager.SignInAsync(user, true);
            return RedirectToAction("Index", "Home");
        }

        ViewBag.Error = string.Join(", ", result.Errors.Select(e => e.Description));
        return View();
    }

    // LOGOUT
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Login");
    }
}
