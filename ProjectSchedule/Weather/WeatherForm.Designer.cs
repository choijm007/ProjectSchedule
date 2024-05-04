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
            this.panelWeather = new ProjectSchedule.Weather.WeatherPanel();
            this.SuspendLayout();
            // 
            // panelWeather
            // 
            this.panelWeather.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panelWeather.Location = new System.Drawing.Point(12, 12);
            this.panelWeather.Name = "panelWeather";
            this.panelWeather.Size = new System.Drawing.Size(1028, 626);
            this.panelWeather.TabIndex = 1;
            // 
            // WeatherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 650);
            this.Controls.Add(this.panelWeather);
            this.Name = "WeatherForm";
            this.Text = "Weather";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WeatherForm_FormClosed);
            this.Load += new System.EventHandler(this.WeatherForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private WeatherPanel panelWeather;
    }
}