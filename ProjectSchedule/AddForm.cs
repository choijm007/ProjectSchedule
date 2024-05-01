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
        public AddForm()
        {
            InitializeComponent();
            repeatDatePicker.Format = DateTimePickerFormat.Custom;
            repeatDatePicker.CustomFormat = "MMMMd일 dddd";
            applyButton.Enabled = false;

            everyEnableChange(false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RepeatListForm rForm = new RepeatListForm();
            DialogResult dResult = rForm.ShowDialog();
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
            if (repeatCategory.SelectedIndex == 0)
                repeatDatePicker.CustomFormat = "dddd";
            else if (repeatCategory.SelectedIndex == 1)
                repeatDatePicker.CustomFormat = "d일";
            else if (repeatCategory.SelectedIndex == 2)
                repeatDatePicker.CustomFormat = "MMMMd일";

            repeatEnableChange(true);
            repeatAddButton.Enabled = false;
        }

        private void valueChanged(object sender, EventArgs e)
        {
            scheduleCategory.Enabled = false;

            if (!((sender == repeatRangePicker1) || (sender == repeatRangePicker2)))
                repeatCategory.Enabled = false;

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
            TimeSpan timePart1 = new TimeSpan(int.Parse(repeatHH1.SelectedItem.ToString()), int.Parse(repeatMM1.SelectedItem.ToString()), 0);
            TimeSpan timePart2 = new TimeSpan(int.Parse(repeatHH2.SelectedItem.ToString()), int.Parse(repeatMM2.SelectedItem.ToString()), 0);

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
    }
}
