using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using QuanLyLichDay.GUI;
using Project_DBManager.DAO;
using Microsoft.Identity.Client;
using QuanLyLichDay.DTO;

namespace QuanLyLichDay.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;
        private static Account acc;
        public static AccountDAO Instance
        {
            get => instance == null ? new AccountDAO() : instance;
            set => instance = value;
        }
        public static Account Acc { get => acc; set => acc = value; }

        private AccountDAO() { }

        public bool checkLogin(string username, string password)
        {
            string query = "SELECT * FROM Users WHERE Username = @Username AND Password = @Password";

            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] {username, password});

            return result.Rows.Count > 0;
        }
        public Account getAccountByUsername(string username)
        {
            string query = "SELECT * FROM Users as U WHERE U.Username = @Username";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { username });
            if (data.Rows.Count != 0)
                return new Account(data.Rows[0]);
            return null;
        }
        public string getEmailByUsername(string username)
        {
            string query = "SELECT User_Email FROM Users Where Username = @Username";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { username });
            return result.Rows[0]["User_Email"].ToString(); 
        }
        public int getRank(string username, string email)
        {
            string query = "SELECT Rank FROM User_Info UI, Users WHERE Users.Username = @Username AND Users.User_ID = UI.User_ID " +
                "AND Users.User_Email = @email";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { username, email });
            int rank = Convert.ToInt32(result.Rows[0]["Rank"].ToString());
            return rank;
        }
    }
}
