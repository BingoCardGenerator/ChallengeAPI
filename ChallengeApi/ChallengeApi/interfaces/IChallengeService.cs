using ChallengeApi.Models;

namespace ChallengeApi.interfaces
{
    public interface IChallengeService
    {
        Task<ServiceResponse<IReadOnlyList<ChallengeModel>>> GetAllChallenges();
        Task<ServiceResponse> CreateChallenge(ChallengeForCreationModel newchallenge);
    }
}
