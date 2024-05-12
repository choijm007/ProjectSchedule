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
    public partial class ClassAddForm : Form
    {
        public readonly int index;
        public List<RepeatTime> repeatList;
        public List<ToDo> toDoList;

        public ClassAddForm()
        {
            InitializeComponent();

            repeatDatePicker.Format = DateTimePickerFormat.Custom;
            repeatDatePicker.CustomFormat = "MMMMd일 dddd";
            applyButton.Enabled = false;
            todoAddButton.Enabled = false;

            index = -1;
            repeatList = new List<RepeatTime>();
            toDoList = new List<ToDo>();

            repeatEnableChange(false);
        }

        public ClassAddForm(int index)
        {
            InitializeComponent();

            repeatDatePicker.Format = DateTimePickerFormat.Custom;
            repeatDatePicker.CustomFormat = "MMMMd일 dddd";
            todoAddButton.Enabled = false;

            this.index = index;

            ClassSchedule temp = ScheduleList.list[index] as ClassSchedule;

            repeatList = temp.repeatList;
            toDoList = temp.todoList;

            nameTextBox.Text = temp.name;

            repeatCategory.SelectedIndex = temp.repeatType;
            if (repeatCategory.SelectedIndex == 0)  // 매주
                repeatDatePicker.CustomFormat = "dddd";
            else if (repeatCategory.SelectedIndex == 1) // 매달
                repeatDatePicker.CustomFormat = "d일";
            else if (repeatCategory.SelectedIndex == 2) // 매년
                repeatDatePicker.CustomFormat = "MMMMd일";
            repeatCategory.Enabled = false;
            repeatViewButton.Enabled = true;

            repeatRangePicker1.Value = temp.startDay;
            repeatRangePicker2.Value = temp.endDay;

            userMemoTextBox.Text = temp.userMemo;

            todoViewButton.Enabled = true;
            applyButton.Enabled = true;
        }

        private void repeatAddButton_Click(object sender, EventArgs e)
        {
            errorLabel.Text = string.Empty;
            applyButton.Enabled = true;

            repeatList.Add(new RepeatTime(-1)
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
            RepeatListForm rForm = new RepeatListForm(repeatList, repeatCategory.SelectedIndex);
            DialogResult dResult = rForm.ShowDialog();

            if (dResult == DialogResult.OK)
            {
                repeatList = rForm.RepeatTimes;
            }
        }

        private void todoAddButton_Click(object sender, EventArgs e)
        {
            toDoList.Add(new ToDo(-1, todoCategory.SelectedItem.ToString())
            {
                name = todoNameTextBox.Text,
                deadLine = todoDeadlinePicker.Value.Date,
                deadLineHour = int.Parse(todoDeadlineHH.SelectedItem.ToString()),
                deadLineMinute = int.Parse(todoDeadlineMM.SelectedItem.ToString()),
                userMemo = todoUserMemo.Text,
            });
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RepeatListForm rForm = new RepeatListForm(toDoList);
            DialogResult dResult = rForm.ShowDialog();

            if (dResult == DialogResult.OK)
            {
                toDoList = rForm.ToDoList;
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
            if (!repeatValueCheck())
            {
                applyButton.Enabled = false;
                repeatAddButton.Enabled = false;
                return;
            }

            if (!repeatTimeCheck())
            {
                applyButton.Enabled = false;
                repeatAddButton.Enabled = false;
                errorLabel.Text = "시간 설정 오류";
                return;
            }

            if (nameTextBox.Text == string.Empty)
            {
                applyButton.Enabled = false;
                errorLabel.Text = "이름 없음";
            }

            
            applyButton.Enabled = true;
            repeatAddButton.Enabled = true;
        }

        private void todoValueChanged(object sender, EventArgs e)
        {
            if (todoNameTextBox.Text == string.Empty)
            {
                todoAddButton.Enabled = false;
                todoErrorLabel.Text = "이름 없음";
                return;
            }
            if (!todoValueCheck())
            {
                todoAddButton.Enabled = false;
                return;
            }
            if (!todoTimeCheck())
            {
                todoErrorLabel.Text = "시간 설정 오류";
                todoAddButton.Enabled = false;
                return;
            }
            todoAddButton.Enabled = true;
        }

        private bool repeatValueCheck()
        {
            return repeatHH1.SelectedIndex != -1
                && repeatMM1.SelectedIndex != -1
                && repeatHH2.SelectedIndex != -1
                && repeatMM2.SelectedIndex != -1;
        }

        private bool todoValueCheck()
        {
            return todoDeadlineHH.SelectedIndex != -1
                && todoDeadlineMM.SelectedIndex != -1;
        }

        private bool repeatTimeCheck()
        {
            DateTime datePartStart = repeatRangePicker1.Value.Date;
            DateTime datePartEnd = repeatRangePicker2.Value.Date;
            TimeSpan timePart1 = new TimeSpan(int.Parse(repeatHH1.SelectedItem.ToString()), int.Parse(repeatMM1.SelectedItem.ToString()), 0);
            TimeSpan timePart2 = new TimeSpan(int.Parse(repeatHH2.SelectedItem.ToString()), int.Parse(repeatMM2.SelectedItem.ToString()), 0);

            if (DateTime.Compare(datePartStart, datePartEnd) != -1) return false;

            if (DateTime.Compare(datePartEnd, DateTime.Now) != 1) return false;

            if (DateTime.Compare(datePartEnd.Add(timePart1), datePartEnd.Add(timePart2)) != -1) return false;

            errorLabel.Text = string.Empty;
            return true;
        }

        private bool todoTimeCheck()
        {
            DateTime datePartStart = repeatRangePicker1.Value.Date;
            DateTime datePartEnd = repeatRangePicker2.Value.Date;
            DateTime datePart = todoDeadlinePicker.Value.Date;

            if (DateTime.Compare(datePartStart, datePartEnd) == 1) return false;

            if (DateTime.Compare(datePartStart, datePart) == 1) return false;

            if (DateTime.Compare(datePartEnd, datePart) == -1) return false;

            todoErrorLabel.Text = string.Empty;
            return true;
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nameTextBox.Text))
            {
                applyButton.Enabled = false;
                errorLabel.Text = "이름 없음";
                return;
            }
            errorLabel.Text = string.Empty;
        }

        private void todoNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(todoNameTextBox.Text))
            {
                todoAddButton.Enabled = false;
                todoErrorLabel.Text = "이름 없음";
                return;
            }
            todoErrorLabel.Text = string.Empty;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            ClassSchedule temp = new ClassSchedule(repeatCategory.SelectedIndex);

            temp.name = nameTextBox.Text;
            temp.startDay = repeatRangePicker1.Value.Date;
            temp.endDay = repeatRangePicker2.Value.Date;
            temp.userMemo = userMemoTextBox.Text;

            foreach (RepeatTime rtemp in repeatList)
            {
                temp.repeatList.Add(new RepeatTime(temp.createRepeatTimeId())
                {
                    date = rtemp.date,
                    startHour = rtemp.startHour,
                    startMinute = rtemp.startMinute,
                    endHour = rtemp.endHour,
                    endMinute = rtemp.endMinute
                });
            }

            foreach (ToDo rtemp in toDoList)
            {
                temp.todoList.Add(new ToDo(temp.createToDoId(), rtemp.type)
                {
                    name = rtemp.name,
                    deadLine = rtemp.deadLine,
                    deadLineHour = rtemp.deadLineHour,
                    deadLineMinute = rtemp.deadLineMinute,
                    userMemo = rtemp.userMemo,
                });
            }

            if (index == -1) { ScheduleList.list.Add(temp); }
            else { ScheduleList.list[index] = temp; }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
