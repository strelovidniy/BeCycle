using System;
using System.Collections.Generic;
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
        public DateTime EventDate { get; set; }
        public DateTime PublicationDate { get; set; }
<<<<<<< HEAD
        public SportType SportType { get; set; }
        
=======

        public User Author { get; set; }
        public int AuthorId { get; set; }

        public List<EventFollower> EventFollowers { get; set; }

        public Poster()
        {
            EventFollowers = new List<EventFollower>();
        }
>>>>>>> 49eb56b697953001b6e4dc113ddc2e07f32e0725
    }
}