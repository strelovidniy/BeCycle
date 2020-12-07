using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackaton_test.Models
{
    public enum SportType
    {
        Extreme, 
        Race,
        ForestRide
    }
    public class Poster
    {
        public int PosterId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [ForeignKey("PosterUserForeignKey")] public User User { get; set; }
        public int UserId { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime PublicationDate { get; set; }
        public SportType SportType { get; set; }
        
    }
}