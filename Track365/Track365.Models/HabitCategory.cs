using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Track365.Models
{
    public class HabitCategory
    {
        public HabitCategory()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Habits = new List<Habit>();
        }

        [Required]
        [Key]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public List<Habit> Habits { get; set; }
    }
}
