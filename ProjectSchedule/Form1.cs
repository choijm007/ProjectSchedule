using ProjectSchedule.Weather;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Animation;
using System.Windows.Shell;
using System.Xml;

namespace ProjectSchedule
{
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

            InitList(); // 리스트 초기화
            
        }

        private void update()
        {
            // update() 함수에서 추가한 schedule 레이블만 삭제
            for (int i = this.Controls.Count - 1; i >= 0; i--)
            {
                if (this.Controls[i] is Label && this.Controls[i].Name.StartsWith("scheduleLabel_"))
                {
                    this.Controls.RemoveAt(i);
                }
            }

            // 현재 날짜 기준 월요일과 일요일의 날짜 정보 얻기
            DateTime today = DateTime.Today;
            int diff = (7 + (today.DayOfWeek - DayOfWeek.Monday)) % 7;
            DateTime startOfWeek = today.AddDays(-1 * diff);
            DateTime endOfWeek = startOfWeek.AddDays(6);


            // 이번 주에 있는 일정들 탐색
            List<ForDisplay> schedulesThisWeek = new List<ForDisplay>();
            for (int i = 0; i < ScheduleList.list.Count; i++)
            {
                if (ScheduleList.list[i] is Alarm )
                {
                    Alarm temp = ScheduleList.list[i] as Alarm;
                    if ((DateTime.Compare(temp.startDay.Date, startOfWeek.Date) != -1) && (DateTime.Compare(temp.startDay.Date, endOfWeek.Date) != 1))
                    {
                        schedulesThisWeek.Add(new ForDisplay(temp));
                    }
                }
                else if (ScheduleList.list[i] is Appointment)
                {
                    Appointment temp = ScheduleList.list[i] as Appointment;
                    if ((DateTime.Compare(temp.startDay.Date, startOfWeek.Date) != -1) && (DateTime.Compare(temp.startDay.Date, endOfWeek.Date) != 1))
                    {
                        schedulesThisWeek.Add(new ForDisplay(temp));
                    }
                }
                else if (ScheduleList.list[i] is RepeatSchedule)
                {
                    RepeatSchedule temp = ScheduleList.list[i] as RepeatSchedule;
                    for (DateTime date = startOfWeek; date <= endOfWeek; date = date.AddDays(1))
                    {
                        if ((DateTime.Compare(date, temp.startDay) == -1) || (DateTime.Compare(date, temp.endDay) == 1)) { continue; }

                        foreach (RepeatTime rt in temp.getRepeatTimeByDay(date)) { schedulesThisWeek.Add(new ForDisplay(rt, temp, date)); }
                    }
                }
                else // 수업
                {
                    ClassSchedule temp = ScheduleList.list[i] as ClassSchedule;
                    for (DateTime date = startOfWeek; date <= endOfWeek; date = date.AddDays(1))
                    {
                        if ((DateTime.Compare(date, temp.startDay) == -1) || (DateTime.Compare(date, temp.endDay) == 1)) { continue; }

                        foreach (RepeatTime rt in temp.getRepeatTimeByDay(date)) { schedulesThisWeek.Add(new ForDisplay(rt, temp, date)); }
                        foreach (ToDo td in temp.getTodoByDay(date)) { schedulesThisWeek.Add(new ForDisplay(td, temp)); }
                    }
                }
            }

            // 요일별로 일정을 화면에 추가
            foreach (ForDisplay fd in schedulesThisWeek)
            {
                addLabel(fd);
            }
        }

        private void addLabel(ForDisplay fd)
        {
            Label scheduleLabel = new Label();
            scheduleLabel.Text = fd.displayText;
            scheduleLabel.Location = new Point(dayToPosition(DateTime.Parse(fd.startDay).DayOfWeek), timeToPosition(fd.getStartTimeToInt())); // 레이블의 위치 설정

            if (fd.getEndTimeToInt() == null)
            {
                scheduleLabel.Size = new Size(87, 100);
            }
            else
            {
                scheduleLabel.Size = new Size(87, timeToPosition(fd.getEndTimeToInt()) - timeToPosition(fd.getStartTimeToInt())); // 레이블의 크기 설정
            }

            scheduleLabel.BackColor = Color.White;

            // schedule 표시하는 레이블 구분용
            scheduleLabel.Name = "scheduleLabel_" + fd.GetHashCode();

            this.Controls.Add(scheduleLabel); // 폼에 레이블 추가
            this.Controls.SetChildIndex(scheduleLabel, 0);
        }

        private void addEditButton_Click(object sender, EventArgs e)
        {
            AddEditForm aeForm = new AddEditForm();
            DialogResult dResult = aeForm.ShowDialog();
            update();
        }

        private void klasButton_Click(object sender, EventArgs e)
        {
            GetSubject subject = new GetSubject();

            subject.ShowDialog();
        }

        #region Weather 변수
        public static bool isWeatherOpen = false; // 날씨 창 하나만 열리게 하기
        string url = string.Empty;
        Thread getWeatherAPI;
        static DateTime weatherDate;
        // 단기예보
        static List<List<string>> weatherInfo1; // 오늘
        static List<List<string>> weatherInfo2; // 내일
        static List<List<string>> weatherInfo3; // 모레
        // 중기예보
        static List<string> midRain;
        static List<string> midWeather;
        static List<string> midTemp;
        #endregion

        private void btOpenWeatherForm_Click(object sender, EventArgs e)
        {
            if(isWeatherOpen == false)
            {
                isWeatherOpen = true;
                Weather.WeatherForm weatherForm = new Weather.WeatherForm();
                weatherForm.Show();
            }            
        }

        private void InitList()
        {
            weatherInfo1 = new List<List<string>>();
            weatherInfo2 = new List<List<string>>();
            weatherInfo3 = new List<List<string>>();
            midRain = new List<string>();
            midWeather = new List<string>();
            midTemp = new List<string>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            getWeatherAPI = new Thread(getAPI);
            getWeatherAPI.Start();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (getWeatherAPI.IsAlive)
            {
                getWeatherAPI.Abort();
            }
        }

        public void getAPI()
        {
            weatherDate = DateTime.Now;
            getVilageFcst();
            getMidFcst();

            btOpenWeatherForm.Invoke(new MethodInvoker(delegate
            {
                btOpenWeatherForm.Enabled = true;
            }));
            Thread.Sleep(100);
            progressBarLoadAPI.Invoke(new MethodInvoker(delegate
            {
                progressBarLoadAPI.Visible = false;
            }));
        }

        private void getVilageFcst() // 단기예보
        {
            while (true) // 단기예보조회
            {
                url = "http://apis.data.go.kr/1360000/VilageFcstInfoService_2.0/getVilageFcst";
                url += "?ServiceKey=" + "p6DmSuJ8xqCPAMgABBFMeYCk%2BmC%2FmibL769%2FJOalQ0GwVG3DQaGjIglUEgWhh5OEKc%2BLnKVV2XtrnBj3i08CvA%3D%3D";
                url += "&numOfRows=1000";
                url += "&pageNo=1";
                url += "&dataType=XML";
                url += "&base_date=" + weatherDate.AddDays(-1).ToString("yyyyMMdd");
                url += "&base_time=2300";
                url += "&nx=61"; // 서울특별시 노원구 월계동 좌표
                url += "&ny=128";

                XmlDocument xml;
                XmlNode header;
                do
                {
                    var request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = "GET";

                    string results = string.Empty;
                    HttpWebResponse response;
                    using (response = request.GetResponse() as HttpWebResponse)
                    {
                        StreamReader reader = new StreamReader(response.GetResponseStream());
                        results = reader.ReadToEnd();
                    }

                    xml = new XmlDocument();
                    xml.LoadXml(results);
                    header = xml.SelectSingleNode("response/header");
                } while (header == null);

                if (header.ChildNodes[0].InnerText == "00")
                {
                    XmlNode body = xml.SelectSingleNode("response/body/items");

                    foreach (XmlNode node in body.ChildNodes)
                    {
                        if (node["fcstDate"].InnerText == weatherDate.ToString("yyyyMMdd"))
                        { // 오늘 날씨
                            int time = int.Parse(node["fcstTime"].InnerText.Substring(0, 2));
                            if (weatherInfo1.Count < time + 1)
                            {
                                weatherInfo1.Add(new List<string>());
                            }
                            weatherInfo1[time].Add(node["fcstValue"].InnerText);
                        }
                        else if (node["fcstDate"].InnerText == weatherDate.AddDays(1).ToString("yyyyMMdd"))
                        { // 내일 날씨
                            int time = int.Parse(node["fcstTime"].InnerText.Substring(0, 2));
                            if (weatherInfo2.Count < time + 1)
                            {
                                weatherInfo2.Add(new List<string>());
                            }
                            weatherInfo2[time].Add(node["fcstValue"].InnerText);
                        }
                        else if (node["fcstDate"].InnerText == weatherDate.AddDays(2).ToString("yyyyMMdd"))
                        { // 모레 날씨
                            int time = int.Parse(node["fcstTime"].InnerText.Substring(0, 2));
                            if (weatherInfo3.Count < time + 1)
                            {
                                weatherInfo3.Add(new List<string>());
                            }
                            weatherInfo3[time].Add(node["fcstValue"].InnerText);
                        }
                    }
                    break;
                }
                else
                {
                    MessageBox.Show("에러 코드 : " + header.ChildNodes[0].InnerText + '\n' + header.ChildNodes[1].InnerText,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            progressBarLoadAPI.Invoke(new MethodInvoker(delegate
            {
                progressBarLoadAPI.Value++;
            }));
        }

        private void getMidFcst() // 중기예보
        {
            while (true) // 중기육상예보조회
            {
                url = "http://apis.data.go.kr/1360000/MidFcstInfoService/getMidLandFcst";
                url += "?ServiceKey=" + "p6DmSuJ8xqCPAMgABBFMeYCk%2BmC%2FmibL769%2FJOalQ0GwVG3DQaGjIglUEgWhh5OEKc%2BLnKVV2XtrnBj3i08CvA%3D%3D";
                url += "&numOfRows=1000";
                url += "&pageNo=1";
                url += "&dataType=XML";
                url += "&regId=11B00000"; // 서울, 인천, 경기도
                if (weatherDate.Hour < 6)
                {
                    url += "&tmFc=" + weatherDate.AddDays(-1).ToString("yyyyMMdd") + "0600";
                }
                else
                {
                    url += "&tmFc=" + weatherDate.ToString("yyyyMMdd") + "0600";
                }

                XmlDocument xml;
                XmlNode header;
                do
                {
                    var request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = "GET";

                    string results = string.Empty;
                    HttpWebResponse response;
                    using (response = request.GetResponse() as HttpWebResponse)
                    {
                        StreamReader reader = new StreamReader(response.GetResponseStream());
                        results = reader.ReadToEnd();
                    }

                    xml = new XmlDocument();
                    xml.LoadXml(results);
                    header = xml.SelectSingleNode("response/header");
                } while (header == null);

                if (header.ChildNodes[0].InnerText == "00")
                {
                    XmlNode body = xml.SelectSingleNode("response/body/items/item");
                    XmlNodeList node = body.ChildNodes;

                    for (int i = 0; i < 13; i++)
                    {
                        midRain.Add(node[i + 1].InnerText);
                        midWeather.Add(node[i + 14].InnerText);
                    }
                    break;
                }
                else
                {
                    MessageBox.Show("에러 코드 : " + header.ChildNodes[0].InnerText + '\n' + header.ChildNodes[1].InnerText,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            progressBarLoadAPI.Invoke(new MethodInvoker(delegate
            {
                progressBarLoadAPI.Value++;
            }));

            while (true)
            {
                // 중기기온조회
                url = "http://apis.data.go.kr/1360000/MidFcstInfoService/getMidTa";
                url += "?ServiceKey=" + "p6DmSuJ8xqCPAMgABBFMeYCk%2BmC%2FmibL769%2FJOalQ0GwVG3DQaGjIglUEgWhh5OEKc%2BLnKVV2XtrnBj3i08CvA%3D%3D";
                url += "&numOfRows=1000";
                url += "&pageNo=1";
                url += "&dataType=XML";
                url += "&regId=11B10101"; // 서울
                if (weatherDate.Hour < 6)
                {
                    url += "&tmFc=" + weatherDate.AddDays(-1).ToString("yyyyMMdd") + "0600";
                }
                else
                {
                    url += "&tmFc=" + weatherDate.ToString("yyyyMMdd") + "0600";
                }

                XmlDocument xml;
                XmlNode header;
                do
                {
                    var request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = "GET";

                    string results = string.Empty;
                    HttpWebResponse response;
                    using (response = request.GetResponse() as HttpWebResponse)
                    {
                        StreamReader reader = new StreamReader(response.GetResponseStream());
                        results = reader.ReadToEnd();
                    }

                    xml = new XmlDocument();
                    xml.LoadXml(results);
                    header = xml.SelectSingleNode("response/header");
                } while (header == null);

                if (header.ChildNodes[0].InnerText == "00")
                {
                    XmlNode body = xml.SelectSingleNode("response/body/items/item");
                    XmlNodeList node = body.ChildNodes;

                    for (int i = 0; i < 16; i++)
                    {
                        midTemp.Add(node[i * 3 + 1].InnerText);
                    }
                    break;
                }
                else
                {
                    MessageBox.Show("에러 코드 : " + header.ChildNodes[0].InnerText + '\n' + header.ChildNodes[1].InnerText,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            progressBarLoadAPI.Invoke(new MethodInvoker(delegate
            {
                progressBarLoadAPI.Value++;
            }));
        }

        #region 변수 반환 함수
        public static DateTime getWeatherDate()
        {
            return weatherDate;
        }

        public static List<List<string>> getWeatherInfo1()
        {
            return weatherInfo1;
        }

        public static List<List<string>> getWeatherInfo2()
        {
            return weatherInfo2;
        }

        public static List<List<string>> getWeatherInfo3()
        {
            return weatherInfo3;
        }

        public static List<string> getMidRain()
        {
            return midRain;
        }

        public static List<string> getMidWeather()
        {
            return midWeather;
        }

        public static List<string> getMidTemp()
        {
            return midTemp;
        }
        #endregion
    }

    public class ScheduleList
    {
        public static List<Schedule> list = new List<Schedule>();

        public static int getScheduleIndexById(int id)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].id == id) { return i; }
            }
            return -1;
        }

        public static int createNewId()
        {
            List<int> idList = new List<int>();
            int temp = 1;

            for (int i = 0; i < list.Count; i++)
            {
                idList.Add(list[i].id);
            }

            while (true)
            {
                if (!idList.Contains(temp)) { return temp; }
                temp++;
            }
        }
    }
}
