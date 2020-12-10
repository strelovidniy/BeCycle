namespace Hackaton_test.Models
{
    public class EventFollower
    {
        public int FollowerId { get; set; }
        public User Follower { get; set; }
        public int EventId { get; set; }
        public Poster Event { get; set; }
    }
}
