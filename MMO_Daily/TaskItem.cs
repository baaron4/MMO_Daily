using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMO_Daily
{
    public class TaskItem
    {
        public int taskID; 
        public string taskName;
        public string taskDesc;
        public bool taskCompletion;
        public DateTime taskLastCompletion;
        public bool taskRecurring; //true for recurring tasks
        public DateTime taskResetDateTime; //Time of day the task resets compeltion status. Marks the start date
        public TimeSpan taskResetTime;//Time between task reset
        public DateTime taskLastResetDateTime;
        public TimeSpan taskLength; //How long that task is available before reset, if 0 always avaialbe



        public TaskItem(string id, string name, string desc, string recur, string resetDateTime, string resetTime,string length)
        {
            this.taskID = Int32.Parse(id);
            this.taskName = name;
            this.taskDesc = desc;
            this.taskRecurring = Boolean.Parse( recur);
            this.taskResetDateTime = DateTime.Parse( resetDateTime);
            this.taskResetTime = TimeSpan.Parse(resetTime);
            this.taskLength = TimeSpan.Parse(length);
        }

        public void UpdateLastCompletion(DateTime dateTime)
        {
            if (dateTime != null)
            {
                this.taskLastCompletion = dateTime;
                this.taskCompletion = true;
            }
            
        }

        public void UpdateStatusFromDates()
        {
            if (taskLastCompletion != null)
            {
                if (taskRecurring == false)
                {
                    taskCompletion = true;
                    return;
                }
                //Get Today, Completion date and last reset
                GetTaskLastResetDateTime();
                if (taskLastCompletion > GetTaskLastResetDateTime() - taskResetTime)
                {
                    
                       taskCompletion = true;
                       return;
                    
                }

                //additional check for limited avaiability tasks
                if (taskLength > TimeSpan.Zero)
                {
                    DateTime dateTimenow = DateTime.Now;
                    DateTime resetTime = GetTaskLastResetDateTime() - taskResetTime;
                    DateTime startTime = GetTaskLastResetDateTime() - taskLength;
                    if (dateTimenow > (resetTime) && dateTimenow < (startTime))
                    {
                        //mark as completed until available again
                        taskCompletion = true;
                        return;
                    }
                }
            }
            taskCompletion = false;
            return;
        }
        public DateTime GetTaskLastResetDateTime()
        {
            DateTime lastResetDate = taskResetDateTime;
            if (taskLastResetDateTime != default(DateTime))
            {
                lastResetDate = taskLastResetDateTime;
            }
            DateTime dateTimeNow = DateTime.Now;
            while ((lastResetDate - dateTimeNow).TotalHours < 0)
            {
                lastResetDate = lastResetDate + taskResetTime;
            }
            return lastResetDate;
        }
        public int GetTimeLeftHours()
        {
            taskLastResetDateTime = GetTaskLastResetDateTime();
            return (int)taskLastResetDateTime.Subtract(DateTime.Now).TotalHours;

        }

        public string GetCompletionButtonText()
        {
            if (taskCompletion)
            {
                return "Done";
            }
            return "To Do";
        }
       
    }
}
