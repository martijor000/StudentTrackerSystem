using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentTrackerSystem.Server.Models;


namespace StudentTrackerSystem.Server.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private IdentityUser IdentityUser;
        private NavigationManager navigationManager;

        public RegisterController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManage)
        {
            _userManager = userManager;
            _signInManager = signInManage;
        }

        [HttpGet]
        public IActionResult Register()
        {
            var model = new Accounts();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(Accounts model)
        {
            if (ModelState.IsValid)
            {
                var userManager = HttpContext.RequestServices.GetService<UserManager<Accounts>>();

                var user = await userManager.GetUserAsync(User);

                bool isInRole = await userManager.IsInRoleAsync(user, "administrator");


                if (isInRole)
                {
                    IdentityUser = new IdentityUser { UserName = model.UserName, Email = model.Email, };
                }
                else
                {

                }
                var result = await _userManager.CreateAsync(IdentityUser, model.PasswordHash);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(IdentityUser, isPersistent: false);
                    navigationManager.NavigateTo("/");

                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }
    }
}
