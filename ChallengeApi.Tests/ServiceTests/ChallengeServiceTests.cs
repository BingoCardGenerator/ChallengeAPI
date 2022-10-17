namespace ChallengeApi.Tests.ServiceTests
{
    public class ChallengeServiceTests
    {
        private ChallengeService _challengeService;
        private ChallengeContext _challengeContext;

        public ChallengeServiceTests()
        {
            var options =
                new DbContextOptionsBuilder<ChallengeContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _challengeContext = new ChallengeContext(options);
            _challengeService = new ChallengeService(_challengeContext);
        }

        [Fact]
        public async Task GetChallenges_WithPopulatedTable_ShouldReturnAllChallenges()
        {
            //Arragne
            await _challengeService.CreateChallenge(new ChallengeForCreationModel { Name = "Test 1"});
            await _challengeService.CreateChallenge(new ChallengeForCreationModel { Name = "Test 2" });
            await _challengeService.CreateChallenge(new ChallengeForCreationModel { Name = "Test 3" });

            //Act
            var results = await _challengeService.GetAllChallenges();
            var resultsData = results.Data ?? new List<ChallengeModel>();


            //Assert
            resultsData
                .Should()
                .NotBeEmpty()
                .And.HaveCount(3);

        }
        [Fact]
        public async Task GetChallenges_WithUnPopulatedTable_ShouldReturnEmpty()
        {
            //Arragne
            await _challengeService.CreateChallenge(new ChallengeForCreationModel());

            //Act
            var results = await _challengeService.GetAllChallenges();
            var resultsData = results.Data ?? new List<ChallengeModel>();


            //Assert
            resultsData
                .Should()
                .BeEmpty();

        }

        [Fact]
        public async Task GetChallenges_WithEmptyTable_ShouldReturnEmpty()
        {
            //Arragne

            //Act
            var results = await _challengeService.GetAllChallenges();
            var resultsData = results.Data;


            //Assert
            resultsData
                .Should()
                .BeEmpty();

        }
    }
}
