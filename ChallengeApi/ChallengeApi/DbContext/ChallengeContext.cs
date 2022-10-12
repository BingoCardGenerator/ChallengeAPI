namespace ChallengeApi.DbContext
{
    using Microsoft.EntityFrameworkCore;
    using ChallengeApi.Models;

    /// <summary>
    /// The context for the Challenge database. 
    /// </summary>
    public class ChallengeContext : DbContext
    {
        public ChallengeContext(DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        /// The table in wich all challegnes are stored.
        /// </summary>
        public DbSet<ChallengeModel> Challenges { get; set; } = null!;

    }
}
