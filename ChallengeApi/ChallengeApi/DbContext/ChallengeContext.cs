namespace ChallengeApi.DbContext
{
    using Microsoft.EntityFrameworkCore;
    using ChallengeApi.Models;

    public class ChallengeContext : DbContext
    {
        public ChallengeContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ChallengeModel> Challenges { get; set; }

    }
}
