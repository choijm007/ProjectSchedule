using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectSchedule
{
    public partial class AddForm : Form
    {
        public readonly int index;
        public List<RepeatTime> repeatListCollection;

        public AddForm()
        {
            InitializeComponent();
            repeatDatePicker.Format = DateTimePickerFormat.Custom;
            repeatDatePicker.CustomFormat = "MMMMd일 dddd";
            applyButton.Enabled = false;

            everyEnableChange(false);

            index = -1;
            repeatListCollection = new List<RepeatTime>();
        }

        public AddForm(int index)
        {
            InitializeComponent();
            repeatDatePicker.Format = DateTimePickerFormat.Custom;
            repeatDatePicker.CustomFormat = "MMMMd일 dddd";

            everyEnableChange(false);

            this.index = index;

            if (ScheduleList.list[index] is Alarm)
            {
                Alarm temp = ScheduleList.list[index] as Alarm;
                repeatListCollection = new List<RepeatTime>();

                scheduleCategory.SelectedIndex = 0;
                scheduleCategory.Enabled = false;

                repeatRangePicker1.Value = temp.startDay;
                timeHH1.SelectedIndex = temp.startHour;
                timeMM1.SelectedIndex = temp.startMinute / 10;
                nameTextBox.Text = temp.name;
                userMemoTextBox.Text = temp.userMemo;

                everyEnableChange(false);
                rangePartOneEnableChange(true);
                timePartOneEnableChange(true);
            }
            else if (ScheduleList.list[index] is Appointment)
            {
                Appointment temp = ScheduleList.list[index] as Appointment;
                repeatListCollection = new List<RepeatTime>();

                scheduleCategory.SelectedIndex = 1;
                scheduleCategory.Enabled = false;

                repeatRangePicker1.Value = temp.startDay;
                timeHH1.SelectedIndex = temp.startHour;
                timeMM1.SelectedIndex = temp.startMinute / 10;
                timeHH2.SelectedIndex = temp.endHour;
                timeMM2.SelectedIndex = temp.endMinute / 10;
                nameTextBox.Text = temp.name;
                userMemoTextBox.Text = temp.userMemo;

                everyEnableChange(false);
                rangePartOneEnableChange(true);
                timeEnableChange(true);
            }
            else if (ScheduleList.list[index] is RepeatSchedule)
            {
                RepeatSchedule temp = ScheduleList.list[index] as RepeatSchedule;
                repeatListCollection = temp.repeatList;

                rangeEnableChange(true);
                timeEnableChange(false);

                repeatCategory.SelectedIndex = temp.repeatType;
                repeatRangePicker1.Value = temp.startDay;
                repeatRangePicker2.Value = temp.endDay;
                userMemoTextBox.Text = temp.userMemo;
                nameTextBox.Text = temp.name;

                scheduleCategory.SelectedIndex = 2;
                scheduleCategory.Enabled = false;

                if (repeatCategory.SelectedIndex == 0)  // 매주
                    repeatDatePicker.CustomFormat = "dddd";
                else if (repeatCategory.SelectedIndex == 1) // 매달
                    repeatDatePicker.CustomFormat = "d일";
                else if (repeatCategory.SelectedIndex == 2) // 매년
                    repeatDatePicker.CustomFormat = "MMMMd일";

                repeatEnableChange(true);
                repeatAddButton.Enabled = false;
            }
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            if (scheduleCategory.SelectedIndex == 0) // 1회성 알람
            {
                Alarm temp = new Alarm();
                
                temp.name = nameTextBox.Text;
                temp.startDay = repeatRangePicker1.Value.Date;
                temp.startHour = int.Parse(timeHH1.SelectedItem.ToString());
                temp.startMinute = int.Parse(timeMM1.SelectedItem.ToString());
                temp.userMemo = userMemoTextBox.Text;

                if (index == -1) { ScheduleList.list.Add(temp); }
                else { ScheduleList.list[index] = temp; }
            }
            else if (scheduleCategory.SelectedIndex == 1) // 1회성 일정
            {
                Appointment temp = new Appointment();

                temp.name = nameTextBox.Text;
                temp.startDay = repeatRangePicker1.Value.Date;
                temp.startHour = int.Parse(timeHH1.SelectedItem.ToString());
                temp.startMinute = int.Parse(timeMM1.SelectedItem.ToString());
                temp.endHour = int.Parse(timeHH2.SelectedItem.ToString());
                temp.endMinute = int.Parse(timeMM2.SelectedItem.ToString());
                temp.userMemo = userMemoTextBox.Text;

                if (index == -1) { ScheduleList.list.Add(temp); }
                else { ScheduleList.list[index] = temp; }
            }
            else if (scheduleCategory.SelectedIndex == 2) // 반복성 일정
            {
                RepeatSchedule temp = new RepeatSchedule(repeatCategory.SelectedIndex);

                temp.name = nameTextBox.Text;
                temp.startDay = repeatRangePicker1.Value.Date;
                temp.endDay = repeatRangePicker2.Value.Date;
                temp.userMemo = userMemoTextBox.Text;

                foreach (RepeatTime rtemp in repeatListCollection)
                {
                    temp.repeatList.Add(new RepeatTime(temp.createRepeatTimeId()) { date = rtemp.date, 
                        startHour = rtemp.startHour, startMinute = rtemp.startMinute,
                        endHour = rtemp.endHour, endMinute = rtemp.endMinute});
                }

                if (index == -1) { ScheduleList.list.Add(temp); }
                else { ScheduleList.list[index] = temp; }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void repeatAddButton_Click(object sender, EventArgs e)
        {
            errorLabel.Text = string.Empty;
            applyButton.Enabled = true;

            repeatListCollection.Add(new RepeatTime(-1)
            {
                date = repeatDatePicker.Value.Date,
                startHour = int.Parse(repeatHH1.SelectedItem.ToString()),
                startMinute = int.Parse(repeatMM1.SelectedItem.ToString()),
                endHour = int.Parse(repeatHH2.SelectedItem.ToString()),
                endMinute = int.Parse(repeatMM2.SelectedItem.ToString())
            });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            repeatCategory.Enabled = false;
            RepeatListForm rForm = new RepeatListForm(repeatListCollection, repeatCategory.SelectedIndex);
            DialogResult dResult = rForm.ShowDialog();

            if (dResult == DialogResult.OK)
            {
                repeatListCollection = rForm.RepeatTimes;
            }
        }

        private void scheduleCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (scheduleCategory.SelectedIndex == 0) // 1회성 알람
            {
                everyEnableChange(false);
                rangePartOneEnableChange(true);
                timePartOneEnableChange(true);
            }
            else if (scheduleCategory.SelectedIndex == 1) // 1회성 일정
            {
                everyEnableChange(false);
                rangePartOneEnableChange(true);
                timeEnableChange(true);
            }
            else if (scheduleCategory.SelectedIndex == 2) // 반복성 일정
            {
                repeatCategory.Enabled = true;
                rangeEnableChange(true);
                timeEnableChange(false);
            }
        }

        private void repeatCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (repeatCategory.SelectedIndex == 0)  // 매주
                repeatDatePicker.CustomFormat = "dddd";
            else if (repeatCategory.SelectedIndex == 1) // 매달
                repeatDatePicker.CustomFormat = "d일";
            else if (repeatCategory.SelectedIndex == 2) // 매년
                repeatDatePicker.CustomFormat = "MMMMd일";

            repeatEnableChange(true);
            repeatAddButton.Enabled = false;
        }

        private void valueChanged(object sender, EventArgs e)
        {
            scheduleCategory.Enabled = false;

            if (alertCheck()) // 1회성 알람
            {
                if (DateTime.Compare(selectedTimePartOne(), DateTime.Now) == -1)
                {
                    errorLabel.Text = "시간 설정 오류";
                    applyButton.Enabled = false;
                }
                else
                {
                    if (nameTextBox.Text == string.Empty)
                    {
                        errorLabel.Text = "이름 없음";
                        applyButton.Enabled = false;
                    }
                    else
                    {
                        errorLabel.Text = string.Empty;
                        applyButton.Enabled = true;
                    }
                }
            }
            else if (scheduleCheck()) // 1회성 일정
            {
                if ((DateTime.Compare(selectedTimePartOne(), DateTime.Now) ==  -1) || 
                    (DateTime.Compare(selectedTimePartOne(), selectedTimePartTwo()) == 1))
                {
                    errorLabel.Text = "시간 설정 오류";
                    applyButton.Enabled = false;
                }
                else
                {
                    if (nameTextBox.Text == string.Empty)
                    {
                        errorLabel.Text = "이름 없음";
                        applyButton.Enabled = false;
                    }
                    else
                    {
                        errorLabel.Text = string.Empty;
                        applyButton.Enabled = true;
                    }
                }

            }
            else if (repeatScheduleCheck()) // 반복성 일정
            {
                if (selectedRepeatTime())
                {
                    if (nameTextBox.Text == string.Empty)
                    {
                        errorLabel.Text = "이름 없음";
                        applyButton.Enabled = false;
                        repeatAddButton.Enabled = true;
                    }
                    else if (repeatListCollection.Count <= 0)
                    {
                        errorLabel.Text = "반복 일정 없음";
                        applyButton.Enabled = false;
                        repeatAddButton.Enabled = true;
                    }
                    else
                    {
                        errorLabel.Text = string.Empty;
                        repeatAddButton.Enabled = true;
                        applyButton.Enabled = true;
                    }
                }
                else
                {
                    errorLabel.Text = "시간 설정 오류";
                    applyButton.Enabled = false;
                    repeatAddButton.Enabled = false;
                }
            }
        }

        private DateTime selectedTimePartOne()
        {
            DateTime datePart = repeatRangePicker1.Value.Date;
            TimeSpan timePart = new TimeSpan(int.Parse(timeHH1.SelectedItem.ToString()), int.Parse(timeMM1.SelectedItem.ToString()), 0);

            return datePart.Add(timePart);
        }
        private DateTime selectedTimePartTwo()
        {
            DateTime datePart = repeatRangePicker1.Value.Date;
            TimeSpan timePart = new TimeSpan(int.Parse(timeHH2.SelectedItem.ToString()), int.Parse(timeMM2.SelectedItem.ToString()), 0);

            return datePart.Add(timePart);
        }
        private bool selectedRepeatTime()
        {
            DateTime datePartEnd = repeatRangePicker2.Value.Date;
            DateTime datePartStart = repeatRangePicker1.Value.Date;
            TimeSpan timePart1 = new TimeSpan(int.Parse(repeatHH1.SelectedItem.ToString()), int.Parse(repeatMM1.SelectedItem.ToString()), 0);
            TimeSpan timePart2 = new TimeSpan(int.Parse(repeatHH2.SelectedItem.ToString()), int.Parse(repeatMM2.SelectedItem.ToString()), 0);

            if (DateTime.Compare(datePartStart, datePartEnd) != -1) return false;

            if (DateTime.Compare(datePartEnd, DateTime.Now) != 1) return false;

            if (DateTime.Compare(datePartEnd.Add(timePart1), datePartEnd.Add(timePart2)) != -1) return false;

            return true;

        }
        private bool alertCheck()
        {
            return scheduleCategory.SelectedIndex == 0
                && timeHH1.SelectedIndex != -1
                && timeMM1.SelectedIndex != -1;
        }
        private bool scheduleCheck()
        {
            return scheduleCategory.SelectedIndex == 1
                && timeHH1.SelectedIndex != -1
                && timeMM1.SelectedIndex != -1
                && timeHH2.SelectedIndex != -1
                && timeMM2.SelectedIndex != -1;
        }
        private bool repeatScheduleCheck()
        {
            return scheduleCategory.SelectedIndex == 2
                && repeatHH1.SelectedIndex != -1
                && repeatMM1.SelectedIndex != -1
                && repeatHH2.SelectedIndex != -1
                && repeatMM2.SelectedIndex != -1;
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nameTextBox.Text))
            {
                errorLabel.Text = "이름 없음";
                return;
            }
            errorLabel.Text = string.Empty;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        
    }
}
