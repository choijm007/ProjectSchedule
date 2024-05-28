using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ProjectSchedule
{
    public partial class AddEditForm : Form
    {
        List<ForDisplay> displayData = new List<ForDisplay>();

        public AddEditForm()
        {
            InitializeComponent();

            if (ScheduleList.list.Count > 0)
            {
                listingSchedulesByDate(DateTime.Today);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ForDisplay item = listBox1.SelectedItem as ForDisplay;
            if (item != null)
            {
                categoryLabel.Text = "유형 : " + item.type;

                if (item.endDay == string.Empty) { repeatTimeLabel.Text = "반복 기간 : -"; }
                else { repeatTimeLabel.Text = "반복 기간 : \n" + item.startDay + " ~ " + item.endDay; }

                timeLabel.Text = "시간 : " + item.startTime;
                if (item.endTime != string.Empty) { timeLabel.Text += " ~ " + item.endTime; }

                nameLabel.Text = "이름 : " + item.name;
                userMemoLabel.Text = "메모 : " + item.userMemo;
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (ScheduleList.list.Count > 0)
            {
                listingSchedulesByDate(monthCalendar1.SelectionStart.Date);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            ForDisplay item = listBox1.SelectedItem as ForDisplay;

            if (item.subId == -1)
            {
                ScheduleList.list.RemoveAt(ScheduleList.getScheduleIndexById(item.id));
            }
            else if (item.type == "반복성 일정")
            {
                RepeatSchedule temp = ScheduleList.list[ScheduleList.getScheduleIndexById(item.id)] as RepeatSchedule;

                for (int i = 0; i < temp.repeatList.Count; i++)
                {
                    if (temp.repeatList[i].id == item.subId)
                    {
                        temp.repeatList.RemoveAt(i);
                        break;
                    }
                }
            }
            else if ((item.type == "수업") && (item.endDay == string.Empty)) // todo
            {
                ClassSchedule temp = ScheduleList.list[ScheduleList.getScheduleIndexById(item.id)] as ClassSchedule;

                for (int i = 0; i < temp.todoList.Count; i++)
                {
                    if (temp.todoList[i].id == item.subId)
                    {
                        temp.todoList.RemoveAt(i);
                        break;
                    }
                }
            }
            else
            {
                ClassSchedule temp = ScheduleList.list[ScheduleList.getScheduleIndexById(item.id)] as ClassSchedule;

                for (int i = 0; i < temp.repeatList.Count; i++)
                {
                    if (temp.repeatList[i].id == item.subId)
                    {
                        temp.repeatList.RemoveAt(i);
                        break;
                    }
                }
            }

            listingSchedulesByDate(monthCalendar1.SelectionStart.Date);
        }

        private void listingSchedulesByDate(DateTime date)
        {
            listBox1.DataSource = null;
            displayData.Clear();

            foreach (Schedule schedule in ScheduleList.list)
            {
                if (schedule is Alarm)
                {
                    var temp = schedule as Alarm;

                    if (temp.startDay.Date == date.Date)
                    {
                        displayData.Add(new ForDisplay(temp));
                    }
                }
                else if (schedule is Appointment)
                {
                    var temp = schedule as Appointment;

                    if (temp.startDay.Date == date.Date)
                    {
                        displayData.Add(new ForDisplay(temp));
                    }

                }
                else if (schedule is RepeatSchedule)
                {
                    var temp = schedule as RepeatSchedule;

                    if ((temp.startDay.Date <= date.Date) && (temp.endDay.Date >= date.Date))
                    {
                        foreach (RepeatTime rtime in temp.getRepeatTimeByDay(date.Date))
                        {
                            displayData.Add(new ForDisplay(rtime, temp));
                        }
                    }
                }
                else // is ClassSchedule
                {
                    var temp = schedule as ClassSchedule;

                    if ((temp.startDay.Date <= date.Date) && (temp.endDay.Date >= date.Date))
                    {
                        foreach (RepeatTime rtime in temp.getRepeatTimeByDay(date.Date))
                        {
                            displayData.Add(new ForDisplay(rtime, temp));
                        }

                        foreach (ToDo td in temp.getTodoByDay(date.Date))
                        {
                            displayData.Add(new ForDisplay(td, temp));
                        }
                    }
                }
            }

            displayData.Sort((a, b) => a.startTimeForSorting.CompareTo(b.startTimeForSorting)); // 정렬
            
            listBox1.DataSource = displayData;
            
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddForm aForm = new AddForm();
            DialogResult dResult = aForm.ShowDialog();
            if (dResult == DialogResult.OK)
            {
                listingSchedulesByDate(monthCalendar1.SelectionStart.Date);
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            ForDisplay item = listBox1.SelectedItem as ForDisplay;
            if (item.type == "수업")
            {
                ClassAddForm cForm = new ClassAddForm(ScheduleList.getScheduleIndexById(item.id));
                DialogResult dResult = cForm.ShowDialog();
                if (dResult == DialogResult.OK)
                {
                    listingSchedulesByDate(monthCalendar1.SelectionStart.Date);
                }
            }
            else
            {
                AddForm aForm = new AddForm(ScheduleList.getScheduleIndexById(item.id));
                DialogResult dResult = aForm.ShowDialog();
                if (dResult == DialogResult.OK)
                {
                    listingSchedulesByDate(monthCalendar1.SelectionStart.Date);
                }
            }
        }

        private void addClassButton_Click(object sender, EventArgs e)
        {
            ClassAddForm cForm = new ClassAddForm();
            DialogResult dResult = cForm.ShowDialog();
        }
    }
}
