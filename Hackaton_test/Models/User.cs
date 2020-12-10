using System.Collections.Generic;

namespace Hackaton_test.Models
{
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
        public int Distance { get; set; }
        public string ImageURL { get; set; }
        public List<Poster> Posters { get; set; }
        public List<EventFollower> EventFollowers { get; set; }
        public List<UserAchievement> UserAchievements { get; set; }
        public List<UserFriend> UserFriends { get; set; }

        public User()
        {
            EventFollowers = new List<EventFollower>();
            UserAchievements = new List<UserAchievement>();
            UserFriends = new List<UserFriend>();
        }
    }
}
