using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

    public class UserFriend
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int FriendId { get; set; }
        public User Friend { get; set; }
    }
}
