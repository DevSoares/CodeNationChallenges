using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
    [Table("acceleration")]
    public class Acceleration
    {
        [Required]
        [Key]
        [Column("id")]
        public int AccelerationId { get; set; }

        [Required]
        [Column("name", TypeName = "varchar(100)")]
        public string AccelerationName { get; set; }

        [Required]
        [Column("slug", TypeName = "varchar(50)")]
        public string AccelerationSlug { get; set; }

        [Required]
        [Column("challenge_id")]
        public int ChallengeId { get; set; }

        [Required]
        [Timestamp]
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Required]
        [ForeignKey("ChallengeId")]
        public Challenge Challenge { get; set; }

        [Required]
        public List<Candidate> Candidates { get; set; }
    }
}
