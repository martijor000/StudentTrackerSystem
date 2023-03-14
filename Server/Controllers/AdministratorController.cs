using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using StudentTrackerSystem.Server.Models;
using StudentTrackerSystem.Server.Data;

namespace StudentTrackerSystem.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdministratorsController : AccountController
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _dbContext;

        public AdministratorsController(UserManager<IdentityUser> userManager, ApplicationDbContext dbContext) : base(userManager, dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent(Account model)
        {
            var result = await _userManager.CreateAsync(model);
            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }
    }
}
