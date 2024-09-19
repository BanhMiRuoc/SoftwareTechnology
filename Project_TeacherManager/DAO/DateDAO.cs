using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLichDay.DAO
{
    public class DateDAO
    {
        private static DateDAO instance;

        public static DateDAO Instance 
        { get => instance == null ? new DateDAO() : instance; set => instance = value; }

        public String toHour(DateTime day)
        {
            return day.ToString("HH:MM:ss");
        }
        public DateTime firstDayOfWeek(DateTime day)
        {

            int daysUntilMonday = ((int)DayOfWeek.Monday - (int)day.DayOfWeek + 7) % 7;
            DateTime firstDay = day.AddDays(-daysUntilMonday);
            firstDay = firstDay.AddHours(-1 * firstDay.Hour).AddMinutes(-1 * firstDay.Minute);
            return firstDay;
            
        }
        public DateTime lastDayOfWeek(DateTime day)
        {
            int daysUntilSunday = ((int)DayOfWeek.Sunday - (int)day.DayOfWeek + 7) % 7;
            DateTime lastDay = day.AddDays(daysUntilSunday);
            lastDay = lastDay.AddHours(23 - lastDay.Hour).AddMinutes(59 - lastDay.Minute);
            return lastDay;
        }
    }
}
