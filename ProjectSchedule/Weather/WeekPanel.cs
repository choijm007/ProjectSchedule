using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Animation;
using System.Windows.Shell;

namespace ProjectSchedule.Weather
{
    public partial class WeekPanel : UserControl
    {
        public List<Label> dayofweekList;
        public List<Label> dayList;
        public List<PictureBox> weatherAMList;
        public List<PictureBox> weatherPMList;
        public List<Label> tempMaxList;
        public List<Label> tempMinList;
        public List<Label> rainAMList;
        public List<Label> rainPMList;

        public WeekPanel()
        {
            InitializeComponent();
            InitList();
        }

        private void InitList()
        {
            dayofweekList = new List<Label>();
            dayList = new List<Label>();
            weatherAMList = new List<PictureBox>();
            weatherPMList = new List<PictureBox>();
            tempMaxList = new List<Label>();
            tempMinList = new List<Label>();
            rainAMList = new List<Label>();
            rainPMList = new List<Label>();

            for (int i = 0; i < 7; i++)
            {
                Label newDayofweek = new Label();
                newDayofweek.Name = "lbDayofweek" + i.ToString();
                newDayofweek.Text = "월";
                newDayofweek.Font = new Font(Font.FontFamily, 12);
                newDayofweek.TextAlign = ContentAlignment.MiddleCenter;
                newDayofweek.Location = new Point(i * 100 + 141, 0);
                newDayofweek.AutoSize = false;
                newDayofweek.Size = new Size(20, 20);
                dayofweekList.Add(newDayofweek);
                this.Controls.Add(newDayofweek);

                Label newDay = new Label();
                newDay.Name = "lbDay" + i.ToString();
                newDay.Text = "12.31";
                newDay.Font = new Font(Font.FontFamily, 11);
                newDay.TextAlign = ContentAlignment.MiddleCenter;
                newDay.Location = new Point(i * 100 + 120, 20);
                newDay.AutoSize = false;
                newDay.Size = new Size(60, 20);
                dayList.Add(newDay);
                this.Controls.Add(newDay);

                PictureBox newWeatherAM = new PictureBox();
                newWeatherAM.Name = "bpWeatherAM" + i.ToString();
                newWeatherAM.Location = new Point(i * 100 + 110, 40);
                newWeatherAM.Size = new Size(40, 40);
                newWeatherAM.SizeMode = PictureBoxSizeMode.Zoom;
                newWeatherAM.Image = Properties.Resources.맑음;
                newWeatherAM.MouseMove += control_MouseMove;
                newWeatherAM.Tag = "";
                weatherAMList.Add(newWeatherAM);
                this.Controls.Add(newWeatherAM);

                PictureBox newWeatherPM = new PictureBox();
                newWeatherPM.Name = "bpWeatherPM" + i.ToString();
                newWeatherPM.Location = new Point(i * 100 + 150, 40);
                newWeatherPM.Size = new Size(40, 40);
                newWeatherPM.SizeMode = PictureBoxSizeMode.Zoom;
                newWeatherPM.Image = Properties.Resources.맑음;
                newWeatherPM.MouseMove += control_MouseMove;
                newWeatherPM.Tag = "";
                weatherPMList.Add(newWeatherPM);
                this.Controls.Add(newWeatherPM);

                Label newTempMax = new Label();
                newTempMax.Name = "lbTempMax" + i.ToString();
                newTempMax.Text = "-°";
                newTempMax.Font = new Font(Font.FontFamily, 12);
                newTempMax.TextAlign = ContentAlignment.MiddleCenter;
                newTempMax.Location = new Point(i * 100 + 110, 85);
                newTempMax.AutoSize = false;
                newTempMax.Size = new Size(40, 20);
                tempMaxList.Add(newTempMax);
                this.Controls.Add(newTempMax);

                Label newTempMin = new Label();
                newTempMin.Name = "lbTempMin" + i.ToString();
                newTempMin.Text = "-°";
                newTempMin.Font = new Font(Font.FontFamily, 12);
                newTempMin.TextAlign = ContentAlignment.MiddleCenter;
                newTempMin.Location = new Point(i * 100 + 150, 85);
                newTempMin.AutoSize = false;
                newTempMin.Size = new Size(40, 20);
                tempMinList.Add(newTempMin);
                this.Controls.Add(newTempMin);

                Label newRainAM = new Label();
                newRainAM.Name = "lbRainAM" + i.ToString();
                newRainAM.Text = "0%";
                newRainAM.Font = new Font(Font.FontFamily, 12);
                newRainAM.TextAlign = ContentAlignment.MiddleCenter;
                newRainAM.Location = new Point(i * 100 + 110, 110);
                newRainAM.AutoSize = false;
                newRainAM.Size = new Size(40, 20);
                rainAMList.Add(newRainAM);
                this.Controls.Add(newRainAM);

                Label newRainPM = new Label();
                newRainPM.Name = "lbRainPM" + i.ToString();
                newRainPM.Text = "0%";
                newRainPM.Font = new Font(Font.FontFamily, 12);
                newRainPM.TextAlign = ContentAlignment.MiddleCenter;
                newRainPM.Location = new Point(i * 100 + 150, 110);
                newRainPM.AutoSize = false;
                newRainPM.Size = new Size(40, 20);
                rainPMList.Add(newRainPM);
                this.Controls.Add(newRainPM);
            }
        }

        private void control_MouseMove(object sender, MouseEventArgs e)
        {
            Control control = sender as Control;
            tooltip.SetToolTip(control, control.Tag.ToString());
        }
    }
}
