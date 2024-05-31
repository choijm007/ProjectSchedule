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
        List<string> subjectName = new List<string>();
        List<string> subjectTime = new List<string>();
        List<string[]> CommitDay = new List<string[]>();

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

        private void addEditButton_Click(object sender, EventArgs e)
        {
            AddEditForm aeForm = new AddEditForm();
            DialogResult dResult = aeForm.ShowDialog();

        }
        private void klas_changed(List<string> l1, List<string> l2, List<string[]> l3)
        {
            subjectName = l1;
            subjectTime = l2;
            CommitDay = l3;

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
}
