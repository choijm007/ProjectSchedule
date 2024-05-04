using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ProjectSchedule.Weather
{
    public partial class WeatherForm : Form
    {
        #region 변수
        string url = string.Empty;

        int alterRain = 50;
        readonly string[] windDir = { "↓", "↙", "↙", "↙", "←", "↖", "↖", "↖", "↑",
            "↗", "↗", "↗", "→", "↘", "↘", "↘", "↓" };
        readonly string[] windDirStr = { "북", "북북동", "북동", "동북동", "동", "동남동", "남동", "남남동", "남",
            "남남서", "남서", "서남서", "서", "서북서", "북서", "북북서", "북" };
        //string[] windDir = { "N", "NNE", "NE", "ENE", "E", "ESE", "SE", "SSE", "S", 
        //    "SSW", "SW", "WSW", "W", "WNW", "NW", "NNW", "N" };
        readonly string[] skyStat = { "", "맑음", "", "구름많음", "흐림" };
        readonly string[] rainStat = { "없음", "비", "비/눈", "눈", "소나기" };

        // 단기예보
        List<List<string>> weatherInfo1;
        List<List<string>> weatherInfo2;
        List<List<string>> weatherInfo3;
        // 중기예보
        List<string> midRain;
        List<string> midWeather;
        List<string> midTemp;
        #endregion

        public WeatherForm()
        {
            InitializeComponent();
            InitList();
        }

        private void WeatherForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1.isWeatherOpen = false;
        }

        private void InitList()
        {
            weatherInfo1 = Form1.getWeatherInfo1();
            weatherInfo2 = Form1.getWeatherInfo2();
            weatherInfo3 = Form1.getWeatherInfo3();
            midRain = Form1.getMidRain();
            midWeather = Form1.getMidWeather();
            midTemp = Form1.getMidTemp();
        }

        private void WeatherForm_Load(object sender, EventArgs e)
        {
            Thread getWeatherInfo = new Thread(setAPI);
            getWeatherInfo.Start();
        }

        public void setAPI()
        {
            this.Invoke(new MethodInvoker(delegate
            {
                this.Cursor = Cursors.WaitCursor;
            }));

            setVilageFcst();
            setMidFcst();

            this.Invoke(new MethodInvoker(delegate
            {
                this.Cursor = Cursors.Default;
            }));
        }

        private void setVilageFcst() // 단기예보
        {
            Debug.Assert(panelWeather.tempList.Count == weatherInfo1.Count, "tempList 사이즈 다름");
            Debug.Assert(panelWeather.rainList.Count == weatherInfo1.Count, "rainList 사이즈 다름");
            Debug.Assert(panelWeather.windList.Count == weatherInfo1.Count, "windList 사이즈 다름");

            // 패널에 추가
            for (int i = 0; i < weatherInfo1.Count; i++)
            {
                panelWeather.Invoke(new MethodInvoker(delegate
                {
                    panelWeather.tempList[i].Text = weatherInfo1[i][0];
                    panelWeather.rainList[i].Text = weatherInfo1[i][7];
                    if (int.Parse(weatherInfo1[i][7]) >= alterRain) // 강수 확률 일정값 이상이면 빨간 글씨
                    {
                        panelWeather.rainList[i].ForeColor = Color.Red;
                    }
                    else
                    {
                        panelWeather.rainList[i].ForeColor = Color.Black;
                    }

                    int dirInt = (int)Math.Truncate((int.Parse(weatherInfo1[i][3]) + 22.5 * 0.5) / 22.5);
                    panelWeather.windList[i].Text = weatherInfo1[i][4] + "\n" + windDir[dirInt];
                    panelWeather.windList[i].Tag = windDirStr[dirInt];

                    int sky = int.Parse(weatherInfo1[i][5]);
                    int rain = int.Parse(weatherInfo1[i][6]);
                    string weatherImageTag = string.Empty;
                    Bitmap weatherImageResult = null;

                    // 날씨 이미지 선택
                    switch (sky)
                    {
                        case 1: // 맑음
                            switch (rain)
                            {
                                case 0:
                                    if (i >= 6 && i <= 18)
                                        weatherImageResult = Properties.Resources.맑음;
                                    else
                                        weatherImageResult = Properties.Resources.맑음_밤_;
                                    weatherImageTag = "맑음";
                                    break;
                                case 1:
                                case 4:
                                    weatherImageResult = Properties.Resources.흐리고_비;
                                    weatherImageTag = "비";
                                    break;
                                case 2:
                                    weatherImageResult = Properties.Resources.흐리고_비눈;
                                    weatherImageTag = "비, 눈";
                                    break;
                                case 3:
                                    weatherImageResult = Properties.Resources.흐리고_눈;
                                    weatherImageTag = "눈";
                                    break;
                            }
                            break;
                        case 3: // 구름많음
                            switch (rain)
                            {
                                case 0:
                                    if (i >= 6 && i <= 18)
                                        weatherImageResult = Properties.Resources.구름많음;
                                    else
                                        weatherImageResult = Properties.Resources.구름많음_밤_;
                                    weatherImageTag = "구름많음";
                                    break;
                                case 1:
                                case 4:
                                    weatherImageResult = Properties.Resources.구름많고_비;
                                    weatherImageTag = "구름많고 비";
                                    break;
                                case 2:
                                    weatherImageResult = Properties.Resources.구름많고_비눈;
                                    weatherImageTag = "구름많고 비, 눈";
                                    break;
                                case 3:
                                    weatherImageResult = Properties.Resources.구름많고_눈;
                                    weatherImageTag = "구름많고 눈";
                                    break;
                            }
                            break;
                        case 4: // 흐림
                            switch (rain)
                            {
                                case 0:
                                    weatherImageResult = Properties.Resources.흐림;
                                    weatherImageTag = "흐림";
                                    break;
                                case 1:
                                case 4:
                                    weatherImageResult = Properties.Resources.흐리고_비;
                                    weatherImageTag = "흐리고 비";
                                    break;
                                case 2:
                                    weatherImageResult = Properties.Resources.흐리고_비눈;
                                    weatherImageTag = "흐리고 비, 눈";
                                    break;
                                case 3:
                                    weatherImageResult = Properties.Resources.흐리고_눈;
                                    weatherImageTag = "흐리고 눈";
                                    break;
                            }
                            break;
                    }
                    Debug.Assert(weatherImageResult != null, "날씨 이미지 오류");
                    Debug.Assert(weatherImageTag != string.Empty, "태그 오류");

                    panelWeather.weatherList[i].Image = weatherImageResult;
                    panelWeather.weatherList[i].Tag = weatherImageTag;
                }));
            }
        }

        private void setMidFcst() // 중기예보
        {
           // 정보 표시
        }
    }
}
