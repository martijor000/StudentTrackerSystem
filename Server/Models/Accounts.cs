using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentTrackerSystem.Server.Models
{
    public class Accounts : IdentityUser
    {
        public bool Deactivate { get; set; }
    }
}
