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
    public partial class WeatherPanel : UserControl
    {
        public List<Label> timeList;
        public List<PictureBox> weatherList;
        public List<Label> tempList;
        public List<Label> rainList;
        public List<Label> windList;

        public WeatherPanel()
        {
            InitializeComponent();
            InitList();
        }

        private void InitList()
        {
            timeList = new List<Label>();
            weatherList = new List<PictureBox>();
            tempList = new List<Label>();
            rainList = new List<Label>();
            windList = new List<Label>();

            for (int i = 0; i < 24; i++)
            {
                Label newTime = new Label();
                newTime.Name = "lbToday" + i.ToString();
                newTime.Text = i.ToString() + "시";
                newTime.TextAlign = ContentAlignment.MiddleCenter;
                if (i < 10)
                {
                    newTime.Location = new Point(i * 40 + 5 + 68, 2);
                    newTime.Size = new Size(33, 18);
                }
                else
                {
                    newTime.Location = new Point(i * 40 - 1 + 68, 2);
                    newTime.Size = new Size(43, 18);
                }
                timeList.Add(newTime);
                this.Controls.Add(newTime);

                PictureBox newWeather = new PictureBox();
                newWeather.Name = "bpToday" + i.ToString();
                newWeather.Location = new Point(i * 40 + 68, 20);
                newWeather.Size = new Size(40, 40);
                newWeather.SizeMode = PictureBoxSizeMode.Zoom;
                //newWeather.Image = Properties.Resources.맑음;
                newWeather.MouseMove += control_MouseMove;
                newWeather.Tag = "";
                weatherList.Add(newWeather);
                this.Controls.Add(newWeather);

                Label newTemp = new Label();
                newTemp.Name = "lbTemp" + i.ToString();
                newTemp.Text = "-";
                newTemp.TextAlign = ContentAlignment.MiddleCenter;
                newTemp.Size = new Size(40, 20);
                newTemp.AutoSize = false;
                newTemp.Location = new Point(i * 40 + 70, 72);
                tempList.Add(newTemp);
                this.Controls.Add(newTemp);

                Label newRain = new Label();
                newRain.Name = "lbRain" + i.ToString();
                newRain.Text = "-";
                newRain.TextAlign = ContentAlignment.MiddleCenter;
                newRain.Size = new Size(40, 20);
                newRain.AutoSize = false;
                newRain.Location = new Point(i * 40 + 70, 112);
                rainList.Add(newRain);
                this.Controls.Add(newRain);

                Label newWind = new Label();
                newWind.Name = "lbWind" + i.ToString();
                newWind.Text = "-";
                newWind.TextAlign = ContentAlignment.MiddleCenter;
                newWind.Size = new Size(40, 40);
                newWind.AutoSize = false;
                newWind.Location = new Point(i * 40 + 70, 142);
                newWind.MouseMove += control_MouseMove;
                newWind.Tag = "";
                windList.Add(newWind);
                this.Controls.Add(newWind);
            }
        }

        private void control_MouseMove(object sender, MouseEventArgs e)
        {
            Control control = sender as Control;
            tooltip.SetToolTip(control, control.Tag.ToString());
        }
    }
}
