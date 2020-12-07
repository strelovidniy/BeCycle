using System.Collections.Generic;

namespace Hackaton_test.Models
{
    public class Achievement
    {
        public int AchievementId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<UserAchievement> UserAchievements { get; set; }

        public Achievement() => UserAchievements = new List<UserAchievement>();
    }
}