using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SHMS.Models;
using System.Security.Claims;
using System.Text;
using SHMS.Data;
using System.Security.Cryptography;

namespace SHMS.Controllers;

public class AccountController : Controller
{
    private readonly DataContext _context;

    public AccountController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View( );
    }

    [HttpPost]
    public IActionResult Register(string name, string email, string password, UserRole role)
    {
        if (_context.Users.Any(u => u.Email == email))
        {
            ModelState.AddModelError("Email", "Email is already registered.");
            return View( );
        }

        var user = new User {
            Name = name,
            Email = email,
            PasswordHash = HashPassword(password),
            Role = role
        };

        _context.Users.Add(user);
        _context.SaveChanges( );

        return RedirectToAction("Login");
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View( );
    }

    public async Task<IActionResult> Login(string email, string password)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == email);
        if (user == null || user.PasswordHash != HashPassword(password))
        {
            ModelState.AddModelError("LoginFailed", "Invalid email or password.");
            return View( );
        }

        var claims = new List<Claim>
        {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.Name, user.Name),
        new Claim(ClaimTypes.Email, user.Email),
        new Claim(ClaimTypes.Role, user.Role.ToString())
    };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

        // Redirect based on user role
        if (user.Role == UserRole.Doctor)
        {
            return RedirectToAction("Upload", "TestResults");
        }
        else if (user.Role == UserRole.Patient)
        {
            return RedirectToAction("Patient", "TestResults");
        }

        // Default redirect if role is not recognized
        return RedirectToAction("Index", "Home");
    }



    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Login");
    }

    private string HashPassword(string password)
    {
        using var sha256 = SHA256.Create( );
        var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(bytes);
    }
}
