using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StudentTrackerSystem.Server.Models;

namespace StudentTrackerSystem.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<Accounts>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Accounts> Students { get; set; }
        
    }
}