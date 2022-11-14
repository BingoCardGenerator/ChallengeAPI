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
                    },

                    new ChallengeModel
                    {
                        Name = "Test challenge 5"
                    },

                    new ChallengeModel
                    {
                        Name = "Test challenge 6"
                    },

                    new ChallengeModel
                    {
                        Name = "Test challenge 7"
                    },
                    new ChallengeModel
                    {
                        Name = "Test challenge 8"
                    },

                    new ChallengeModel
                    {
                        Name = "Test challenge 9"
                    },

                    new ChallengeModel
                    {
                        Name = "Test challenge 10"
                    },

                    new ChallengeModel
                    {
                        Name = "Test challenge 11"
                    },

                    new ChallengeModel
                    {
                        Name = "Test challenge 12"
                    },

                    new ChallengeModel
                    {
                        Name = "Test challenge 13"
                    },

                    new ChallengeModel
                    {
                        Name = "Test challenge 14"
                    },

                    new ChallengeModel
                    {
                        Name = "Test challenge 15"
                    },

                    new ChallengeModel
                    {
                        Name = "Test challenge 16"
                    },

                    new ChallengeModel
                    {
                        Name = "Test challenge 17"
                    },
                    new ChallengeModel
                    {
                        Name = "Test challenge 18"
                    },

                    new ChallengeModel
                    {
                        Name = "Test challenge 19"
                    },

                    new ChallengeModel
                    {
                        Name = "Test challenge 20"
                    },
                    new ChallengeModel
                    {
                        Name = "Test challenge 21"
                    },

                    new ChallengeModel
                    {
                        Name = "Test challenge 22"
                    },

                    new ChallengeModel
                    {
                        Name = "Test challenge 23"
                    },

                    new ChallengeModel
                    {
                        Name = "Test challenge 24"
                    },

                    new ChallengeModel
                    {
                        Name = "Test challenge 25"
                    },

                    new ChallengeModel
                    {
                        Name = "Test challenge 26"
                    },

                    new ChallengeModel
                    {
                        Name = "Test challenge 27"
                    },
                    new ChallengeModel
                    {
                        Name = "Test challenge 28"
                    },

                    new ChallengeModel
                    {
                        Name = "Test challenge 29"
                    },

                    new ChallengeModel
                    {
                        Name = "Test challenge 30"
                    },

                    new ChallengeModel
                    {
                        Name = "Test challenge 31"
                    },

                    new ChallengeModel
                    {
                        Name = "Test challenge 32"
                    },

                    new ChallengeModel
                    {
                        Name = "Test challenge 33"
                    },

                    new ChallengeModel
                    {
                        Name = "Test challenge 34"
                    },

                    new ChallengeModel
                    {
                        Name = "Test challenge 35"
                    },

                    new ChallengeModel
                    {
                        Name = "Test challenge 36"
                    },

                    new ChallengeModel
                    {
                        Name = "Test challenge 37"
                    },
                    new ChallengeModel
                    {
                        Name = "Test challenge 38"
                    },

                    new ChallengeModel
                    {
                        Name = "Test challenge 39"
                    },

                    new ChallengeModel
                    {
                        Name = "Test challenge 40"
                    },


                };

                _context.Challenges.AddRange(challenges);
                Console.WriteLine("Adding challenges");
                _context.SaveChanges();
            }
        }
    }
}
