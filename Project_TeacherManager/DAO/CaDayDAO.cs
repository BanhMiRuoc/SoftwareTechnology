using Project_DBManager.DAO;
using QuanLyLichDay.DTO;
using QuanLyLichDay.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyLichDay.DAO
{
    public class CaDayDAO
    {
        private static CaDayDAO instance;

        public static CaDayDAO Instance { get => instance == null ? new CaDayDAO() : instance; set => instance = value; }
        public void updateStatusCaDay(string className, string status, int shift, DateTime day, string username)
        {
            string query = string.Format("UPDATE Class SET Status = N'{0}' " +
                            "WHERE Class_Name = N'{1}' AND Shift_ID = {2} AND DayOfClass = '{3}' AND User_ID = (SELECT User_ID From Users WHERE Username = '{4}')",status, className, shift, day.ToString("MM-dd-yyyy"), username);
            int row = DataProvider.Instance.ExecuteNonQuery(query);
            if(row > 0)
            {
                MessageBox.Show("Cập nhật thành công");
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại");
            }
        }
        public bool deleteCaDay(string className, int shift, DateTime day, string username)
        {
            string query = string.Format("DELETE FROM CLASS WHERE Class_Name = N'{0}' AND Shift_ID = {1} AND DayOfClass = '{2}' AND User_ID = (SELECT User_ID From Users WHERE Username = '{3}')", className, shift, day.ToString("MM-dd-yyyy"), username);
            int row = DataProvider.Instance.ExecuteNonQuery(query);
            if (row > 0)
            {
                MessageBox.Show("Xoá thành công");
            }
            else
            {
                MessageBox.Show("Xoá thất bại");
            }
            return row > 0;
        }
        public bool insertCaDay(string className, int shift, DateTime day, string username)
        {
            string query = string.Format("INSERT INTO Class (Class_Name, Shift_ID, User_ID, DayOfClass) VALUES (N'{0}', {1}, (SELECT User_ID From Users WHERE Username = '{2}'), '{3}')", className, shift, username, day.ToString("MM-dd-yyyy"));
            int row = DataProvider.Instance.ExecuteNonQuery(query);
            if (row > 0)
            {
                MessageBox.Show("Thêm thành công");
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
            return row > 0;
        }
    }
}
