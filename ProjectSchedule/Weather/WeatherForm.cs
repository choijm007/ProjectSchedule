using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
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
        readonly string[] windDir = { "↓", "↙", "↙", "↙", "←", "↖", "↖", "↖", "↑",
            "↗", "↗", "↗", "→", "↘", "↘", "↘", "↓" };
        readonly string[] windDirStr = { "북", "북북동", "북동", "동북동", "동", "동남동", "남동", "남남동", "남",
            "남남서", "남서", "서남서", "서", "서북서", "북서", "북북서", "북" };
        readonly string[] dayofweek = { "일", "월", "화", "수", "목", "금", "토" };
        readonly string[] PMGrade = { "", "좋음", "보통", "나쁨", "매우나쁨" };

        DateTime weatherDate;
        // 단기예보
        List<List<string>> weatherInfo1;
        List<List<string>> weatherInfo2;
        List<List<string>> weatherInfo3;
        // 중기예보
        List<string> midRain;
        List<string> midWeather;
        List<string> midTemp;
        // 미세먼지
        List<string> PMInfo;
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
            weatherDate = Form1.getWeatherDate();
            weatherInfo1 = Form1.getWeatherInfo1();
            weatherInfo2 = Form1.getWeatherInfo2();
            weatherInfo3 = Form1.getWeatherInfo3();
            midRain = Form1.getMidRain();
            midWeather = Form1.getMidWeather();
            midTemp = Form1.getMidTemp();
            PMInfo = Form1.getPMInfo();
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
            lbToday.Invoke(new MethodInvoker(delegate
            {
                lbToday.Text += weatherDate.ToString(" yyyy.MM.dd");
                lbToday.Text += "(" + dayofweek[(int)weatherDate.DayOfWeek] + ")";
            }));

            setVilageFcst();
            setMidFcst();
            setPMFcst();

            this.Invoke(new MethodInvoker(delegate
            {
                this.Cursor = Cursors.Default;
            }));
        }

        private void setVilageFcst() // 단기예보
        {
            Debug.Assert(panelWeatherToday.tempList.Count == weatherInfo1.Count, "tempList 사이즈 다름");
            Debug.Assert(panelWeatherToday.rainList.Count == weatherInfo1.Count, "rainList 사이즈 다름");
            Debug.Assert(panelWeatherToday.windList.Count == weatherInfo1.Count, "windList 사이즈 다름");

            // 패널에 추가
            for (int i = 0; i < weatherInfo1.Count; i++)
            {
                panelWeatherToday.Invoke(new MethodInvoker(delegate
                {
                    panelWeatherToday.tempList[i].Text = weatherInfo1[i][0];
                    panelWeatherToday.rainList[i].Text = weatherInfo1[i][7];
                    
                    updateRainAlert(); // 강수 확률 일정값 이상이면 빨간 글씨

                    int dirInt = (int)Math.Truncate((int.Parse(weatherInfo1[i][3]) + 22.5 * 0.5) / 22.5);
                    panelWeatherToday.windList[i].Text = weatherInfo1[i][4] + "\n" + windDir[dirInt];
                    panelWeatherToday.windList[i].Tag = windDirStr[dirInt];

                    panelWeatherToday.weatherList[i] = selectTodayWeatherImg(panelWeatherToday.weatherList[i],
                        i, int.Parse(weatherInfo1[i][5]), int.Parse(weatherInfo1[i][6]));
                }));
            }
        }

        private void setMidFcst() // 중기예보
        {
            int[] mTemp = new int[4]; // 기온 - 내일 최대, 최소 / 모레 최대, 최소
            int[] mRain = new int[4]; // 강수 확률 - 내일 오전, 오후 / 모레 오전, 오후

            Debug.Assert(weatherInfo2.Count == 24, "setMidFcst - weatherInfo2 오류");
            Debug.Assert(weatherInfo3.Count == 24, "setMidFcst - weatherInfo3 오류");
            Debug.Assert(midTemp.Count == 16, "setMidFcst - 기온 오류");
            Debug.Assert(midRain.Count == 13, "setMidFcst - 강수확률 오류");
            Debug.Assert(midWeather.Count == 13, "setMidFcst - 날씨 오류");

            for (int i = 0; i < 7; i++) // 날짜, 요일 설정
            {
                panelWeatherWeek.Invoke(new MethodInvoker(delegate
                {
                    panelWeatherWeek.dayofweekList[i].Text = dayofweek[(int)weatherDate.AddDays(i + 1).DayOfWeek];
                    panelWeatherWeek.dayList[i].Text = weatherDate.AddDays(i + 1).ToString("M.d");
                }));
            }

            #region 내일, 모레 날씨에 대한 기온, 강수 확률의 최대, 최소값 구하기
            mTemp[0] = mTemp[1] = int.Parse(weatherInfo2[0][0]);
            for (int i = 0; i < weatherInfo2.Count; i++)
            {
                mTemp[0] = Math.Max(mTemp[0], int.Parse(weatherInfo2[i][0]));
                mTemp[1] = Math.Min(mTemp[1], int.Parse(weatherInfo2[i][0]));
            }
            mTemp[2] = mTemp[3] = int.Parse(weatherInfo3[0][0]);
            for (int i = 0; i < weatherInfo3.Count; i++)
            {
                mTemp[2] = Math.Max(mTemp[2], int.Parse(weatherInfo3[i][0]));
                mTemp[3] = Math.Min(mTemp[3], int.Parse(weatherInfo3[i][0]));
            }

            mRain[0] = int.Parse(weatherInfo2[0][7]);
            mRain[1] = int.Parse(weatherInfo2[12][7]);
            mRain[2] = int.Parse(weatherInfo3[0][7]);
            mRain[3] = int.Parse(weatherInfo3[12][7]);
            for (int i = 0; i < 12; i++)
            {
                mRain[0] = Math.Max(mRain[0], int.Parse(weatherInfo2[i][7]));
                mRain[1] = Math.Max(mRain[1], int.Parse(weatherInfo2[i + 12][7]));
                mRain[2] = Math.Max(mRain[2], int.Parse(weatherInfo3[i][7]));
                mRain[3] = Math.Max(mRain[3], int.Parse(weatherInfo3[i + 12][7]));
            }            
            #endregion

            panelWeatherWeek.Invoke(new MethodInvoker(delegate
            {
                for (int i = 0; i < 2; i++) // 내일, 모레 날씨
                {
                    panelWeatherWeek.tempMaxList[i].Text = mTemp[i * 2].ToString() + "°";
                    panelWeatherWeek.tempMinList[i].Text = mTemp[i * 2 + 1].ToString() + "°";

                    panelWeatherWeek.rainAMList[i].Text = mRain[i * 2].ToString() + "%";
                    panelWeatherWeek.rainPMList[i].Text = mRain[i * 2 + 1].ToString() + "%";
                }

                panelWeatherWeek.weatherAMList[0] = selectTodayWeatherImg(panelWeatherWeek.weatherAMList[0],
                    8, int.Parse(weatherInfo2[8][5]), int.Parse(weatherInfo2[8][6]));
                panelWeatherWeek.weatherPMList[0] = selectTodayWeatherImg(panelWeatherWeek.weatherPMList[0],
                    18, int.Parse(weatherInfo2[18][5]), int.Parse(weatherInfo2[18][6]));

                panelWeatherWeek.weatherAMList[1] = selectTodayWeatherImg(panelWeatherWeek.weatherAMList[1],
                    8, int.Parse(weatherInfo3[8][5]), int.Parse(weatherInfo3[8][6]));
                panelWeatherWeek.weatherPMList[1] = selectTodayWeatherImg(panelWeatherWeek.weatherPMList[1],
                    18, int.Parse(weatherInfo3[18][5]), int.Parse(weatherInfo3[18][6]));

                for (int i = 0; i < 5; i++) // 3일뒤 ~ 7일뒤 날씨
                {
                    panelWeatherWeek.tempMaxList[i + 2].Text = midTemp[i * 2 + 1] + "°";
                    panelWeatherWeek.tempMinList[i + 2].Text = midTemp[i * 2] + "°";

                    panelWeatherWeek.rainAMList[i + 2].Text = midRain[i * 2] + "%";
                    panelWeatherWeek.rainPMList[i + 2].Text = midRain[i * 2 + 1] + "%";

                    panelWeatherWeek.weatherAMList[i + 2].Image = selectWeekWeatherImg(midWeather[i * 2]);
                    panelWeatherWeek.weatherPMList[i + 2].Image = selectWeekWeatherImg(midWeather[i * 2 + 1]);
                    panelWeatherWeek.weatherAMList[i + 2].Tag = midWeather[i * 2];
                    panelWeatherWeek.weatherPMList[i + 2].Tag = midWeather[i * 2 + 1];
                }
            }));
        }

        private void setPMFcst() // 미세먼지
        {
            int curHour = DateTime.Now.Hour;

            panelWeatherCur.Invoke(new MethodInvoker(delegate
            {
                panelWeatherCur.weatherList[0] = selectTodayWeatherImg(panelWeatherCur.weatherList[0],
                curHour, int.Parse(weatherInfo1[curHour][5]), int.Parse(weatherInfo1[curHour][6]));
                panelWeatherCur.labelList[0].Text = weatherInfo1[curHour][0] + "°C";
                panelWeatherCur.labelList[1].Text = panelWeatherCur.weatherList[0].Tag.ToString();
                if (PMInfo[1] == "점검및교정")
                {
                    panelWeatherCur.labelList[2].Text = "미세먼지 정보를 불러올 수 없습니다.";
                }
                else
                {
                    panelWeatherCur.labelList[2].Text += PMInfo[2] + " (" + PMGrade[int.Parse(PMInfo[3])] + ")";
                }
                if (PMInfo[4] == "점검및교정")
                {
                    panelWeatherCur.labelList[3].Text = "초미세먼지 정보를 불러올 수 없습니다.";
                }
                else
                {
                    panelWeatherCur.labelList[3].Text += PMInfo[5] + " (" + PMGrade[int.Parse(PMInfo[6])] + ")";
                }
                panelWeatherCur.labelList[4].Text = "(" + PMInfo[0] + " 기준)";
            }));
        }

        private PictureBox selectTodayWeatherImg(PictureBox origin, int time, int sky, int rain)
        {
            string weatherImageTag = string.Empty;
            Bitmap weatherImageResult = null;

            // 날씨 이미지 선택
            switch (sky)
            {
                case 1: // 맑음
                    switch (rain)
                    {
                        case 0:
                            if (time >= 6 && time <= 18)
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
                            if (time >= 6 && time <= 18)
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

            origin.Image = weatherImageResult;
            origin.Tag = weatherImageTag;

            return origin;
        }

        private Bitmap selectWeekWeatherImg(string input)
        {
            Bitmap result = null;

            switch (input)
            {
                case "맑음":
                    result = Properties.Resources.맑음;
                    break;
                case "구름많음":
                    result = Properties.Resources.구름많음;
                    break;
                case "구름많고 비":
                case "구름많고 소나기":
                    result = Properties.Resources.구름많고_비;
                    break;
                case "구름많고 눈":
                    result = Properties.Resources.구름많고_눈;
                    break;
                case "구름많고 비/눈":
                    result = Properties.Resources.구름많고_비눈;
                    break;
                case "흐림":
                    result = Properties.Resources.흐림;
                    break;
                case "흐리고 비":
                case "흐리고 소나기":
                    result = Properties.Resources.흐리고_비;
                    break;
                case "흐리고 눈":
                    result = Properties.Resources.흐리고_눈;
                    break;
                case "흐리고 비/눈":
                    result = Properties.Resources.흐리고_비눈;
                    break;
            }

            Debug.Assert(result != null, "selectMidWeatherImg - 이미지 오류");
            return result;
        }

        public void updateRainAlert()
        {
            for (int i = 0; i < weatherInfo1.Count; i++)
            {
                if (int.Parse(weatherInfo1[i][7]) >= Form1.alterRain) // 강수 확률 일정값 이상이면 빨간 글씨
                {
                    panelWeatherToday.rainList[i].ForeColor = Color.Red;
                }
                else
                {
                    panelWeatherToday.rainList[i].ForeColor = Color.Black;
                }
                if (weatherInfo1[i][9] != "강수없음")
                {
                    panelWeatherToday.rainList[i].Tag = weatherInfo1[i][9];
                }
            }
        }
    }
}
