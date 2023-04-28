using Microsoft.AspNetCore.Identity;

namespace Track365.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            this.Habits = new List<Habit>();
            this.Friends = new List<User>();
        }

        public User(string username, string email)
        {
            this.UserName = username;
            this.Email = email;
        }
        public List<Habit> Habits { get; set; }

        public List<User> Friends { get; set; }
    }
}
