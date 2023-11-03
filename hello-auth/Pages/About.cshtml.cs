using hello_auth.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace hello_auth.Pages;

[Authorize]
public class AboutModel : PageModel
{
    private readonly ILogger<AboutModel> _logger;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public AboutModel(
        ILogger<AboutModel> logger,
        UserManager<IdentityUser> umgr,
        RoleManager<IdentityRole> rmgr,
        SignInManager<IdentityUser> simgr)
    {
        _logger = logger;
        _userManager = umgr;
        _roleManager = rmgr;
        _signInManager = simgr;
    }

    public async Task OnGetAsync()
    {
        
        var roleExists = await _roleManager.RoleExistsAsync("Admin");
        if (!roleExists) {
            await _roleManager.CreateAsync(new IdentityRole("Admin"));
        }

        ViewData["IsAdmin"] = User.IsInRole("Admin");
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var uid = _userManager.GetUserId(this.User);
        var iUser = await _userManager.FindByIdAsync(uid);

        var role = Request.Form["role"];
        if (role == "admin")
        {
            await _userManager.AddToRoleAsync(iUser, "Admin");
        }
        else
        {
            await _userManager.RemoveFromRoleAsync(iUser, "Admin");
        }
        await _signInManager.SignInAsync(iUser, false);
        return RedirectToPage('.');
    }
}
