using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using CsvHelper;

namespace MMO_Daily
{
    public partial class Form1 : Form
    {
        public List<TaskItem> taskList = new List<TaskItem>();
        public List<DBItem> datesDB = new List<DBItem>();
        int lastHour = 0;
        public Form1()
        {
            InitializeComponent();
            
         
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Check CSV Autoload
            textBox_CSVFilePath.Text = MMO_Daily.Properties.Settings.Default.AutoLoadCSVLocation;
            checkBox_AutoLoad.Checked = MMO_Daily.Properties.Settings.Default.AutoLoadCSVEnable;
            textBox_DBCSV.Text = MMO_Daily.Properties.Settings.Default.AutoLoadDBCSVLocation;
            checkBox_AutoLoadDB.Checked = MMO_Daily.Properties.Settings.Default.AutoLoadDBCSVEnable;

            if (checkBox_AutoLoad.Checked)
            {
                if (File.Exists(textBox_CSVFilePath.Text))
                {
                    UpdateTaskListData(textBox_CSVFilePath.Text);
                    

                    //Check DB autoload
                    if (checkBox_AutoLoadDB.Checked)
                    {
                        if (File.Exists(textBox_DBCSV.Text))
                        {
                            LoadDateTimeDB(textBox_DBCSV.Text);
                        }
                    }

                    GenerateDataGridView();
                    UpdatedataGridViewColor();
                }
            }

            var aTimer = new System.Timers.Timer(60000); //One second, (use less to add precision, use more to consume less processor time
            
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Start();
             
          
        }
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            
            if (lastHour < DateTime.Now.Hour || (lastHour == 23 && DateTime.Now.Hour == 0))
            {
                lastHour = DateTime.Now.Hour;

                HourlyUpdate();
            }

        }
        private void HourlyUpdate()
        {
            Console.WriteLine("Hour Update");
            foreach (TaskItem item in taskList)
            {
                item.GetTaskLastResetDateTime();
                item.UpdateStatusFromDates();

            }
            UpdateDataGridView();
        }
        private void button_Import_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();

