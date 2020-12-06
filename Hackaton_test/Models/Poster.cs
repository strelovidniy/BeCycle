using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackaton_test.Models
{
    [Table("Poster")]
    public class Poster
    {
        [Column("PosterId")] public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [ForeignKey("PosterUserForeignKey")] public User User { get; set; }
        public uint UserId { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}