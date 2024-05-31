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
    public partial class CurPanel : UserControl
    {
        public List<PictureBox> weatherList;
        public List<Label> labelList;

        public CurPanel()
        {
            InitializeComponent();
            InitList();
        }

        private void InitList()
        {
            weatherList = new List<PictureBox>();
            labelList = new List<Label>();

            weatherList.Add(pbCur);
            labelList.Add(lbTemp);
            labelList.Add(lbWeather);
            labelList.Add(lbPM10);
            labelList.Add(lbPM25);
            labelList.Add(lbPMTime);
        }
    }
}
