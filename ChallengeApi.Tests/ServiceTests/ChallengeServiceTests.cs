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

            results.Message
                .Should()
                .BeEquivalentTo("200: Challenges found.");

            results.ServiceResultCode
                .Should()
                .Be(ServiceResultCode.Ok);
            results.SuccesFull
                .Should()
                .BeTrue();

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

            results.Message
                .Should()
                .BeEquivalentTo("404: No challenges found.");

            results.ServiceResultCode
                .Should()
                .Be(ServiceResultCode.NotFound);

            results.SuccesFull
                .Should()
                .BeFalse();

        }

        [Fact]
        public async Task CreateChallenge_WithName_ShouldReturnOk()
        {
            //Act
            var result = await _challengeService.CreateChallenge(new ChallengeForCreationModel { Name = "Test 1"});

            //Assert
            result.SuccesFull
                .Should()
                .BeTrue();
            result.ServiceResultCode
                .Should()
                .Be(ServiceResultCode.Ok);
            result.Message
                .Should()
                .BeEquivalentTo("200: Challenge succesfully added.");

        }

        [Fact]
        public async Task CreateChallenge_WithoutName_ShouldReturnBadRequest()
        {
            //Act
            var result = await _challengeService.CreateChallenge(new ChallengeForCreationModel());

            //Assert
            result.SuccesFull
                .Should()
                .BeFalse();
            result.ServiceResultCode
                .Should()
                .Be(ServiceResultCode.BadRequest);
            result.Message
                .Should()
                .BeEquivalentTo("400: Name can not be Empty.");

        }

        [Fact]
        public async Task CountChallenge_WithPopulatedTable_ShouldReturnCorrectCount()
        {
            //Arange
            await _challengeContext.Challenges.AddRangeAsync(
                new ChallengeModel { Id = Guid.NewGuid(), Name = "Test Challenge 1" },
                new ChallengeModel { Id = Guid.NewGuid(), Name = "Test Challenge 2" },
                new ChallengeModel { Id = Guid.NewGuid(), Name = "Test Challenge 3" }
            );
            await _challengeContext.SaveChangesAsync();

            //Act
            var result = await _challengeService.CountChallenges();

            //Assert
            result.SuccesFull
                .Should()
                .Be(true);
            result.ServiceResultCode
                .Should()
                .Be(ServiceResultCode.Ok);
            result.Data
                .Should()
                .Be("3");

        }

        [Fact]
        public async Task CountChallenge_WithUnpopulatedTable_ShouldReturnZero()
        {
            //Act
            var result = await _challengeService.CountChallenges();

            //Assert
            result.SuccesFull
                .Should()
                .Be(true);
            result.ServiceResultCode
                .Should()
                .Be(ServiceResultCode.Ok);
            result.Data
                .Should()
                .Be("0");
        }
    }
}
