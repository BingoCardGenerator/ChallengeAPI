using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChallengeApi.Models
{
    public class ChallengeForModificationModel
    {
        [Required]
        public string Name { get; set; } = String.Empty;
    }

    public class ChallengeForCreationModel : ChallengeForModificationModel
    {

    }

    public class ChallengeModel : ChallengeForModificationModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        
    }
}
