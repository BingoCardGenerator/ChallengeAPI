using ChallengeApi.DbContext;
using ChallengeApi.Models;

namespace ChallengeApi
{
    public class Seed
    {
        private readonly ChallengeContext _context;

        public Seed(ChallengeContext context)
        {
            _context = context;
        }

        public void SeedContext()
        {
            if(!_context.Challenges.Any())
            {
                var challenges = new List<ChallengeModel>()
                {
                    new ChallengeModel
                    {
                        Name = "Test challenge 1"
                    },

                    new ChallengeModel
                    {
                        Name = "Test challenge 2"
                    },

                    new ChallengeModel
                    {
                        Name = "Test challenge 3"
                    },

                    new ChallengeModel
                    {
                        Name = "Test challenge 4"
                    }

                };

                _context.Challenges.AddRange(challenges);
                Console.WriteLine("Adding challenges");
                _context.SaveChanges();
            }
        }
    }
}
