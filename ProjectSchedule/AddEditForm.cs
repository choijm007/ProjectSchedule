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
    public partial class AddEditForm : Form
    {
        public AddEditForm()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddForm aForm = new AddForm();
            DialogResult dResult = aForm.ShowDialog();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            // 수정하고자 하는 일정이 수업일 경우 AddClassForm 을 열도록 수정할 예정
            AddForm aForm = new AddForm();
            DialogResult dResult = aForm.ShowDialog();
        }

        private void addClassButton_Click(object sender, EventArgs e)
        {
            ClassAddForm cForm = new ClassAddForm();
            DialogResult dResult = cForm.ShowDialog();
        }
    }
}
