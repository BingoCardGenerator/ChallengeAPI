using ChallengeApi.DbContext;
using ChallengeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ChallengeApi.Services
{
    public class ChallengeService
    {
        private readonly ChallengeContext _context;

        public ChallengeService(ChallengeContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<ChallengeModel>> GetAllChallenges()
        {
            return await _context.Challenges.ToListAsync();
        }

        public async Task CreateChallenge(ChallengeModel newchallenge)
        {
            await _context.Challenges.AddAsync(newchallenge);
            await _context.SaveChangesAsync();
        }
    }
}
