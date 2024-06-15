namespace ProjectSchedule
{
    partial class GetSubject
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.btnLogin = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.btnGetFile = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            this.txtCommitDate = new System.Windows.Forms.TextBox();
            this.btnCommitDate = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnGive = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(237, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "password : ";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(66, 27);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(151, 21);
            this.txtId.TabIndex = 2;
            this.txtId.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(316, 27);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(163, 21);
            this.txtPassword.TabIndex = 3;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(646, 359);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(454, 239);
            this.webBrowser1.TabIndex = 4;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(505, 20);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(81, 32);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "로그인";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 91);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(543, 244);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(659, 91);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(454, 244);
            this.checkedListBox1.TabIndex = 7;
            // 
            // btnGetFile
            // 
            this.btnGetFile.Location = new System.Drawing.Point(480, 341);
            this.btnGetFile.Name = "btnGetFile";
            this.btnGetFile.Size = new System.Drawing.Size(75, 35);
            this.btnGetFile.TabIndex = 8;
            this.btnGetFile.Text = "조회";
            this.btnGetFile.UseVisualStyleBackColor = true;
            this.btnGetFile.Click += new System.EventHandler(this.btnGetFile_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(1038, 341);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(75, 35);
            this.btnDownload.TabIndex = 9;
            this.btnDownload.Text = "다운로드";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // txtCommitDate
            // 
            this.txtCommitDate.Location = new System.Drawing.Point(12, 407);
            this.txtCommitDate.Multiline = true;
            this.txtCommitDate.Name = "txtCommitDate";
            this.txtCommitDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCommitDate.Size = new System.Drawing.Size(543, 227);
            this.txtCommitDate.TabIndex = 10;
            // 
            // btnCommitDate
            // 
            this.btnCommitDate.Location = new System.Drawing.Point(480, 640);
            this.btnCommitDate.Name = "btnCommitDate";
            this.btnCommitDate.Size = new System.Drawing.Size(75, 35);
            this.btnCommitDate.TabIndex = 11;
            this.btnCommitDate.Text = "제출기한 조회";
            this.btnCommitDate.UseVisualStyleBackColor = true;
            this.btnCommitDate.Click += new System.EventHandler(this.btnCommitDate_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(937, 20);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 35);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "닫기";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnGive
            // 
            this.btnGive.Location = new System.Drawing.Point(844, 19);
            this.btnGive.Name = "btnGive";
            this.btnGive.Size = new System.Drawing.Size(75, 35);
            this.btnGive.TabIndex = 13;
            this.btnGive.Text = "적용하기";
            this.btnGive.UseVisualStyleBackColor = true;
            this.btnGive.Click += new System.EventHandler(this.btnGive_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(659, 498);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(454, 37);
            this.progressBar1.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(657, 483);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "진행사항";
            // 
            // GetSubject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 687);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnGive);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnCommitDate);
            this.Controls.Add(this.txtCommitDate);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.btnGetFile);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "GetSubject";
            this.Text = "GetSubject";
            this.Load += new System.EventHandler(this.GetSubject_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button btnGetFile;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.TextBox txtCommitDate;
        private System.Windows.Forms.Button btnCommitDate;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnGive;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label3;
    }
}