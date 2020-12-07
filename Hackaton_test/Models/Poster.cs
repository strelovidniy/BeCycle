using System;
using System.Collections.Generic;

namespace Hackaton_test.Models
{
<<<<<<< HEAD
    public enum SportType
    {
        Extreme, 
        Race,
        ForestRide
    }
=======
>>>>>>> cb99acb0613358e8666409f4eb6f503b457fe108
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

<<<<<<< HEAD
        public Poster()
        {
            EventFollowers = new List<EventFollower>();
        }
>>>>>>> 49eb56b697953001b6e4dc113ddc2e07f32e0725
=======
        public Poster() => EventFollowers = new List<EventFollower>();
>>>>>>> cb99acb0613358e8666409f4eb6f503b457fe108
    }
}