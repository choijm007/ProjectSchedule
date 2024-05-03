using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjectSchedule
{
    public partial class GetSubject : Form
    {
        List<string> subjectName = new List<string>();
        List<string> subjectTime = new List<string>();
        List<string> fileNm = new List<string>();
        List<string[]> CommitDay = new List<string[]>();
        int n = -1;

        public GetSubject()
        {
            InitializeComponent();
        }

        private void GetSubject_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;

            listView1.Columns.Add("No.");
            listView1.Columns.Add("Name");
            listView1.Columns.Add("Instructor / Date");

            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            for (int i = 0; i < listView1.Columns.Count; i++)
            {
                listView1.Columns[i].TextAlign = HorizontalAlignment.Left;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private  HtmlElementCollection getSubjectElement() 
        {
            try
            {
                HtmlDocument doc = webBrowser1.Document;
                string tableid = "appModule";
                HtmlElement name = doc.GetElementById(tableid);
                HtmlElementCollection tul = name.GetElementsByTagName("ul");
                HtmlElementCollection tli = tul[0].GetElementsByTagName("li");



                return tli;
            }catch (Exception ex)
            {
                throw new Exception();
            }

        }

        private void loadListView()
        {

            for (int i = 0; i < n; i++)
            {
                var lvwItem = new ListViewItem(new string[listView1.Columns.Count]);

                for (int j = 0; j < listView1.Columns.Count; j++)
                {
                    lvwItem.SubItems[j].Name = listView1.Columns[j].Name;
                }

                lvwItem.SubItems[0].Text = (i + 1).ToString();
                lvwItem.SubItems[1].Text = subjectName[i];
                lvwItem.SubItems[2].Text = subjectTime[i];
                listView1.Items.Add(lvwItem);
            }


        }
        private bool search(string s)
        {
            for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
            {
                if (checkedListBox1.CheckedItems[i].ToString() == s) { return true; }
            }
            return false;
        }

        private static bool isDate(string date)
        {
            return Regex.IsMatch(date, @"^(19|20)\d{2}-(0[1-9]|1[012])-(0[1-9]|[12][0-9]|3[0-1])$");
        }

        private async void autoLogin()
        {
            try               
            {
                webBrowser1.Navigate("https://klas.kw.ac.kr");
                await Task.Delay(1500);
                webBrowser1.Document.GetElementById("loginId").SetAttribute("value", txtId.Text);
                webBrowser1.Document.GetElementById("loginPwd").SetAttribute("value", txtPassword.Text);
                HtmlElementCollection loginBtn = webBrowser1.Document.GetElementsByTagName("button");


                foreach (HtmlElement el in loginBtn)
                {
                    if (el.InnerText.Replace(" ", string.Empty) == "로그인") el.InvokeMember("click");
                }
                await Task.Delay(1500);
            }
            catch
            {
                MessageBox.Show("Try Again");
                return;
            }
            HtmlElementCollection tli;
            while (true)
            {
                try
                {
                    webBrowser1.Navigate("https://klas.kw.ac.kr");
                    await Task.Delay(1500);
                    tli = getSubjectElement();
                }
                catch
                {
                    continue;
                }
                break;

            }




            foreach (HtmlElement el in tli)
            {
                ++n;

                el.Focus();
                subjectName.Add(Regex.Split(el.InnerText, Environment.NewLine)[0]);
                subjectTime.Add(Regex.Split(el.InnerText, Environment.NewLine)[1]);

            }
            
            loadListView();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            autoLogin();
        }

        private async void btnGetFile_Click(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();
            progressBar1.Maximum = 50;
            progressBar1.Value = 0;

            HtmlElementCollection tli;
            while (true)
            {
                try
                {
                    webBrowser1.Navigate("https://klas.kw.ac.kr");
                    await Task.Delay(1500);
                    tli = getSubjectElement();
                }
                catch
                {
                    continue;
                }
                break;

            }

            int num;
            while (true)
            {
                try
                {
                    var lvwItem = listView1.FocusedItem;
                    num = Convert.ToInt32(lvwItem.SubItems[0].Text);
                    break;
                }
                catch (Exception)
                {
                    MessageBox.Show("Choose subject!");
                    continue;
                }
            }



            checkedListBox1.Items.Clear();
            HtmlElementCollection tt = tli[num - 1].GetElementsByTagName("button");
            // 여기서 강의자료실로 이동
            // 그 후 선택된거 다운로드


            foreach (HtmlElement el in tt)
            {
                if (el.InnerText.Replace(" ", string.Empty) == "강의자료실") el.InvokeMember("click");
            }

            await Task.Delay(1500);

            HtmlDocument doc = webBrowser1.Document;
            string tableid = "appModule";
            HtmlElement name = doc.GetElementById(tableid);

            HtmlElementCollection ttr = name.GetElementsByTagName("tr");


            HtmlElementCollection ttd = ttr[1].GetElementsByTagName("td");
            ttd[1].InvokeMember("click");
            HtmlElementCollection elm;
            fileNm = new List<string>();
            // download = new Dictionary<string, HtmlElement>();
            do
            {
                progressBar1.Value += 1;
                await Task.Delay(1500);
                HtmlDocument subjectDoc = webBrowser1.Document;
                HtmlElement sub = subjectDoc.GetElementById(tableid);
                HtmlElementCollection ta = sub.GetElementsByTagName("a");
                fileNm.Add(ta[0].InnerText);
                // download.Add(ta[0].InnerText,ta[0]);
                //filePath.Add(ta[0].InnerText,webBrowser1.Url +"/"+ ta[0].InnerText);
                elm = sub.GetElementsByTagName("dd");
                elm[0].InvokeMember("click");

            } while (elm[0].InnerText != "이전글이 없습니다.");

            progressBar1.Value = progressBar1.Maximum;
            for (int i = 0; i < fileNm.Count; i++)
            {
                checkedListBox1.Items.Add(fileNm[i]);
            }
        }

        private async void btnDownload_Click(object sender, EventArgs e)
        {
            HtmlElementCollection elm;
            string tableid = "appModule";
            do
            {
                await Task.Delay(1500);
                HtmlDocument subjectDoc = webBrowser1.Document;
                HtmlElement sub = subjectDoc.GetElementById(tableid);
                HtmlElementCollection ta = sub.GetElementsByTagName("a");

                if (search(ta[0].InnerText))
                {
                    ta[0].InvokeMember("click");
                    await Task.Delay(1500);
                }



                elm = sub.GetElementsByTagName("dd");
                elm[1].InvokeMember("click");

            } while (elm[1].InnerText != "다음글이 없습니다.");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnCommitDate_Click(object sender, EventArgs e)
        {
/*            webBrowser1.Navigate("https://klas.kw.ac.kr");
            await Task.Delay(2000);
            HtmlElementCollection tle = getSubjectElement();
            int k = tle.Count;*/
            progressBar1.Maximum = n;
            progressBar1.Value = 0;
            for (int i = 0; i < n; i++)
            {
                try
                {
                    progressBar1.Value += 1;
                    HtmlElementCollection tli;
                    while (true)
                    {
                        try
                        {
                            webBrowser1.Navigate("https://klas.kw.ac.kr");
                            await Task.Delay(1500);
                            tli = getSubjectElement();
                        }
                        catch
                        {
                            continue;
                        }
                        break;

                    }

                    tli[i].Focus();
                    tli[i].GetElementsByTagName("button")[0].InvokeMember("click");


                    await Task.Delay(2000);
                    webBrowser1.Navigate("https://klas.kw.ac.kr/std/lis/evltn/TaskStdPage.do");
                    await Task.Delay(2000);

                    HtmlDocument Commitdoc = webBrowser1.Document;
                    string tableid = "appModule";
                    HtmlElement name = Commitdoc.GetElementById(tableid);

                    HtmlElementCollection ttr = name.GetElementsByTagName("table");


                    HtmlElementCollection ttd = ttr[0].GetElementsByTagName("tbody");
                    foreach (HtmlElement eel in ttd)
                    {
                        string[] str = eel.InnerText.Split(' ');
                        if (str.Length > 3) // 제출된거 표시 안하려면 && str[8] != "제출" 추가
                        {
                            int index = 0;
                            bool chk = false;
                            foreach(string str2 in str)
                            {
                                if (isDate(str2))
                                {
                                    if (chk)
                                        break;
                                    chk = true;
                                }

                                index++;
                            }
                            string[] left = str[index].Split('-');
                            string[] right = str[index+1].Split(':');
                            DateTime t1 = new DateTime(Int32.Parse(left[0]), Int32.Parse(left[1]), Int32.Parse(left[2]), Int32.Parse(right[0]), Int32.Parse(right[1]), Int32.Parse(right[2]));
                            if(DateTime.Compare(DateTime.Now,t1)<=0)
                                CommitDay.Add(str);
                        }
                            

                    }
                }
                catch
                {
                    i--;
                    progressBar1.Value -= 1;
                    continue;
                }

            }


            foreach (string[] s in CommitDay)
            {
                txtCommitDate.Text += String.Join(" ", s);
                txtCommitDate.Text += "\r\n\r\n";
            }
        }
    }
}
