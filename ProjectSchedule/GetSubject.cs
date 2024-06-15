using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
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
        int no_star = 1;

        List<string> subjectName = new List<string>();
        List<string> subjectTime = new List<string>();
        List<string> fileNm = new List<string>();
        List<string[]> CommitDay = new List<string[]>();
        int n = 0;

        
        bool loadComplete = false;
        public GetSubject()
        {
            InitializeComponent();
        }

        private void GetSubject_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://klas.kw.ac.kr");

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

        public List<string> getSubjectName() { return subjectName; }
        public List<string> getSubjectTime() { return subjectTime; }

        public List<string[]> getCommitDay() { return CommitDay; }

        public delegate void SendListParents(List<string> l1, List<string> l2, List<string[]> l3);
        public event SendListParents Changed;
        private void btnGive_Click(object sender, EventArgs e)
        {
            if (Changed != null)
                Changed(subjectName, subjectTime, CommitDay);

            MessageBox.Show("적용 완료!");
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            loadComplete = true;
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
            }catch
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
                    //webBrowser1.Navigate("https://klas.kw.ac.kr");
/*                  loadComplete = false;
                    while (true)
                    {
                        if (loadComplete)
                            break;
                    }*/
                    await Task.Delay(1500);

                    tli = getSubjectElement();
                }
                catch
                {
                    continue;
                }
                break;

            }
            
