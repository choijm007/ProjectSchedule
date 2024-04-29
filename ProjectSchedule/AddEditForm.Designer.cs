namespace ProjectSchedule
{
    partial class AddEditForm
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
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.addButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.repeatTimeLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.userMemoLabel = new System.Windows.Forms.Label();
            this.addClassButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(18, 18);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 1;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(251, 18);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(319, 364);
            this.listBox1.TabIndex = 2;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(247, 389);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 3;
            this.addButton.Text = "추가";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(419, 389);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(75, 23);
            this.editButton.TabIndex = 4;
            this.editButton.Text = "수정";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(505, 389);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 5;
            this.deleteButton.Text = "삭제";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // categoryLabel
            // 
            this.categoryLabel.AutoSize = true;
            this.categoryLabel.Location = new System.Drawing.Point(16, 189);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(37, 12);
            this.categoryLabel.TabIndex = 6;
            this.categoryLabel.Text = "유형 :";
            // 
            // repeatTimeLabel
            // 
            this.repeatTimeLabel.AutoSize = true;
            this.repeatTimeLabel.Location = new System.Drawing.Point(16, 214);
            this.repeatTimeLabel.Name = "repeatTimeLabel";
            this.repeatTimeLabel.Size = new System.Drawing.Size(65, 12);
            this.repeatTimeLabel.TabIndex = 7;
            this.repeatTimeLabel.Text = "반복 기간 :";
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(16, 240);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(37, 12);
            this.timeLabel.TabIndex = 8;
            this.timeLabel.Text = "시간 :";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(16, 266);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(37, 12);
            this.nameLabel.TabIndex = 9;
            this.nameLabel.Text = "이름 :";
            // 
            // userMemoLabel
            // 
            this.userMemoLabel.Location = new System.Drawing.Point(16, 292);
            this.userMemoLabel.Name = "userMemoLabel";
            this.userMemoLabel.Size = new System.Drawing.Size(222, 120);
            this.userMemoLabel.TabIndex = 10;
            this.userMemoLabel.Text = "메모 :";
            // 
            // addClassButton
            // 
            this.addClassButton.Location = new System.Drawing.Point(333, 389);
            this.addClassButton.Name = "addClassButton";
            this.addClassButton.Size = new System.Drawing.Size(75, 23);
            this.addClassButton.TabIndex = 11;
            this.addClassButton.Text = "수업 추가";
            this.addClassButton.UseVisualStyleBackColor = true;
            this.addClassButton.Click += new System.EventHandler(this.addClassButton_Click);
            // 
            // AddEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 424);
            this.Controls.Add(this.addClassButton);
            this.Controls.Add(this.userMemoLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.repeatTimeLabel);
            this.Controls.Add(this.categoryLabel);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.monthCalendar1);
            this.Name = "AddEditForm";
            this.Text = "AddEditForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Label categoryLabel;
        private System.Windows.Forms.Label repeatTimeLabel;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label userMemoLabel;
        private System.Windows.Forms.Button addClassButton;
    }
}