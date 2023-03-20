using Microsoft.AspNetCore.Identity;

namespace StudentTrackerSystem.Server.Models
{
    public class Alumni
    {
        public Accounts account { get; set; }
        public Degree degree { get; set; }
        public DateOnly graduationDate { get; set; }
    }
}
