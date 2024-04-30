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
    }
}
