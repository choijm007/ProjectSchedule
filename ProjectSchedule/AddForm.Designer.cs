namespace ProjectSchedule
{
    partial class AddForm
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
            this.label기간 = new System.Windows.Forms.Label();
            this.label시간 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.repeatRangePicker2 = new System.Windows.Forms.DateTimePicker();
            this.repeatRangePicker1 = new System.Windows.Forms.DateTimePicker();
            this.userMemoTextBox = new System.Windows.Forms.TextBox();
            this.applyButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.scheduleCategory = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.timeHH1 = new System.Windows.Forms.ComboBox();
            this.timeMM1 = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.timeMM2 = new System.Windows.Forms.ComboBox();
            this.timeHH2 = new System.Windows.Forms.ComboBox();
            this.repeatCategory = new System.Windows.Forms.ComboBox();
            this.repeatDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.repeatMM2 = new System.Windows.Forms.ComboBox();
            this.repeatHH2 = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.repeatMM1 = new System.Windows.Forms.ComboBox();
            this.repeatHH1 = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.repeatAddButton = new System.Windows.Forms.Button();
            this.repeatViewButton = new System.Windows.Forms.Button();
            this.label반복 = new System.Windows.Forms.Label();
            this.errorLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "이름 :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 47);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(37, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "유형 :";
            // 
            // label기간
            // 
            this.label기간.AutoSize = true;
            this.label기간.Location = new System.Drawing.Point(13, 190);
            this.label기간.Name = "label기간";
            this.label기간.Size = new System.Drawing.Size(37, 12);
            this.label기간.TabIndex = 2;
            this.label기간.Text = "기간 :";
            // 
            // label시간
            // 
            this.label시간.AutoSize = true;
            this.label시간.Location = new System.Drawing.Point(12, 225);
            this.label시간.Name = "label시간";
            this.label시간.Size = new System.Drawing.Size(37, 12);
            this.label시간.TabIndex = 3;
            this.label시간.Text = "시간 :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 261);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "메모 :";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(55, 10);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(233, 21);
            this.nameTextBox.TabIndex = 5;
            this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
            // 
            // repeatRangePicker2
            // 
            this.repeatRangePicker2.Location = new System.Drawing.Point(285, 185);
            this.repeatRangePicker2.Name = "repeatRangePicker2";
            this.repeatRangePicker2.Size = new System.Drawing.Size(176, 21);
            this.repeatRangePicker2.TabIndex = 9;
            this.repeatRangePicker2.ValueChanged += new System.EventHandler(this.valueChanged);
            // 
            // repeatRangePicker1
            // 
            this.repeatRangePicker1.Location = new System.Drawing.Point(57, 185);
            this.repeatRangePicker1.Name = "repeatRangePicker1";
            this.repeatRangePicker1.Size = new System.Drawing.Size(179, 21);
            this.repeatRangePicker1.TabIndex = 8;
            this.repeatRangePicker1.ValueChanged += new System.EventHandler(this.valueChanged);
            // 
            // userMemoTextBox
            // 
            this.userMemoTextBox.Location = new System.Drawing.Point(56, 261);
            this.userMemoTextBox.Multiline = true;
            this.userMemoTextBox.Name = "userMemoTextBox";
            this.userMemoTextBox.Size = new System.Drawing.Size(484, 143);
            this.userMemoTextBox.TabIndex = 10;
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(17, 416);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(128, 38);
            this.applyButton.TabIndex = 11;
            this.applyButton.Text = "적용";
            this.applyButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(414, 416);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(128, 38);
            this.cancelButton.TabIndex = 12;
            this.cancelButton.Text = "취소";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // scheduleCategory
            // 
            this.scheduleCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.scheduleCategory.FormattingEnabled = true;
            this.scheduleCategory.Items.AddRange(new object[] {
            "1회성 알람",
            "1회성 일정",
            "반복성 일정"});
            this.scheduleCategory.Location = new System.Drawing.Point(55, 44);
            this.scheduleCategory.Name = "scheduleCategory";
            this.scheduleCategory.Size = new System.Drawing.Size(121, 20);
            this.scheduleCategory.TabIndex = 13;
            this.scheduleCategory.SelectedIndexChanged += new System.EventHandler(this.scheduleCategory_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(247, 190);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "부터";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(236, 226);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 15;
            this.label7.Text = "부터";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(471, 190);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 16;
            this.label8.Text = "까지";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(461, 226);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 17;
            this.label9.Text = "까지";
            // 
            // timeHH1
            // 
            this.timeHH1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.timeHH1.FormattingEnabled = true;
            this.timeHH1.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24"});
            this.timeHH1.Location = new System.Drawing.Point(56, 221);
            this.timeHH1.Name = "timeHH1";
            this.timeHH1.Size = new System.Drawing.Size(60, 20);
            this.timeHH1.TabIndex = 18;
            this.timeHH1.SelectedIndexChanged += new System.EventHandler(this.valueChanged);
            // 
            // timeMM1
            // 
            this.timeMM1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.timeMM1.FormattingEnabled = true;
            this.timeMM1.Items.AddRange(new object[] {
            "00",
            "10",
            "20",
            "30",
            "40",
            "50"});
            this.timeMM1.Location = new System.Drawing.Point(141, 221);
            this.timeMM1.Name = "timeMM1";
            this.timeMM1.Size = new System.Drawing.Size(60, 20);
            this.timeMM1.TabIndex = 19;
            this.timeMM1.SelectedIndexChanged += new System.EventHandler(this.valueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(120, 225);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 12);
            this.label10.TabIndex = 20;
            this.label10.Text = "시";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(209, 225);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 12);
            this.label11.TabIndex = 21;
            this.label11.Text = "분";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(430, 226);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 12);
            this.label12.TabIndex = 25;
            this.label12.Text = "분";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(341, 226);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(17, 12);
            this.label13.TabIndex = 24;
            this.label13.Text = "시";
            // 
            // timeMM2
            // 
            this.timeMM2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.timeMM2.FormattingEnabled = true;
            this.timeMM2.Items.AddRange(new object[] {
            "00",
            "10",
            "20",
            "30",
            "40",
            "50"});
            this.timeMM2.Location = new System.Drawing.Point(362, 222);
            this.timeMM2.Name = "timeMM2";
            this.timeMM2.Size = new System.Drawing.Size(60, 20);
            this.timeMM2.TabIndex = 23;
            this.timeMM2.SelectedIndexChanged += new System.EventHandler(this.valueChanged);
            // 
            // timeHH2
            // 
            this.timeHH2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.timeHH2.FormattingEnabled = true;
            this.timeHH2.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24"});
            this.timeHH2.Location = new System.Drawing.Point(277, 222);
            this.timeHH2.Name = "timeHH2";
            this.timeHH2.Size = new System.Drawing.Size(60, 20);
            this.timeHH2.TabIndex = 22;
            this.timeHH2.SelectedIndexChanged += new System.EventHandler(this.valueChanged);
            // 
            // repeatCategory
            // 
            this.repeatCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.repeatCategory.FormattingEnabled = true;
            this.repeatCategory.Items.AddRange(new object[] {
            "매주",
            "매달",
            "매년"});
            this.repeatCategory.Location = new System.Drawing.Point(55, 85);
            this.repeatCategory.Name = "repeatCategory";
            this.repeatCategory.Size = new System.Drawing.Size(61, 20);
            this.repeatCategory.TabIndex = 26;
            this.repeatCategory.SelectedIndexChanged += new System.EventHandler(this.repeatCategory_SelectedIndexChanged);
            // 
            // repeatDatePicker
            // 
            this.repeatDatePicker.Location = new System.Drawing.Point(141, 85);
            this.repeatDatePicker.Name = "repeatDatePicker";
            this.repeatDatePicker.Size = new System.Drawing.Size(179, 21);
            this.repeatDatePicker.TabIndex = 27;
            this.repeatDatePicker.ValueChanged += new System.EventHandler(this.valueChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(455, 117);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(17, 12);
            this.label14.TabIndex = 37;
            this.label14.Text = "분";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(366, 117);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(17, 12);
            this.label15.TabIndex = 36;
            this.label15.Text = "시";
            // 
            // repeatMM2
            // 
            this.repeatMM2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.repeatMM2.FormattingEnabled = true;
            this.repeatMM2.Items.AddRange(new object[] {
            "00",
            "10",
            "20",
            "30",
            "40",
            "50"});
            this.repeatMM2.Location = new System.Drawing.Point(387, 113);
            this.repeatMM2.Name = "repeatMM2";
            this.repeatMM2.Size = new System.Drawing.Size(60, 20);
            this.repeatMM2.TabIndex = 35;
            this.repeatMM2.SelectedIndexChanged += new System.EventHandler(this.valueChanged);
            // 
            // repeatHH2
            // 
            this.repeatHH2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.repeatHH2.FormattingEnabled = true;
            this.repeatHH2.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24"});
            this.repeatHH2.Location = new System.Drawing.Point(302, 113);
            this.repeatHH2.Name = "repeatHH2";
            this.repeatHH2.Size = new System.Drawing.Size(60, 20);
            this.repeatHH2.TabIndex = 34;
            this.repeatHH2.SelectedIndexChanged += new System.EventHandler(this.valueChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(234, 116);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(17, 12);
            this.label16.TabIndex = 33;
            this.label16.Text = "분";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(145, 116);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(17, 12);
            this.label17.TabIndex = 32;
            this.label17.Text = "시";
            // 
            // repeatMM1
            // 
            this.repeatMM1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.repeatMM1.FormattingEnabled = true;
            this.repeatMM1.Items.AddRange(new object[] {
            "00",
            "10",
            "20",
            "30",
            "40",
            "50"});
            this.repeatMM1.Location = new System.Drawing.Point(166, 112);
            this.repeatMM1.Name = "repeatMM1";
            this.repeatMM1.Size = new System.Drawing.Size(60, 20);
            this.repeatMM1.TabIndex = 31;
            this.repeatMM1.SelectedIndexChanged += new System.EventHandler(this.valueChanged);
            // 
            // repeatHH1
            // 
            this.repeatHH1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.repeatHH1.FormattingEnabled = true;
            this.repeatHH1.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24"});
            this.repeatHH1.Location = new System.Drawing.Point(81, 112);
            this.repeatHH1.Name = "repeatHH1";
            this.repeatHH1.Size = new System.Drawing.Size(60, 20);
            this.repeatHH1.TabIndex = 30;
            this.repeatHH1.SelectedIndexChanged += new System.EventHandler(this.valueChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(486, 117);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(29, 12);
            this.label18.TabIndex = 29;
            this.label18.Text = "까지";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(261, 117);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(29, 12);
            this.label19.TabIndex = 28;
            this.label19.Text = "부터";
            // 
            // repeatAddButton
            // 
            this.repeatAddButton.Location = new System.Drawing.Point(323, 139);
            this.repeatAddButton.Name = "repeatAddButton";
            this.repeatAddButton.Size = new System.Drawing.Size(60, 23);
            this.repeatAddButton.TabIndex = 38;
            this.repeatAddButton.Text = "추가";
            this.repeatAddButton.UseVisualStyleBackColor = true;
            // 
            // repeatViewButton
            // 
            this.repeatViewButton.Location = new System.Drawing.Point(416, 139);
            this.repeatViewButton.Name = "repeatViewButton";
            this.repeatViewButton.Size = new System.Drawing.Size(99, 23);
            this.repeatViewButton.TabIndex = 39;
            this.repeatViewButton.Text = "목록 보기";
            this.repeatViewButton.UseVisualStyleBackColor = true;
            this.repeatViewButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // label반복
            // 
            this.label반복.AutoSize = true;
            this.label반복.Location = new System.Drawing.Point(13, 89);
            this.label반복.Name = "label반복";
            this.label반복.Size = new System.Drawing.Size(37, 12);
            this.label반복.TabIndex = 40;
            this.label반복.Text = "반복 :";
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Location = new System.Drawing.Point(339, 19);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(0, 12);
            this.errorLabel.TabIndex = 41;
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 461);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.label반복);
            this.Controls.Add(this.repeatViewButton);
            this.Controls.Add(this.repeatAddButton);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.repeatMM2);
            this.Controls.Add(this.repeatHH2);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.repeatMM1);
            this.Controls.Add(this.repeatHH1);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.repeatDatePicker);
            this.Controls.Add(this.repeatCategory);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.timeMM2);
            this.Controls.Add(this.timeHH2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.timeMM1);
            this.Controls.Add(this.timeHH1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.scheduleCategory);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.userMemoTextBox);
            this.Controls.Add(this.repeatRangePicker2);
            this.Controls.Add(this.repeatRangePicker1);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label시간);
            this.Controls.Add(this.label기간);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddForm";
            this.Text = "AddForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label기간;
        private System.Windows.Forms.Label label시간;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.DateTimePicker repeatRangePicker2;
        private System.Windows.Forms.DateTimePicker repeatRangePicker1;
        private System.Windows.Forms.TextBox userMemoTextBox;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ComboBox scheduleCategory;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox timeHH1;
        private System.Windows.Forms.ComboBox timeMM1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox timeMM2;
        private System.Windows.Forms.ComboBox timeHH2;
        private System.Windows.Forms.ComboBox repeatCategory;
        private System.Windows.Forms.DateTimePicker repeatDatePicker;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox repeatMM2;
        private System.Windows.Forms.ComboBox repeatHH2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox repeatMM1;
        private System.Windows.Forms.ComboBox repeatHH1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button repeatAddButton;
        private System.Windows.Forms.Button repeatViewButton;
        private System.Windows.Forms.Label label반복;
        private System.Windows.Forms.Label errorLabel;
    }
}