            textBox_CSVFilePath.Text = openFileDialog1.FileName;
            if (File.Exists(openFileDialog1.FileName))
            {
                MMO_Daily.Properties.Settings.Default.AutoLoadCSVLocation = openFileDialog1.FileName;
                MMO_Daily.Properties.Settings.Default.Save();
                UpdateTaskListData(textBox_CSVFilePath.Text);
                GenerateDataGridView();
                UpdatedataGridViewColor();
            }
        }
        private void checkBox_AutoLoad_CheckedChanged(object sender, EventArgs e)
        {
            MMO_Daily.Properties.Settings.Default.AutoLoadCSVEnable = checkBox_AutoLoad.Checked;
            MMO_Daily.Properties.Settings.Default.Save();
        }
        private void button_SetDBCSV_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();

            textBox_DBCSV.Text = openFileDialog2.FileName;
            if (File.Exists(openFileDialog2.FileName))
            {
                MMO_Daily.Properties.Settings.Default.AutoLoadDBCSVLocation = openFileDialog2.FileName;
                MMO_Daily.Properties.Settings.Default.Save();
                LoadDateTimeDB(textBox_DBCSV.Text);
            }
        }
        private void checkBox_AutoLoadDB_CheckedChanged(object sender, EventArgs e)
        {
            MMO_Daily.Properties.Settings.Default.AutoLoadDBCSVEnable = checkBox_AutoLoadDB.Checked;
            MMO_Daily.Properties.Settings.Default.Save();
        }
        private void UpdateTaskListData(string templateFile)
        {

            //Collect Template Data from CSV
            string[] lines = System.IO.File.ReadAllLines(templateFile);
            if (lines.Length > 0)
            {
                string firstLine = lines[0];
                string[] headerLabels = firstLine.Split(',');
                for (int r = 1; r < lines.Length; r++)
                {
                    string[] dataWords = lines[r].Split(',');
                    taskList.Add(new TaskItem(dataWords[0], dataWords[1], dataWords[2], dataWords[3],dataWords[4],dataWords[5],dataWords[6]));
                }
            }
        }

        private void GenerateDataGridView()
        {
            //Generate DataGridView
            if(dataGridView1.ColumnCount == 0)
            {
                dataGridView1.ColumnCount = 2;
                dataGridView1.Columns[0].Name = "Task Name";
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dataGridView1.Columns[1].Name = "Description";
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                DataGridViewButtonColumn completeButtonColumn = new DataGridViewButtonColumn();
                completeButtonColumn.Name = "Status";
                completeButtonColumn.Text = "Status";
                completeButtonColumn.SortMode = DataGridViewColumnSortMode.Automatic;
                dataGridView1.Columns.Add(completeButtonColumn);

                //dataGridView1.Columns[2].Name = "Complete";
                //dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                DataGridViewProgressColumn progressColumn = new DataGridViewProgressColumn();
                progressColumn.HeaderText = "Time Left";
                progressColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                progressColumn.SortMode = DataGridViewColumnSortMode.Automatic;
                dataGridView1.Columns.Add(progressColumn);
                //dataGridView1.Columns[3].HeaderText = "Time Left";
                //dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            //generate data
            foreach (TaskItem taskEntry in taskList)
            {
                
                dataGridView1.Rows.Add(new object[] { taskEntry.taskName, taskEntry.taskDesc, taskEntry.GetCompletionButtonText(), calcTimeLeftBar(taskEntry)  });
            }
        }
         private int calcTimeLeftBar(TaskItem taskEntry)
        {
            int timeleftbar = taskEntry.GetTimeLeftHours();
            if (taskEntry.taskLength > TimeSpan.Zero)
            {
                if (timeleftbar > taskEntry.taskLength.TotalHours)
                {
                    timeleftbar = timeleftbar - (int)taskEntry.taskLength.TotalHours;
                }
            }
            return timeleftbar;
        }
        private void UpdateDataGridView()
        {

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                TaskItem taskEntry = taskList.Find(x => x.taskName == (string)row.Cells[0].Value);
                if (taskEntry != null)
                {

                    dataGridView1.Rows[row.Index].SetValues(new object[] { taskEntry.taskName, taskEntry.taskDesc, taskEntry.GetCompletionButtonText(), calcTimeLeftBar(taskEntry) });
                }
               
            }
            UpdatedataGridViewColor();
        }

        private void UpdateDataGridViewRow(int rownum)
        {
            //Update data
            TaskItem taskEntry = taskList.Find(x => x.taskName == (string)dataGridView1.Rows[rownum].Cells[0].Value);
            if (taskEntry != null)
            {
                dataGridView1.Rows[rownum].SetValues(new object[] { taskEntry.taskName, taskEntry.taskDesc, taskEntry.GetCompletionButtonText(), calcTimeLeftBar(taskEntry) });
            }
            //update color
            if (dataGridView1.Rows[rownum].Cells[0].Value != null)
            {
                if ((string)dataGridView1.Rows[rownum].Cells[2].Value == "Done")
                {
                    //Done state
                    dataGridView1.Rows[rownum].DefaultCellStyle.BackColor = Color.LightGray;
                    dataGridView1.Rows[rownum].Cells[3].Style.BackColor = Color.LightGray;
                    dataGridView1.Rows[rownum].DefaultCellStyle.ForeColor = Color.Gray;
                }
                else if (Convert.ToInt32(dataGridView1.Rows[rownum].Cells[3].Value) < 6)
                {
                    //Ready but low on time
                    dataGridView1.Rows[rownum].Cells[3].Style.BackColor = Color.PaleVioletRed;
                    dataGridView1.Rows[rownum].DefaultCellStyle.ForeColor = Color.Black;
                }
                else
                {
                    //Ready
                    dataGridView1.Rows[rownum].DefaultCellStyle.BackColor = Color.White;
                    dataGridView1.Rows[rownum].Cells[3].Style.BackColor = Color.White;
                    dataGridView1.Rows[rownum].DefaultCellStyle.ForeColor = Color.Black;
                }
            }

            
        }
        private void UpdatedataGridViewColor()
        {
            //Update Color
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    if ((string)row.Cells[2].Value == "Done")
                    {
                        //Done state
                        row.DefaultCellStyle.BackColor = Color.LightGray;
                        row.Cells[3].Style.BackColor = Color.LightGray;
                        row.DefaultCellStyle.ForeColor = Color.Gray;
                        
                    }
                    else if (Convert.ToInt32(row.Cells[3].Value) < 6)
                    {
                        //Ready but low on time
                        row.Cells[3].Style.BackColor = Color.PaleVioletRed;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                    else
                    {
                        //Ready
                        row.DefaultCellStyle.BackColor = Color.White;
                        row.Cells[3].Style.BackColor = Color.White;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
                
                
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0 && e.RowIndex < dataGridView1.RowCount-1)
            {
                if (taskList.Find(x => x.taskName == (string)dataGridView1.Rows[e.RowIndex].Cells[0].Value).taskCompletion == false)
                {
                    taskList.Find(x => x.taskName == (string)dataGridView1.Rows[e.RowIndex].Cells[0].Value).UpdateLastCompletion(DateTime.Now);
                    datesDB.Find(x => x.name == (string)dataGridView1.Rows[e.RowIndex].Cells[0].Value).CompletionTimes.Add(DateTime.Now);
                    SaveDateTimeDB(textBox_DBCSV.Text);
                    UpdateDataGridViewRow(e.RowIndex);
                }
            }
        }

        private void LoadDateTimeDB(string filepath)
        {
            //Collect any existing data
            string[] lines = System.IO.File.ReadAllLines(filepath);
            if (lines.Length > 0)
            {

                for (int r = 0; r < lines.Length; r++)
                {
                    string[] dataWords = lines[r].Split(',');
                    List<DateTime> dateList = new List<DateTime>();
                    for (int n = 1; n < dataWords.Count(); n++)
                    {
                        dateList.Add(DateTime.Parse( dataWords[n]));
                    }
                    DBItem item = new DBItem(dataWords[0], dateList);
                    datesDB.Add(item);
                }
            }
            //Verify all tasks exist in DB/Collect data . If none add them
            int taskcount = 0;
            foreach (TaskItem taskItem in taskList)
            {
                bool nameexists = false;
                foreach (DBItem dateItem in datesDB)
                {
                    if (taskItem.taskName == dateItem.name)
                    {
                        nameexists = true;
                        if (dateItem.CompletionTimes.Count > 0)
                        {
                            taskList[taskcount].UpdateLastCompletion(dateItem.CompletionTimes[dateItem.CompletionTimes.Count - 1]);
                            taskList[taskcount].UpdateStatusFromDates();
                        }
                        
                        break;
                    }
                }
                if (!nameexists)
                {
                    datesDB.Add(new DBItem(taskItem.taskName, new List<DateTime>()));
                }
                taskcount++;
            }
        }

        private void SaveDateTimeDB(string filepath)
        {
            using (var writer = new StreamWriter(filepath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                foreach (DBItem item in datesDB)
                {
                    csv.WriteField(item.name);
                    foreach (DateTime time in item.CompletionTimes)
                    {
                        csv.WriteField(time);
                    }
                    csv.NextRecord();
                }
                writer.Flush();
            }
            
        }

        private void button_OpenDBCSV_Click(object sender, EventArgs e)
        {
            if (File.Exists(textBox_DBCSV.Text))
            {
                Process.Start(textBox_DBCSV.Text);
            }
        }

        private void button_OpenCSV_Click(object sender, EventArgs e)
        {
            if (File.Exists(textBox_CSVFilePath.Text))
            {
                Process.Start(textBox_CSVFilePath.Text);
            }
        }
    }
}
