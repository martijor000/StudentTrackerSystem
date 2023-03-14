using Microsoft.AspNetCore.Identity;

namespace StudentTrackerSystem.Server.Models
{
    public class Alumni
    {
        public Account account { get; set; }
        public string Degree { get; set; }
    }
}