/*
            Task<HtmlElementCollection> t1 = Task<HtmlElementCollection>.Run(() =>
            {
                webBrowser1.Navigate("https://klas.kw.ac.kr");
                loadComplete = false;
                while (true)
                {
                    if (loadComplete)
                        break;
                }

                HtmlDocument doc = webBrowser1.Document;
                string tableid = "appModule";
                HtmlElement name = doc.GetElementById(tableid);
                HtmlElementCollection tul = name.GetElementsByTagName("ul");
                HtmlElementCollection t = tul[0].GetElementsByTagName("li");

                return t;

            });

             tli = t1.Result;*/

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

            HtmlDocument doc = webBrowser1.Document;

            if (doc.Title == "광운대학교")
            {
                HtmlElementCollection tul = doc.GetElementsByTagName("a");
                foreach(HtmlElement el in tul)
                {
                    if(el.InnerText == "Logout")
                    {
                        el.InvokeMember("click");
                        
                    }
                }
            }
            
            
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

            HtmlElementCollection tt;
            try
            {
                tt = tli[num - 1].GetElementsByTagName("button");
            }
            catch
            {
                MessageBox.Show("Try again");
                return;
            }
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
            if (ttd.Count < 2)
            {
                progressBar1.Value = progressBar1.Maximum;
                return;
            }

            #region 별표 자료 추가
            HtmlElementCollection ttd2 = null;
            string star_img_src = "/assets/custom/images/icon-star.png";

            if (ttd[0].InnerHtml.Contains(star_img_src))
            {
                while (no_star < ttr.Count && ttr[no_star].GetElementsByTagName("td")[0].InnerHtml.Contains(star_img_src))
                    no_star++;
                progressBar1.Maximum = int.Parse(ttr[no_star].GetElementsByTagName("td")[0].GetElementsByTagName("span")[0].InnerHtml);
                ttd2 = ttr[no_star].GetElementsByTagName("td");
            }
            else
            {
                progressBar1.Maximum = int.Parse(ttd[0].GetElementsByTagName("span")[0].InnerHtml);
            }
            #endregion

            ttd[1].InvokeMember("click");
            HtmlElementCollection elm;
            fileNm = new List<string>();
            // download = new Dictionary<string, HtmlElement>();
            do
            {
                HtmlElement sub;
                progressBar1.Value += 1;
                await Task.Delay(1500);
                HtmlDocument subjectDoc = webBrowser1.Document;
                sub = subjectDoc.GetElementById(tableid);
                HtmlElementCollection ta = sub.GetElementsByTagName("a");
                try
                {
                    fileNm.Add(ta[0].InnerText);
                }
                catch
                {
                    
                }

                // download.Add(ta[0].InnerText,ta[0]);
                //filePath.Add(ta[0].InnerText,webBrowser1.Url +"/"+ ta[0].InnerText);

                elm = sub.GetElementsByTagName("dd");
                elm[0].InvokeMember("click");


            } while (elm[0].InnerText != "이전글이 없습니다.");

            #region 별표 자료 추가
            HtmlElement list_button = webBrowser1.Document.GetElementById(tableid).GetElementsByTagName("button")[1];
            list_button.InvokeMember("click");
            await Task.Delay(3000);

            name = doc.GetElementById(tableid);
            ttr = name.GetElementsByTagName("tr");
            ttd = ttr[no_star].GetElementsByTagName("td");

            if (no_star > 1 && ttd2 != null)
            {
                ttd[1].InvokeMember("click");
                // download = new Dictionary<string, HtmlElement>();
                do
                {
                    HtmlElement sub;
                    progressBar1.Value += 1;
                    await Task.Delay(1500);
                    HtmlDocument subjectDoc = webBrowser1.Document;
                    sub = subjectDoc.GetElementById(tableid);
                    HtmlElementCollection ta = sub.GetElementsByTagName("a");
                    try
                    {
                        fileNm.Add(ta[0].InnerText);
                    }
                    catch
                    {

                    }

                    // download.Add(ta[0].InnerText,ta[0]);
                    //filePath.Add(ta[0].InnerText,webBrowser1.Url +"/"+ ta[0].InnerText);

                    elm = sub.GetElementsByTagName("dd");
                    elm[0].InvokeMember("click");


                } while (elm[0].InnerText != "이전글이 없습니다.");

                list_button = webBrowser1.Document.GetElementById(tableid).GetElementsByTagName("button")[1];
                list_button.InvokeMember("click");
                await Task.Delay(3000);
            }
            #endregion

            progressBar1.Value = progressBar1.Maximum;
            for (int i = 0; i < fileNm.Count; i++)
            {
                checkedListBox1.Items.Add(fileNm[i]);
            }
        }

        private async void btnDownload_Click(object sender, EventArgs e)
        {
            #region 별표 자료 추가
            progressBar1.Maximum = checkedListBox1.CheckedItems.Count;
            progressBar1.Value = 0;

            HtmlDocument doc = webBrowser1.Document;
            HtmlElement name = doc.GetElementById("appModule");
            HtmlElementCollection ttr = name.GetElementsByTagName("tr");
            HtmlElementCollection ttd = ttr[1].GetElementsByTagName("td");
            ttd[1].InvokeMember("click");
            #endregion
            // 밑에 elm[1] > elm[0], 다음글 > 이전글 수정, try~catch 문 추가

            HtmlElementCollection elm;
            string tableid = "appModule";
            do
            {
                await Task.Delay(1500);
                HtmlDocument subjectDoc = webBrowser1.Document;
                HtmlElement sub = subjectDoc.GetElementById(tableid);
                HtmlElementCollection ta = sub.GetElementsByTagName("a");

                try
                {
                    if (search(ta[0].InnerText))
                    {
                        ta[0].InvokeMember("click");
                        progressBar1.Value++;
                        await Task.Delay(1500);
                    }
                }
                catch { }


                elm = sub.GetElementsByTagName("dd");
                elm[0].InvokeMember("click");

            } while (elm[0].InnerText != "이전글이 없습니다.");

            #region 별표 자료 추가
            HtmlElement list_button = webBrowser1.Document.GetElementById(tableid).GetElementsByTagName("button")[1];
            list_button.InvokeMember("click");
            await Task.Delay(3000);

            if (no_star > 1)
            {
                name = doc.GetElementById(tableid);
                ttr = name.GetElementsByTagName("tr");
                ttd = ttr[no_star].GetElementsByTagName("td");
                ttd[1].InvokeMember("click");

                do
                {
                    await Task.Delay(1500);
                    HtmlDocument subjectDoc = webBrowser1.Document;
                    HtmlElement sub = subjectDoc.GetElementById(tableid);
                    HtmlElementCollection ta = sub.GetElementsByTagName("a");

                    try
                    {
                        if (search(ta[0].InnerText))
                        {
                            ta[0].InvokeMember("click");
                            progressBar1.Value++;
                            await Task.Delay(1500);
                        }
                    }
                    catch { }

                    elm = sub.GetElementsByTagName("dd");
                    elm[0].InvokeMember("click");

                } while (elm[0].InnerText != "이전글이 없습니다.");

                list_button = webBrowser1.Document.GetElementById(tableid).GetElementsByTagName("button")[1];
                list_button.InvokeMember("click");
                await Task.Delay(3000);
            }
            #endregion
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

            checkedListBox1.Items.Clear();

            progressBar1.Maximum = n;
            progressBar1.Value = 0;


            for (int i = 0; i < n; i++)
            {
                try
                {
                    progressBar1.Value += 1;
                    await Task.Delay(1500);
                    webBrowser1.Navigate("https://klas.kw.ac.kr");

                    HtmlElementCollection tli;

                    webBrowser1.Navigate("https://klas.kw.ac.kr");
                    await Task.Delay(1500);

                    while (true)
                    {
                        try
                        {
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
            if (CommitDay.Count == 0)
                MessageBox.Show("남아 있는 과제가 없습니다.");
        }


    }
}
