using Microsoft.AspNetCore.Mvc;
using ChallengeApi.DbContext;
using ChallengeApi.interfaces;
using ChallengeApi.Services;
using ChallengeApi.Models;


namespace ChallengeApi.Controllers
{
    /// <summary>
    /// Controller route for Challenges 
    /// </summary>
    [ApiController]
    [Route("Api/Challenges")]
    public class ChallengeController : ChallengeApiController
    {
        /// <summary>
        /// The service object to handel challenges.
        /// </summary>
        private readonly IChallengeService _challengeService;

        public ChallengeController(ChallengeContext context)
        {
              _challengeService = new ChallengeService(context);
        }

        /// <summary>
        /// Api enpoint that gets all the challenges from the database.
        /// </summary>
        /// <returns>
        /// A list of all the challenges in the database.
        /// 200: If the search was completed succesfully.
        /// 404: if the no challenges were found. 
        /// </returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<ChallengeModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("/challenges")]
        public async Task<IActionResult> GetAllChallenges()
        {
            return GetActionResult(await _challengeService.GetAllChallenges());
        }

        /// <summary>
        /// API endpoint to create and add a new challenge to the database.
        /// </summary>
        /// <param name="forCreationModel">The challenge that has to be created</param>
        /// <returns>
        /// 200: If the challenge was created succesfully.
        /// 400: If the challenge could not be created. 
        /// </returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreateNewChallenge(ChallengeForCreationModel forCreationModel)
        {
            var result = await _challengeService.CreateChallenge(forCreationModel);

            return GetActionResult(result);
        }

        /// <summary>
        /// API endpoint to get all challenge ids.
        /// </summary>
        /// <returns>
        /// 200: if the challenge ids were succesfully gotten.
        /// 404: if no challenge ids were found.
        /// </returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("/challenges/ids")]
        public async Task<IActionResult> GetAllIds()
        {
            var result = await _challengeService.GetAllChallengeIds();
            return GetActionResult(result);
        }

        /// <summary>
        /// API endpoint to get the amount of challenges in the database.
        /// </summary>
        /// <returns>
        /// 200: with the amount of challenges in the database.
        /// </returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("/count")]
        public async Task<IActionResult> GetChallengeCount()
        {
            var result = await _challengeService.CountChallenges();
            return GetActionResult(result);
        }
    }
}
