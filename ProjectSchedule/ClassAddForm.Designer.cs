namespace ProjectSchedule
{
    partial class ClassAddForm
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
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.repeatViewButton = new System.Windows.Forms.Button();
            this.repeatAddButton = new System.Windows.Forms.Button();
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
            this.repeatDatePicker = new System.Windows.Forms.DateTimePicker();
            this.repeatCategory = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.repeatRangePicker2 = new System.Windows.Forms.DateTimePicker();
            this.repeatRangePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.userMemoTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.todoCategory = new System.Windows.Forms.ComboBox();
            this.todoNameTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.todoDeadlinePicker = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.todoDeadlineMM = new System.Windows.Forms.ComboBox();
            this.todoDeadlineHH = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.todoUserMemo = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.todoAddButton = new System.Windows.Forms.Button();
            this.todoViewButton = new System.Windows.Forms.Button();
            this.applyButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(52, 12);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(233, 21);
            this.nameTextBox.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "이름 :";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(11, 54);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(37, 12);
            this.label20.TabIndex = 60;
            this.label20.Text = "반복 :";
            // 
            // repeatViewButton
            // 
            this.repeatViewButton.Location = new System.Drawing.Point(414, 104);
            this.repeatViewButton.Name = "repeatViewButton";
            this.repeatViewButton.Size = new System.Drawing.Size(99, 23);
            this.repeatViewButton.TabIndex = 59;
            this.repeatViewButton.Text = "목록 보기";
            this.repeatViewButton.UseVisualStyleBackColor = true;
            this.repeatViewButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // repeatAddButton
            // 
            this.repeatAddButton.Location = new System.Drawing.Point(321, 104);
            this.repeatAddButton.Name = "repeatAddButton";
            this.repeatAddButton.Size = new System.Drawing.Size(60, 23);
            this.repeatAddButton.TabIndex = 58;
            this.repeatAddButton.Text = "추가";
            this.repeatAddButton.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(453, 82);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(17, 12);
            this.label14.TabIndex = 57;
            this.label14.Text = "분";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(364, 82);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(17, 12);
            this.label15.TabIndex = 56;
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
            this.repeatMM2.Location = new System.Drawing.Point(385, 78);
            this.repeatMM2.Name = "repeatMM2";
            this.repeatMM2.Size = new System.Drawing.Size(60, 20);
            this.repeatMM2.TabIndex = 55;
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
            this.repeatHH2.Location = new System.Drawing.Point(300, 78);
            this.repeatHH2.Name = "repeatHH2";
            this.repeatHH2.Size = new System.Drawing.Size(60, 20);
            this.repeatHH2.TabIndex = 54;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(232, 81);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(17, 12);
            this.label16.TabIndex = 53;
            this.label16.Text = "분";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(143, 81);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(17, 12);
            this.label17.TabIndex = 52;
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
            this.repeatMM1.Location = new System.Drawing.Point(164, 77);
            this.repeatMM1.Name = "repeatMM1";
            this.repeatMM1.Size = new System.Drawing.Size(60, 20);
            this.repeatMM1.TabIndex = 51;
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
            this.repeatHH1.Location = new System.Drawing.Point(79, 77);
            this.repeatHH1.Name = "repeatHH1";
            this.repeatHH1.Size = new System.Drawing.Size(60, 20);
            this.repeatHH1.TabIndex = 50;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(484, 82);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(29, 12);
            this.label18.TabIndex = 49;
            this.label18.Text = "까지";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(259, 82);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(29, 12);
            this.label19.TabIndex = 48;
            this.label19.Text = "부터";
            // 
            // repeatDatePicker
            // 
            this.repeatDatePicker.Location = new System.Drawing.Point(139, 50);
            this.repeatDatePicker.Name = "repeatDatePicker";
            this.repeatDatePicker.Size = new System.Drawing.Size(179, 21);
            this.repeatDatePicker.TabIndex = 47;
            // 
            // repeatCategory
            // 
            this.repeatCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.repeatCategory.FormattingEnabled = true;
            this.repeatCategory.Items.AddRange(new object[] {
            "매주",
            "매달",
            "매년"});
            this.repeatCategory.Location = new System.Drawing.Point(53, 50);
            this.repeatCategory.Name = "repeatCategory";
            this.repeatCategory.Size = new System.Drawing.Size(61, 20);
            this.repeatCategory.TabIndex = 46;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(500, 155);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 45;
            this.label8.Text = "까지";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(276, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 44;
            this.label6.Text = "부터";
            // 
            // repeatRangePicker2
            // 
            this.repeatRangePicker2.Location = new System.Drawing.Point(314, 150);
            this.repeatRangePicker2.Name = "repeatRangePicker2";
            this.repeatRangePicker2.Size = new System.Drawing.Size(176, 21);
            this.repeatRangePicker2.TabIndex = 43;
            // 
            // repeatRangePicker1
            // 
            this.repeatRangePicker1.Location = new System.Drawing.Point(86, 150);
            this.repeatRangePicker1.Name = "repeatRangePicker1";
            this.repeatRangePicker1.Size = new System.Drawing.Size(179, 21);
            this.repeatRangePicker1.TabIndex = 42;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 41;
            this.label3.Text = "반복 기간 :";
            // 
            // userMemoTextBox
            // 
            this.userMemoTextBox.Location = new System.Drawing.Point(54, 188);
            this.userMemoTextBox.Multiline = true;
            this.userMemoTextBox.Name = "userMemoTextBox";
            this.userMemoTextBox.Size = new System.Drawing.Size(484, 116);
            this.userMemoTextBox.TabIndex = 62;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 12);
            this.label5.TabIndex = 61;
            this.label5.Text = "메모 :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 320);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 12);
            this.label2.TabIndex = 63;
            this.label2.Text = "과제, 시험 등의 일정";
            // 
            // todoCategory
            // 
            this.todoCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.todoCategory.FormattingEnabled = true;
            this.todoCategory.Items.AddRange(new object[] {
            "과제",
            "시험",
            "퀴즈"});
            this.todoCategory.Location = new System.Drawing.Point(15, 344);
            this.todoCategory.Name = "todoCategory";
            this.todoCategory.Size = new System.Drawing.Size(61, 20);
            this.todoCategory.TabIndex = 64;
            // 
            // todoNameTextBox
            // 
            this.todoNameTextBox.Location = new System.Drawing.Point(139, 344);
            this.todoNameTextBox.Name = "todoNameTextBox";
            this.todoNameTextBox.Size = new System.Drawing.Size(233, 21);
            this.todoNameTextBox.TabIndex = 66;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(97, 349);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 12);
            this.label4.TabIndex = 65;
            this.label4.Text = "이름 :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(96, 376);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 12);
            this.label7.TabIndex = 67;
            this.label7.Text = "마감일 :";
            // 
            // todoDeadlinePicker
            // 
            this.todoDeadlinePicker.Location = new System.Drawing.Point(148, 372);
            this.todoDeadlinePicker.Name = "todoDeadlinePicker";
            this.todoDeadlinePicker.Size = new System.Drawing.Size(181, 21);
            this.todoDeadlinePicker.TabIndex = 68;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(491, 376);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 12);
            this.label9.TabIndex = 73;
            this.label9.Text = "분";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(402, 376);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 12);
            this.label10.TabIndex = 72;
            this.label10.Text = "시";
            // 
            // todoDeadlineMM
            // 
            this.todoDeadlineMM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.todoDeadlineMM.FormattingEnabled = true;
            this.todoDeadlineMM.Items.AddRange(new object[] {
            "00",
            "10",
            "20",
            "30",
            "40",
            "50"});
            this.todoDeadlineMM.Location = new System.Drawing.Point(423, 372);
            this.todoDeadlineMM.Name = "todoDeadlineMM";
            this.todoDeadlineMM.Size = new System.Drawing.Size(60, 20);
            this.todoDeadlineMM.TabIndex = 71;
            // 
            // todoDeadlineHH
            // 
            this.todoDeadlineHH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.todoDeadlineHH.FormattingEnabled = true;
            this.todoDeadlineHH.Items.AddRange(new object[] {
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
            this.todoDeadlineHH.Location = new System.Drawing.Point(338, 372);
            this.todoDeadlineHH.Name = "todoDeadlineHH";
            this.todoDeadlineHH.Size = new System.Drawing.Size(60, 20);
            this.todoDeadlineHH.TabIndex = 70;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(509, 376);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 69;
            this.label11.Text = "까지";
            // 
            // todoUserMemo
            // 
            this.todoUserMemo.Location = new System.Drawing.Point(139, 402);
            this.todoUserMemo.Multiline = true;
            this.todoUserMemo.Name = "todoUserMemo";
            this.todoUserMemo.Size = new System.Drawing.Size(294, 116);
            this.todoUserMemo.TabIndex = 75;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(96, 402);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 12);
            this.label12.TabIndex = 74;
            this.label12.Text = "메모 :";
            // 
            // todoAddButton
            // 
            this.todoAddButton.Location = new System.Drawing.Point(454, 417);
            this.todoAddButton.Name = "todoAddButton";
            this.todoAddButton.Size = new System.Drawing.Size(75, 23);
            this.todoAddButton.TabIndex = 76;
            this.todoAddButton.Text = "추가";
            this.todoAddButton.UseVisualStyleBackColor = true;
            // 
            // todoViewButton
            // 
            this.todoViewButton.Location = new System.Drawing.Point(454, 468);
            this.todoViewButton.Name = "todoViewButton";
            this.todoViewButton.Size = new System.Drawing.Size(75, 23);
            this.todoViewButton.TabIndex = 77;
            this.todoViewButton.Text = "목록 보기";
            this.todoViewButton.UseVisualStyleBackColor = true;
            this.todoViewButton.Click += new System.EventHandler(this.button4_Click);
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(15, 534);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(101, 40);
            this.applyButton.TabIndex = 78;
            this.applyButton.Text = "적용";
            this.applyButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(187, 534);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(101, 40);
            this.cancelButton.TabIndex = 79;
            this.cancelButton.Text = "취소";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // ClassAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 586);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.todoViewButton);
            this.Controls.Add(this.todoAddButton);
            this.Controls.Add(this.todoUserMemo);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.todoDeadlineMM);
            this.Controls.Add(this.todoDeadlineHH);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.todoDeadlinePicker);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.todoNameTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.todoCategory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.userMemoTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label20);
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
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.repeatRangePicker2);
            this.Controls.Add(this.repeatRangePicker1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label1);
            this.Name = "ClassAddForm";
            this.Text = "ClassAddForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button repeatViewButton;
        private System.Windows.Forms.Button repeatAddButton;
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
        private System.Windows.Forms.DateTimePicker repeatDatePicker;
        private System.Windows.Forms.ComboBox repeatCategory;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker repeatRangePicker2;
        private System.Windows.Forms.DateTimePicker repeatRangePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox userMemoTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox todoCategory;
        private System.Windows.Forms.TextBox todoNameTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker todoDeadlinePicker;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox todoDeadlineMM;
        private System.Windows.Forms.ComboBox todoDeadlineHH;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox todoUserMemo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button todoAddButton;
        private System.Windows.Forms.Button todoViewButton;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Button cancelButton;
    }
}