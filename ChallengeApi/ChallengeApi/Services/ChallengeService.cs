using ChallengeApi.DbContext;
using ChallengeApi.interfaces;
using ChallengeApi.Models;
using ChallengeApi;
using Microsoft.EntityFrameworkCore;

namespace ChallengeApi.Services
{
    /// <summary>
    /// A server that handels all the challenges releated request.
    /// </summary>
    public class ChallengeService : IChallengeService
    {
        private readonly ChallengeContext _context;

        public ChallengeService(ChallengeContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<IReadOnlyList<ChallengeModel>>> GetAllChallenges()
        {
            var challenges = (await _context.Challenges.ToListAsync());

            return new ServiceResponse<IReadOnlyList<ChallengeModel>>
            {
                Data = challenges,
                SuccesFull = challenges is not null,
                ServiceResultCode = challenges is not null ? ServiceResultCode.Ok : ServiceResultCode.NotFound,
                Message = challenges is not null ? "200: Messages found." : "404: No challenges found."
            };
        }

        public async Task<ServiceResponse> CreateChallenge(ChallengeForCreationModel newchallenge)
        {
            var message = "";

            if (newchallenge.Name == String.Empty)
                message += "Challenge name cannot be empty";

            // new rules can for name (or challenge) can be added here later.

            if (string.IsNullOrEmpty(message)) 
            { 
                ChallengeModel newChallenge = new ChallengeModel { Name = newchallenge.Name };
                await _context.Challenges.AddAsync(newChallenge);
                await _context.SaveChangesAsync();
            }

            return new ServiceResponse
            {
                SuccesFull = String.IsNullOrEmpty(message),
                ServiceResultCode = String.IsNullOrEmpty(message) ? ServiceResultCode.Ok : ServiceResultCode.BadRequest,
                Message = String.IsNullOrEmpty(message) ? "200: Challenge succesfully added." : $"400: {message}."
            };
        }
    }
}
