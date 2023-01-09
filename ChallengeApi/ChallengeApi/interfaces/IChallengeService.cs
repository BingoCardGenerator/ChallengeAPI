using ChallengeApi.Models;

namespace ChallengeApi.interfaces
{
    /// <summary>
    /// Defines a contract that represents the service that handels all challenge releated requests.
    /// </summary>
    public interface IChallengeService
    {
        /// <summary>
        /// Gets all challenges from the database.
        /// </summary>
        /// <returns>
        /// A list of all challenges.
        /// </returns>
        Task<ServiceResponse<IEnumerable<ChallengeModel>>> GetAllChallenges();

        /// <summary>
        /// Adds a new challenge to the database.
        /// </summary>
        /// <param name="newchallenge"> The challenge that has to be created.</param>
        Task<ServiceResponse> CreateChallenge(ChallengeForCreationModel newchallenge);

        /// <summary>
        /// Gets a list of all challenge ids.
        /// </summary>
        /// <returns>A list of challenge ids.</returns>
        Task<ServiceResponse<IEnumerable<Guid>>> GetAllChallengeIds();

        /// <summary>
        /// Get the amount of challenges in the database.
        /// </summary>
        Task<ServiceResponse<String>> CountChallenges();
    }
}
