using Project_DBManager.DAO;
using System;
using System.Data;

namespace Project_DBManager.DTO
{
    public class Task
    {
        private string taskTitle;
        private int taskID;
        private string department;
        private string assignDate;
        private string deadline;
        private string description;
        private bool isCompleted;
        private bool isChecked;

        public Task(DataRow row)
        {
            isChecked = false;
            taskTitle = row["Task_Title"].ToString();
            taskID = Convert.ToInt32(row["Task_ID"].ToString());
            assignDate = Convert.ToDateTime(row["AssignDate"]).ToString("dd-MM-yyyy");
            deadline = Convert.ToDateTime(row["Deadline"]).ToString("dd-MM-yyyy");
            description = row["Task_Description"].ToString();
            isCompleted = Convert.ToInt32(row["IsCompleted"].ToString()) == 0 ? false:true;
            department = InformationDAO.Instance.getDepartmenNameByID(Convert.ToInt32(row["Department_ID"].ToString()));
        }

        public string TaskTitle { get => taskTitle; set => taskTitle = value; }
        public int TaskID { get => taskID; set => taskID = value; }
        public string Department { get => department; set => department = value; }
        public string AssignDate { get => assignDate; set => assignDate = value; }
        public string Deadline { get => deadline; set => deadline = value; }
        public string Description { get => description; set => description = value; }
        public bool IsCompleted { get => isCompleted; set => isCompleted = value; }
    }
}
