namespace ProjectSchedule
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.klasButton = new System.Windows.Forms.Button();
            this.addEditButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.deadlineListBox = new System.Windows.Forms.ListBox();
            this.takingClassesListView = new System.Windows.Forms.ListView();
            this.btOpenWeatherForm = new System.Windows.Forms.Button();
            this.progressBarLoadAPI = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // klasButton
            // 
            this.klasButton.Location = new System.Drawing.Point(13, 13);
            this.klasButton.Name = "klasButton";
            this.klasButton.Size = new System.Drawing.Size(121, 23);
            this.klasButton.TabIndex = 0;
            this.klasButton.Text = "klas에서 불러오기";
            this.klasButton.UseVisualStyleBackColor = true;
            this.klasButton.Click += new System.EventHandler(this.klasButton_Click);
            // 
            // addEditButton
            // 
            this.addEditButton.Location = new System.Drawing.Point(154, 13);
            this.addEditButton.Name = "addEditButton";
            this.addEditButton.Size = new System.Drawing.Size(118, 23);
            this.addEditButton.TabIndex = 1;
            this.addEditButton.Text = "일정 추가 및 수정";
            this.addEditButton.UseVisualStyleBackColor = true;
            this.addEditButton.Click += new System.EventHandler(this.addEditButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(35, 63);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 581F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(609, 576);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(35, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "월요일";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(122, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "화요일";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(209, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "수요일";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(296, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "목요일";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(383, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "금요일";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(470, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "토요일";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(557, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "일요일";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // deadlineListBox
            // 
            this.deadlineListBox.Font = new System.Drawing.Font("굴림", 12F);
            this.deadlineListBox.FormattingEnabled = true;
            this.deadlineListBox.ItemHeight = 16;
            this.deadlineListBox.Location = new System.Drawing.Point(13, 657);
            this.deadlineListBox.Name = "deadlineListBox";
            this.deadlineListBox.Size = new System.Drawing.Size(631, 148);
            this.deadlineListBox.TabIndex = 11;
            // 
            // takingClassesListView
            // 
            this.takingClassesListView.HideSelection = false;
            this.takingClassesListView.Location = new System.Drawing.Point(13, 811);
            this.takingClassesListView.Name = "takingClassesListView";
            this.takingClassesListView.Size = new System.Drawing.Size(631, 131);
            this.takingClassesListView.TabIndex = 12;
            this.takingClassesListView.UseCompatibleStateImageBehavior = false;
            // 
            // btOpenWeatherForm
            // 
            this.btOpenWeatherForm.Enabled = false;
            this.btOpenWeatherForm.Location = new System.Drawing.Point(289, 13);
            this.btOpenWeatherForm.Name = "btOpenWeatherForm";
            this.btOpenWeatherForm.Size = new System.Drawing.Size(79, 23);
            this.btOpenWeatherForm.TabIndex = 14;
            this.btOpenWeatherForm.Text = "날씨 정보";
            this.btOpenWeatherForm.UseVisualStyleBackColor = true;
            this.btOpenWeatherForm.Click += new System.EventHandler(this.btOpenWeatherForm_Click);
            // 
            // progressBarLoadAPI
            // 
            this.progressBarLoadAPI.Location = new System.Drawing.Point(385, 13);
            this.progressBarLoadAPI.Maximum = 3;
            this.progressBarLoadAPI.Name = "progressBarLoadAPI";
            this.progressBarLoadAPI.Size = new System.Drawing.Size(259, 23);
            this.progressBarLoadAPI.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 950);
            this.Controls.Add(this.progressBarLoadAPI);
            this.Controls.Add(this.btOpenWeatherForm);
            this.Controls.Add(this.takingClassesListView);
            this.Controls.Add(this.deadlineListBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.addEditButton);
            this.Controls.Add(this.klasButton);
            this.Name = "Form1";
            this.Text = "ProjectSchedule";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button klasButton;
        private System.Windows.Forms.Button addEditButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox deadlineListBox;
        private System.Windows.Forms.ListView takingClassesListView;
        private System.Windows.Forms.Button btOpenWeatherForm;
        private System.Windows.Forms.ProgressBar progressBarLoadAPI;
    }
}

