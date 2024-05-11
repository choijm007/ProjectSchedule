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
    public partial class RepeatListForm : Form
    {
        public List<RepeatTime> RepeatTimes;
        public List<ToDo> ToDoList;
        public readonly string type;

        public RepeatListForm()
        {
            InitializeComponent();
        }

        public RepeatListForm(List<RepeatTime> repeats, int type)
        {
            InitializeComponent();
            RepeatTimes = repeats;
            if (type == 0) { this.type = "매주"; }
            else if (type == 1) { this.type = "매달"; }
            else if (type == 2) { this.type = "매년"; }

            showDisplay(RepeatTimes);
        }

        public RepeatListForm(List<ToDo> toDo, int type)
        {
            InitializeComponent();
            ToDoList = toDo;
            if (type == 0) { this.type = "매주"; }
            else if (type == 1) { this.type = "매달"; }
            else if (type == 2) { this.type = "매년"; }

            showDisplay(ToDoList);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int temp = listBox1.SelectedIndex;

            if (RepeatTimes == null)
            {
                ToDoList.RemoveAt(temp);
                showDisplay(ToDoList);
            }
            else
            {
                RepeatTimes.RemoveAt(temp);
                showDisplay(RepeatTimes);
            }
        }

        private void showDisplay(List<RepeatTime> list)
        {
            listBox1.Items.Clear();

            if (type == "매주")
            {
                foreach (RepeatTime temp in list)
                {
                    listBox1.Items.Add($"매주 {temp.date.DayOfWeek} {temp.startHour}:{temp.startMinute}" +
                        $"~ {temp.endHour}:{temp.endMinute}");
                }
            }
            else if (type == "매달")
            {
                foreach (RepeatTime temp in list)
                {
                    listBox1.Items.Add($"매달 {temp.date.Day}일 {temp.startHour}:{temp.startMinute}" +
                        $"~ {temp.endHour}:{temp.endMinute}");
                }
            }
            else if (type == "매년")
            {
                foreach (RepeatTime temp in list)
                {
                    listBox1.Items.Add($"매년 {temp.date.Month}월 {temp.date.Day}일 " +
                        $"{temp.startHour}:{temp.startMinute}" +
                        $"~ {temp.endHour}:{temp.endMinute}");
                }
            }
            
        }
        private void showDisplay(List<ToDo> list)
        {

        }
    }
}
