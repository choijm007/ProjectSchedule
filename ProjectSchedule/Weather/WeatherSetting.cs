using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectSchedule.Weather
{
    public partial class WeatherSetting : Form
    {
        public WeatherSetting()
        {
            InitializeComponent();
            this.ActiveControl = updownAlert;
        }

        private void WeatherSetting_Load(object sender, EventArgs e)
        {
            updownAlert.Value = Form1.alterRain;
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            int oldAlert = Form1.alterRain;
            int curAlert = decimal.ToInt32(updownAlert.Value);
            if (oldAlert != curAlert)
            {
                Form1.alterRain = curAlert;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
