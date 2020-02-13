using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
    [Table("company")]
    public class Company
    {
        [Required]
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("name", TypeName = "varchar(100)")]
        public string CompanyName { get; set; }

        [Required]
        [Column("slug", TypeName = "varchar(50)")]
        public string CompanySlug { get; set; }

        [Required]
        [Timestamp]
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Required]
        public List<Candidate> Candidates { get; set; }

    }
}