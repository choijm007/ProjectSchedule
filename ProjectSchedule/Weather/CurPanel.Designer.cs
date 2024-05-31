namespace ProjectSchedule.Weather
{
    partial class CurPanel
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbCur = new System.Windows.Forms.PictureBox();
            this.lbTemp = new System.Windows.Forms.Label();
            this.lbWeather = new System.Windows.Forms.Label();
            this.lbPM10 = new System.Windows.Forms.Label();
            this.lbPM25 = new System.Windows.Forms.Label();
            this.lbPMTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbCur)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCur
            // 
            this.pbCur.Location = new System.Drawing.Point(3, 3);
            this.pbCur.Name = "pbCur";
            this.pbCur.Size = new System.Drawing.Size(80, 80);
            this.pbCur.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCur.TabIndex = 24;
            this.pbCur.TabStop = false;
            // 
            // lbTemp
            // 
            this.lbTemp.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbTemp.Location = new System.Drawing.Point(89, 3);
            this.lbTemp.Name = "lbTemp";
            this.lbTemp.Size = new System.Drawing.Size(120, 40);
            this.lbTemp.TabIndex = 31;
            this.lbTemp.Text = "1000°C";
            this.lbTemp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbWeather
            // 
            this.lbWeather.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbWeather.Location = new System.Drawing.Point(89, 43);
            this.lbWeather.Name = "lbWeather";
            this.lbWeather.Size = new System.Drawing.Size(120, 40);
            this.lbWeather.TabIndex = 32;
            this.lbWeather.Text = "날씨날씨";
            this.lbWeather.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbPM10
            // 
            this.lbPM10.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbPM10.Location = new System.Drawing.Point(215, 3);
            this.lbPM10.Name = "lbPM10";
            this.lbPM10.Size = new System.Drawing.Size(524, 40);
            this.lbPM10.TabIndex = 34;
            this.lbPM10.Text = "미세먼지ㅤ : ";
            this.lbPM10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbPM25
            // 
            this.lbPM25.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbPM25.Location = new System.Drawing.Point(215, 46);
            this.lbPM25.Name = "lbPM25";
            this.lbPM25.Size = new System.Drawing.Size(524, 40);
            this.lbPM25.TabIndex = 35;
            this.lbPM25.Text = "초미세먼지 : ";
            this.lbPM25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbPMTime
            // 
            this.lbPMTime.AutoSize = true;
            this.lbPMTime.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbPMTime.Location = new System.Drawing.Point(215, 86);
            this.lbPMTime.Name = "lbPMTime";
            this.lbPMTime.Size = new System.Drawing.Size(115, 13);
            this.lbPMTime.TabIndex = 36;
            this.lbPMTime.Text = "미세먼지 예보시각";
            // 
            // CurPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbPMTime);
            this.Controls.Add(this.lbPM25);
            this.Controls.Add(this.lbPM10);
            this.Controls.Add(this.lbWeather);
            this.Controls.Add(this.lbTemp);
            this.Controls.Add(this.pbCur);
            this.Name = "CurPanel";
            this.Size = new System.Drawing.Size(785, 171);
            ((System.ComponentModel.ISupportInitialize)(this.pbCur)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbCur;
        private System.Windows.Forms.Label lbTemp;
        private System.Windows.Forms.Label lbWeather;
        private System.Windows.Forms.Label lbPM10;
        private System.Windows.Forms.Label lbPM25;
        private System.Windows.Forms.Label lbPMTime;
    }
}
