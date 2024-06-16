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
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Shell;
using System.Xml;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace ProjectSchedule
{
    public partial class Form1 : Form
    {
        List<string> subjectName = new List<string>();
        List<string> subjectTime = new List<string>();
        List<string[]> CommitDay = new List<string[]>();
        List<int> KWUnivClassID = new List<int>();

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
            
            dayOfWeek = (DateTime.Now.DayOfWeek != 0) ? (int)DateTime.Now.DayOfWeek - 1 : 6;
            for (int i = 0; i < 24; i++) // 강우 경고 라벨 생성
            {
                Label newAlert = new Label();
                newAlert.Visible = false;
                newAlert.Dock = DockStyle.Right;
                //newAlert.AutoSize = false;
                newAlert.Margin = new Padding(0, 0, 0, 0);
                newAlert.Size = new Size(5, 23);
                newAlert.BackColor = Color.Red;
                newAlert.MouseMove += control_MouseMove;
                labelList.Add(newAlert);
                tableLayoutPanel1.Controls.Add(newAlert, dayOfWeek, i);

                //Label temp = new Label();
                //temp.Visible = true;
                //temp.Dock = DockStyle.Left;
                //temp.Margin = new Padding(0, 0, 0, 0);
                //temp.BackColor = Color.FromArgb(255, 192, 192);
                //tableLayoutPanel1.Controls.Add(temp, dayOfWeek, i);
            }
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
            Label alarmBar;
            scheduleLabel.Text = fd.displayText;
            scheduleLabel.Location = new Point(dayToPosition(DateTime.Parse(fd.startDay).DayOfWeek), timeToPosition(fd.getStartTimeToInt())); // 레이블의 위치 설정

            if (fd.getEndTimeToInt() == null)
            {
                scheduleLabel.Size = new Size(80, 50);
            }
            else
            {
                scheduleLabel.Size = new Size(80, timeToPosition(fd.getEndTimeToInt()) - timeToPosition(fd.getStartTimeToInt())); // 레이블의 크기 설정
            }

            if (fd.type == "알람")
            {
                scheduleLabel.BackColor = Color.FromArgb(247, 247, 247);
                scheduleLabel.Location = new Point(dayToPosition(DateTime.Parse(fd.startDay).DayOfWeek), timeToPosition(fd.getStartTimeToInt()) + 7);
                alarmBar = new Label();
                alarmBar.Text = string.Empty;
                alarmBar.Location = new Point(dayToPosition(DateTime.Parse(fd.startDay).DayOfWeek), timeToPosition(fd.getStartTimeToInt()));
                alarmBar.Size = new Size(80, 7);
                alarmBar.BackColor = Color.FromArgb(0, 255, 153);

                alarmBar.Name = "scheduleLabel_" + fd.type.GetHashCode();
                this.Controls.Add(alarmBar);
                this.Controls.SetChildIndex(alarmBar, 0);
            }
            if (fd.type == "반복성 일정")
            {
                scheduleLabel.BackColor = Color.FromArgb(255, 204, 204);
            }
            if (fd.type == "일회성 일정")
            {
                scheduleLabel.BackColor = Color.FromArgb(204, 204, 255);
            }
            if (fd.type == "수업")
            {
                scheduleLabel.BackColor = Color.FromArgb(255, 255, 153);
            }

            // schedule 표시하는 레이블 구분용
            scheduleLabel.Name = "scheduleLabel_" + fd.GetHashCode();

            scheduleLabel.MouseHover += MouseHoverEvent_ScheduleLabel;

            this.Controls.Add(scheduleLabel); // 폼에 레이블 추가
            this.Controls.SetChildIndex(scheduleLabel, 0);
        }

        private void MouseHoverEvent_ScheduleLabel(object sender, EventArgs e)
        {
            Label lb = sender as Label;
            ToolTip ttip = new ToolTip();
            ttip.SetToolTip(lb, lb.Text);
        }

        private void addEditButton_Click(object sender, EventArgs e)
        {
            AddEditForm aeForm = new AddEditForm();
            DialogResult dResult = aeForm.ShowDialog();
            update();
        }
        private void klas_changed(List<string> l1, List<string> l2, List<string[]> l3)
        {
            subjectName = l1;
            subjectTime = l2;
            CommitDay = l3;

            if(CommitDay.Count == 0)
            {
                textBox1.Text = "남아있는 과제가 없습니다.";
            }

            foreach (string[] s in CommitDay)
            {
                textBox1.Text += String.Join(" ", s);
                textBox1.Text += "\r\n\r\n";
            }

            DateTime today = DateTime.Today;
            DateTime startDate = new DateTime(today.Year, 3, 1);
            DateTime endDate = new DateTime(today.Year, 6, 21);


            if ((today >= startDate) && (today <= endDate)) { }
            else
            {
                startDate = new DateTime(today.Year, 9, 1);
                endDate = new DateTime(today.Year, 12, 20);
            }


            for (int i = 0; i < l1.Count; i++)
            {
                ClassSchedule classtemp = new ClassSchedule(0);

                classtemp.name = l1[i].Substring(0, l1[i].IndexOf(" ("));
                classtemp.startDay = startDate;
                classtemp.endDay = endDate;

                string pattern = @"[가-힣] \d+(,\d+)*교시";
                MatchCollection matches = Regex.Matches(l2[i], pattern);


                foreach (Match match in matches)
                {
                    DateTime dtemp;
                    List<int> rytl = new List<int>();
                    int[] stime = new int[]{ 0, 0 };
                    int[] etime = new int[]{ 24, 0 };
                    string stemp = match.Value;
                    if (stemp[0] == '월') { dtemp = new DateTime(2024, 6, 10); }
                    else if (stemp[0] == '화') { dtemp = new DateTime(2024, 6, 11); }
                    else if (stemp[0] == '수') { dtemp = new DateTime(2024, 6, 12); }
                    else if (stemp[0] == '목') { dtemp = new DateTime(2024, 6, 13); }
                    else { dtemp = new DateTime(2024, 6, 14); }

                    for (int j = 2; j < stemp.IndexOf("교시"); j++)
                    {
                        if (stemp[j] != ',') { rytl.Add(int.Parse(stemp[j].ToString())); }
                    }

                    // if (rytl.Count == 1) { rytl.Add(rytl[0] + 1); }

                    if (rytl[0] == 0) { stime[0] = 8; }
                    else if (rytl[0] == 1) { stime[0] = 9; }
                    else if (rytl[0] == 2) { stime[0] = 10; stime[1] = 30; }
                    else if (rytl[0] == 3) { stime[0] = 12; }
                    else if (rytl[0] == 4) { stime[0] = 13; stime[1] = 30; }
                    else if (rytl[0] == 5) { stime[0] = 15; }
                    else if (rytl[0] == 6) { stime[0] = 16; stime[1] = 30; }

                    if (rytl[rytl.Count - 1] == -7) { etime[0] = 8; }
                    else if (rytl[rytl.Count - 1] == 0) { etime[0] = 8; etime[1] = 45; }
                    else if (rytl[rytl.Count - 1] == 1) { etime[0] = 10; etime[1] = 15; }
                    else if (rytl[rytl.Count - 1] == 2) { etime[0] = 11; etime[1] = 45; }
                    else if (rytl[rytl.Count - 1] == 3) { etime[0] = 13; etime[1] = 15; }
                    else if (rytl[rytl.Count - 1] == 4) { etime[0] = 14; etime[1] = 45; }
                    else if (rytl[rytl.Count - 1] == 5) { etime[0] = 16; etime[1] = 15; }
                    else { etime[0] = 17; etime[1] = 45; }

                    classtemp.repeatList.Add(new RepeatTime(classtemp.createRepeatTimeId())
                    {
                        date = dtemp,
                        startHour = stime[0],
                        startMinute = stime[1],
                        endHour = etime[0],
                        endMinute = etime[1]
                    });
                }

                ScheduleList.list.Add(classtemp);

            }

            update();


            /*            foreach (string s in l1)
                            Console.WriteLine(s);

                        foreach (string s in l2)
                            Console.WriteLine(s);

                        foreach (string[] s in l3)
                            Console.WriteLine(string.Join(" ",s));*/
        }

        private void klasButton_Click(object sender, EventArgs e)
        {
            GetSubject subject = new GetSubject();


            subject.Changed += new GetSubject.SendListParents(klas_changed);
            subject.ShowDialog();
        }

        #region Weather 변수
        public static bool isWeatherOpen = false; // 날씨 창 하나만 열리게 하기
        bool[] isAPI = new bool[4];
        string[] errStr = new string[4];

        const int API_COUNT = 4;
        public static int alterRain = 50;
        string url = string.Empty;
        Thread getWeatherAPI;
        static DateTime weatherDate;
        int dayOfWeek;

        Weather.WeatherForm weatherForm;

        // 단기예보
        static List<List<string>> weatherInfo1; // 오늘
        static List<List<string>> weatherInfo2; // 내일
        static List<List<string>> weatherInfo3; // 모레
        // 중기예보
        static List<string> midRain;
        static List<string> midWeather;
        static List<string> midTemp;
        // 미세먼지
        static List<string> PMInfo;
        // 시간표 라벨
        static List<Label> labelList;
        #endregion

        private void btOpenWeatherForm_Click(object sender, EventArgs e)
        {
            if (isWeatherOpen == false)
            {
                int count = 0;
                for (int i = 0; i < API_COUNT; i++)
                {
                    if (!isAPI[i])
                    {
                        MessageBox.Show(errStr[i]);
                    }
                    else
                    {
                        count++;
                    }
                }

                if (count == API_COUNT)
                {
                    isWeatherOpen = true;
                    weatherForm = new Weather.WeatherForm();
                    weatherForm.Show();
                }
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
            PMInfo = new List<string>();
            labelList = new List<Label>();
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
            try
            {
                weatherDate = DateTime.Now;

                getVilageFcst();
                getMidFcst();
                getPMFcst();

                btOpenWeatherForm.Invoke(new MethodInvoker(delegate
                {
                    btOpenWeatherForm.Enabled = true;
                }));

                if (isAPI[0] && isAPI[1] && isAPI[2] && isAPI[3])
                    rainAlert();
                
                Thread.Sleep(100);
                this.Invoke(new MethodInvoker(delegate
                {
                    progressBarLoadAPI.Visible = false;
                    btAlertSetting.Visible = true;
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void getVilageFcst() // 단기예보
        {
            // 단기예보조회
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
                isAPI[0] = true;
            }
            else
            {
                //MessageBox.Show("에러 코드 : " + header.ChildNodes[0].InnerText + '\n' + header.ChildNodes[1].InnerText,
                //    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errStr[0] = "단기예보조회\n"
                    + "에러 코드 : " + header.ChildNodes[0].InnerText + '\n' + header.ChildNodes[1].InnerText;
            }
            
            progressBarLoadAPI.Invoke(new MethodInvoker(delegate
            {
                progressBarLoadAPI.Value++;
            }));
        }

        private void getMidFcst() // 중기예보
        {
            // 중기육상예보조회
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
                isAPI[1] = true;
            }
            else
            {
                //MessageBox.Show("에러 코드 : " + header.ChildNodes[0].InnerText + '\n' + header.ChildNodes[1].InnerText,
                //    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errStr[1] = "중기육상예보조회\n"
                    + "에러 코드 : " + header.ChildNodes[0].InnerText + '\n' + header.ChildNodes[1].InnerText;
            }

            progressBarLoadAPI.Invoke(new MethodInvoker(delegate
            {
                progressBarLoadAPI.Value++;
            }));

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
                isAPI[2] = true;
            }
            else
            {
                //MessageBox.Show("에러 코드 : " + header.ChildNodes[0].InnerText + '\n' + header.ChildNodes[1].InnerText,
                //    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errStr[2] = "중기기온조회\n"
                    + "에러 코드 : " + header.ChildNodes[0].InnerText + '\n' + header.ChildNodes[1].InnerText;
            }
            
            progressBarLoadAPI.Invoke(new MethodInvoker(delegate
            {
                progressBarLoadAPI.Value++;
            }));
        }

        private void getPMFcst() // 대기오염정보
        {
            // 측정소별 실시간 측정정보 조회
            url = "http://apis.data.go.kr/B552584/ArpltnInforInqireSvc/getMsrstnAcctoRltmMesureDnsty";
            url += "?serviceKey=" + "p6DmSuJ8xqCPAMgABBFMeYCk%2BmC%2FmibL769%2FJOalQ0GwVG3DQaGjIglUEgWhh5OEKc%2BLnKVV2XtrnBj3i08CvA%3D%3D";
            url += "&numOfRows=100";
            url += "&pageNo=1";
            url += "&returnType=XML";
            url += "&stationName=노원구";
            url += "&dataTerm=DAILY";
            url += "&ver=1.0";

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
                XmlNode node = xml.SelectSingleNode("response/body/items/item");

                PMInfo.Add(node["dataTime"].InnerText);
                PMInfo.Add(node["pm10Flag"].InnerText);
                PMInfo.Add(node["pm10Value"].InnerText);
                PMInfo.Add(node["pm10Grade"].InnerText);
                PMInfo.Add(node["pm25Flag"].InnerText);
                PMInfo.Add(node["pm25Value"].InnerText);
                PMInfo.Add(node["pm25Grade"].InnerText);

                isAPI[3] = true;
            }
            else
            {
                errStr[3] = "측정소별 실시간 측정정보 조회\n"
                    + "에러 코드 : " + header.ChildNodes[0].InnerText + '\n' + header.ChildNodes[1].InnerText;
            }

            progressBarLoadAPI.Invoke(new MethodInvoker(delegate
            {
                progressBarLoadAPI.Value++;
            }));
        }

        private void rainAlert()
        {
            for (int i = 0; i < 24; i++) // 강우 경고 라벨 visible 설정
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    if (int.Parse(weatherInfo1[i][7]) >= alterRain)
                    {
                        labelList[i].Visible = true;
                        labelList[i].Tag = weatherInfo1[i][9];
                    }
                    else
                    {
                        labelList[i].Visible = false;
                        labelList[i].Tag = "";
                    }
                }));
            }
        }

        private void control_MouseMove(object sender, MouseEventArgs e)
        {
            Control control = sender as Control;
            tooltip.SetToolTip(control, control.Tag.ToString());
        }

        private void btAlertSetting_Click(object sender, EventArgs e)
        {
            Weather.WeatherSetting weatherSetting = new Weather.WeatherSetting();
            DialogResult weatherSettingResult = weatherSetting.ShowDialog();
            if (weatherSettingResult == DialogResult.OK)
            {
                rainAlert();
                if (isWeatherOpen)
                    weatherForm.updateRainAlert();
            }
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

        public static List<string> getPMInfo()
        {
            return PMInfo;
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
