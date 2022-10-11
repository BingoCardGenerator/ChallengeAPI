using Microsoft.AspNetCore.Mvc;
using ChallengeApi.DbContext;
using ChallengeApi.interfaces;
using ChallengeApi.Services;
using ChallengeApi.Models;


namespace ChallengeApi.Controllers
{
    [ApiController]
    [Route("Api/Challenges")]
    public class ChallengeController : ChallengeApiController
    {
        private readonly IChallengeService _challengeService;

        public ChallengeController(ChallengeContext context)
        {
              _challengeService = new ChallengeService(context);
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<ChallengeModel>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetAllChallenges()
        {
            return GetActionResult(await _challengeService.GetAllChallenges());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreateNewChallenge(ChallengeForCreationModel forCreationModel)
        {
            var result = await _challengeService.CreateChallenge(forCreationModel);

            return GetActionResult(result);
        }
    }
}
