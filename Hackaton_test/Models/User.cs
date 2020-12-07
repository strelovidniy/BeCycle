using System.Collections.Generic;

namespace Hackaton_test.Models
{
<<<<<<< HEAD
=======

>>>>>>> 49eb56b697953001b6e4dc113ddc2e07f32e0725
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
<<<<<<< HEAD

        public int Distance { get; set; }

        public List<Poster> Posters { get; set; } 
=======
        public int Distance { get; set; }

        public List<Poster> Posters { get; set; }
>>>>>>> 49eb56b697953001b6e4dc113ddc2e07f32e0725

        public List<EventFollower> EventFollowers { get; set; }
        public List<UserAchievement> UserAchievements { get; set; }

        public User()
        {
            EventFollowers = new List<EventFollower>();
            UserAchievements = new List<UserAchievement>();
        }
    }

    public class UserAchievement
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int AchievementId { get; set; }
        public Achievement Achievement { get; set; }
    }

    public class EventFollower
    {
        public int FollowerId { get; set; }
        public User Follower { get; set; }
        public int EventId { get; set; }
        public Poster Event { get; set; }
    }
}