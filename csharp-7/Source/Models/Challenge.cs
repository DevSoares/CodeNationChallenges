using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
    [Table("challenge")]
    public class Challenge
    {
        [Required]
        [Key]
        [Column("id")]
        public int ChallengenId { get; set; }

        [Required]
        [Column("name", TypeName = "varchar(100)")]
        public string ChallengeName { get; set; }

        [Required]
        [Column("slug", TypeName = "varchar(50)")]
        public string ChallengeSlug { get; set; }

        [Required]
        [Timestamp]
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Required]
        public List<Submission> Submissions { get; set; }

        [Required]
        public List<Acceleration> Accelerations { get; set; }
    }
}
