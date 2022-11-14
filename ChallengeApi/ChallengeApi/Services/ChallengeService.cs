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

        public async Task<ServiceResponse<IEnumerable<ChallengeModel>>> GetAllChallenges()
        {
            var challenges = await _context.Challenges.ToListAsync();

            if(challenges == null)
            {
                return new ServiceResponse<IEnumerable<ChallengeModel>>
                {
                    Data = challenges,
                    SuccesFull = false,
                    ServiceResultCode = ServiceResultCode.NotFound,
                    Message = "404: No challenges found."
                };
            }

            else return new ServiceResponse<IEnumerable<ChallengeModel>>
            {
                Data = challenges,
                SuccesFull = challenges.Count > 0,
                ServiceResultCode = challenges.Count > 0 ? ServiceResultCode.Ok : ServiceResultCode.NotFound,
                Message = challenges.Count > 0 ? "200: Challenges found." : "404: No challenges found."
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

        public async Task<ServiceResponse<IEnumerable<Guid>>>GetAllChallengeIds()
        {
            var challenges = await _context.Challenges.ToListAsync();
            var ids = new List<Guid>();
            
            if(challenges == null)
            {
                return new ServiceResponse<IEnumerable<Guid>>
                {
                    Data = ids,
                    SuccesFull = false,
                    ServiceResultCode = ServiceResultCode.NotFound,
                    Message = "404: No challenges found."
                };
            }
            foreach(var challenge in challenges)
            {
                ids.Add(challenge.Id);
            }

            return new ServiceResponse<IEnumerable<Guid>>
            {
                Data = ids,
                SuccesFull = true,
                ServiceResultCode = ServiceResultCode.Ok,
                Message = "200: Succesfully returned all Ids."
            };
        }
    }
}
