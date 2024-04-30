﻿using System;
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
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MMMMd일 dddd";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RepeatListForm rForm = new RepeatListForm();
            DialogResult dResult = rForm.ShowDialog();
        }
    }
}
