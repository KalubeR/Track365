using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Track365.Models
{
    public class Habit
    {
        public Habit()
        {
            this.Id = Guid.NewGuid().ToString();
            this.StartDate = DateTime.Now;
        }

        [Required]
        [Key]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        public User User { get; set; }

        public string UserId { get; set; }

        public HabitCategory HabitCategory { get; set; }

        public string HabitCategoryId { get; set; }

        public DateTime StartDate { get; set; }

        public Reminder Reminder { get; set; }

        public string ReminderId { get; set; }

    }
}
