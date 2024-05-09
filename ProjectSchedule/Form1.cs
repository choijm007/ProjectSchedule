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
    public class ScheduleList
    {
        public static List<Schedule> list = new List<Schedule>();
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // 00시부터 24시까지 표시하는 Lable 생성
            for (int i = 0; i < 25; i++)
            {
                Label newLabel = new Label();
                string labelText = "";

                if (i < 10)
                {
                    labelText = "0";
                }
                labelText += i.ToString();

                newLabel.Text = labelText;
                newLabel.Location = new Point(11, 58 + 24 * i); // 레이블의 위치 설정

                this.Controls.Add(newLabel); // 폼에 레이블 추가
            }
        }


        private void addEditButton_Click(object sender, EventArgs e)
        {
            AddEditForm aeForm = new AddEditForm();
            DialogResult dResult = aeForm.ShowDialog();
        }

        private void klasButton_Click(object sender, EventArgs e)
        {
            GetSubject subject = new GetSubject();

            subject.ShowDialog();
        }
    }
}
