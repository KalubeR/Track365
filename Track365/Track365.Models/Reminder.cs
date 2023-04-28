using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Track365.Models
{
    public class Reminder
    {
        public Reminder()
        {
            this.Id = Guid.NewGuid().ToString();
            this.RemindTime = DateTime.Now;
        }

        public string Id { get; set; }

        public DateTime RemindTime { get; set; }

        public Habit Habit { get; set; }

        public string HabitId { get; set; }
    }
}
