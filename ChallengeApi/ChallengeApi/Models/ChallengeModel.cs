using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChallengeApi.Models
{
    /// <summary>
    /// Base class to challenge models of.
    /// </summary>
    public class ChallengeForModificationModel
    {
        /// <summary>
        /// The challenge.
        /// </summary>
        [Required]
        public string Name { get; set; } = String.Empty;
    }

    /// <summary>
    /// Model for a challenge that has yet to be created.
    /// </summary>
    public class ChallengeForCreationModel : ChallengeForModificationModel
    {

    }

    /// <summary>
    /// Model for a challenge.
    /// </summary>
    public class ChallengeModel : ChallengeForModificationModel
    {
        /// <summary>
        /// A unique identifier to keep challenges appart.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        
    }
}
