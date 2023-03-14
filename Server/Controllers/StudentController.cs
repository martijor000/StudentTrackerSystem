using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentTrackerSystem.Server.Data;
using StudentTrackerSystem.Server.Models;

namespace StudentTrackerSystem.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : AccountController
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _dbContext;

        public StudentController(UserManager<IdentityUser> userManager, ApplicationDbContext dbContext) : base(userManager, dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext; 
        }
    }

}
