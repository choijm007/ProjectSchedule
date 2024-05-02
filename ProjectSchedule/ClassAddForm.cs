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
        public ClassAddForm()
        {
            InitializeComponent();

            repeatDatePicker.Format = DateTimePickerFormat.Custom;
            repeatDatePicker.CustomFormat = "MMMMd일 dddd";
            applyButton.Enabled = false;
            todoAddButton.Enabled = false;

            repeatEnableChange(false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RepeatListForm rForm = new RepeatListForm();
            DialogResult dResult = rForm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RepeatListForm rForm = new RepeatListForm();
            DialogResult dResult = rForm.ShowDialog();
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
    }
}
