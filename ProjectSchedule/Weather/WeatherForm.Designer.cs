namespace ProjectSchedule.Weather
{
    partial class WeatherForm
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
            this.lbToday = new System.Windows.Forms.Label();
            this.lbWeek = new System.Windows.Forms.Label();
            this.panelWeatherToday = new ProjectSchedule.Weather.TodayPanel();
            this.panelWeatherWeek = new ProjectSchedule.Weather.WeekPanel();
            this.SuspendLayout();
            // 
            // lbToday
            // 
            this.lbToday.AutoSize = true;
            this.lbToday.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbToday.Location = new System.Drawing.Point(12, 9);
            this.lbToday.Name = "lbToday";
            this.lbToday.Size = new System.Drawing.Size(106, 21);
            this.lbToday.TabIndex = 2;
            this.lbToday.Text = "오늘 날씨";
            // 
            // lbWeek
            // 
            this.lbWeek.AutoSize = true;
            this.lbWeek.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbWeek.Location = new System.Drawing.Point(12, 241);
            this.lbWeek.Name = "lbWeek";
            this.lbWeek.Size = new System.Drawing.Size(106, 21);
            this.lbWeek.TabIndex = 3;
            this.lbWeek.Text = "주간 날씨";
            // 
            // panelWeatherToday
            // 
            this.panelWeatherToday.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panelWeatherToday.Location = new System.Drawing.Point(12, 40);
            this.panelWeatherToday.Margin = new System.Windows.Forms.Padding(3, 10, 3, 15);
            this.panelWeatherToday.Name = "panelWeatherToday";
            this.panelWeatherToday.Size = new System.Drawing.Size(1028, 186);
            this.panelWeatherToday.TabIndex = 1;
            // 
            // panelWeatherWeek
            // 
            this.panelWeatherWeek.Location = new System.Drawing.Point(12, 272);
            this.panelWeatherWeek.Margin = new System.Windows.Forms.Padding(3, 10, 3, 15);
            this.panelWeatherWeek.Name = "panelWeatherWeek";
            this.panelWeatherWeek.Size = new System.Drawing.Size(1028, 256);
            this.panelWeatherWeek.TabIndex = 4;
            // 
            // WeatherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 552);
            this.Controls.Add(this.panelWeatherWeek);
            this.Controls.Add(this.lbWeek);
            this.Controls.Add(this.lbToday);
            this.Controls.Add(this.panelWeatherToday);
            this.Name = "WeatherForm";
            this.Text = "Weather";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WeatherForm_FormClosed);
            this.Load += new System.EventHandler(this.WeatherForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TodayPanel panelWeatherToday;
        private System.Windows.Forms.Label lbToday;
        private System.Windows.Forms.Label lbWeek;
        private WeekPanel panelWeatherWeek;
    }
}