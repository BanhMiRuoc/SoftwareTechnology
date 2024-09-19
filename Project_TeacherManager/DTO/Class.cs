using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyLichDay.DTO
{
    public class Class
    {
        private string className;
        private int shift;
        private DateTime day;
        private string status;

        public string ClassName { get => className; set => className = value; }
        public DateTime Day { get => day; set => day = value; }
        public int Shift { get => shift; set => shift = value; }
        public string Status { get => status; set => status = value; }

        public Class(DataRow row)
        {
            this.className = row["Class_Name"].ToString();
            this.shift = int.Parse(row["Shift_ID"].ToString());
            string[] item = row["Day"].ToString().Split('-');
            this.day = new DateTime(int.Parse(item[0]), int.Parse(item[1]), int.Parse(item[2])); // Format: year-month-day
            this.Status = row["Status"].ToString();
        }
    }
}
