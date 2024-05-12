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

        public class ForDisplay
        {
            public readonly int id;
            public readonly int subId;
            public readonly int startTimeForSorting;
            public string type;
            public string name;
            public string startDay;
            public string endDay;
            public string startTime;
            public string endTime;
            public string userMemo;
            public string displayText;

            public ForDisplay(Alarm alarm)
            {
                id = alarm.id;
                subId = -1;
                type = "알람";
                name = alarm.name;
                startDay = alarm.startDay.ToString("yyyy-MM-dd");
                endDay = string.Empty;
                startTime = alarm.startHour.ToString() + ":" + alarm.startMinute.ToString();
                endTime = string.Empty;
                userMemo = alarm.userMemo;
                startTimeForSorting = alarm.startHour * 100 + alarm.startMinute;
                displayText = $"{startTime} 에 {name} 이(가) 있습니다.";
            }

            public ForDisplay(Appointment appointment)
            {
                id = appointment.id;
                subId = -1;
                type = "일회성 일정";
                name = appointment.name;
                startDay = appointment.startDay.ToString("yyyy-MM-dd");
                endDay = string.Empty;
                startTime = appointment.startHour.ToString() + ":" + appointment.startMinute.ToString();
                endTime = appointment.endHour.ToString() + ":" + appointment.endMinute.ToString();
                userMemo = appointment.userMemo;
                startTimeForSorting = appointment.startHour * 100 + appointment.startMinute;
                displayText = $"{startTime} 부터 {endTime} 까지 {name} 일정이 있습니다.";
            }

            public ForDisplay(RepeatTime repeatTime, RepeatSchedule repeatSchedule)
            {
                id = repeatSchedule.id;
                subId = repeatTime.id;
                type = "반복성 일정";
                name = repeatSchedule.name;
                startDay = repeatSchedule.startDay.ToString("yyyy-MM-dd");
                endDay = repeatSchedule.endDay.ToString("yyyy-MM-dd");
                startTime = repeatTime.startHour.ToString() + ":" + repeatTime.startMinute.ToString();
                endTime = repeatTime.endHour.ToString() + ":" + repeatTime.endMinute.ToString();
                userMemo = repeatSchedule.userMemo;
                startTimeForSorting = repeatTime.startHour * 100 + repeatTime.startMinute;
                displayText = $"{startTime} 부터 {endTime} 까지 {name} 일정이 있습니다.";
            }

            public ForDisplay(RepeatTime repeatTime, ClassSchedule classSchedule)
            {
                id = classSchedule.id;
                subId = repeatTime.id;
                type = "수업";
                name = classSchedule.name;
                startDay = classSchedule.startDay.ToString("yyyy-MM-dd");
                endDay = classSchedule.endDay.ToString("yyyy-MM-dd");
                startTime = repeatTime.startHour.ToString() + ":" + repeatTime.startMinute.ToString();
                endTime = repeatTime.endHour.ToString() + ":" + repeatTime.endMinute.ToString();
                userMemo = classSchedule.userMemo;
                startTimeForSorting = repeatTime.startHour * 100 + repeatTime.startMinute;
                displayText = $"{startTime} 부터 {endTime} 까지 {name} 수업이 있습니다.";
            }

            public ForDisplay(ToDo todo, ClassSchedule classSchedule)
            {
                id = classSchedule.id;
                subId = todo.id;
                type = "수업";
                name = $"{classSchedule.name} 수업의 {todo.name} 과제";
                startDay = todo.deadLine.ToString("yyyy-MM-dd");
                endDay = string.Empty;
                startTime = todo.deadLineHour.ToString() + ":" + todo.deadLineMinute.ToString();
                endTime = string.Empty;
                userMemo = todo.userMemo;
                startTimeForSorting = todo.deadLineHour * 100 + todo.deadLineMinute;
                displayText = $"{startTime} 에 {name} {todo.type} 이(가) 마감됩니다.";
            }

            public override string ToString()
            {
                return displayText;
            }
        }

        
    }
}
