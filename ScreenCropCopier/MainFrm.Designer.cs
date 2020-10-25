namespace ScreenCropCopier
{
    partial class MainFrm
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
            this.ClickThruCheckbox = new System.Windows.Forms.CheckBox();
            this.RectX = new System.Windows.Forms.NumericUpDown();
            this.lbl_X = new System.Windows.Forms.Label();
            this.lbl_Y = new System.Windows.Forms.Label();
            this.RectY = new System.Windows.Forms.NumericUpDown();
            this.lbl_W = new System.Windows.Forms.Label();
            this.RectW = new System.Windows.Forms.NumericUpDown();
            this.lbl_H = new System.Windows.Forms.Label();
            this.RectH = new System.Windows.Forms.NumericUpDown();
            this.ImageOpacity = new System.Windows.Forms.NumericUpDown();
            this.lbl_Opacity = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.RectX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RectY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RectW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RectH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageOpacity)).BeginInit();
            this.SuspendLayout();
            // 
            // ClickThruCheckbox
            // 
            this.ClickThruCheckbox.AutoSize = true;
            this.ClickThruCheckbox.Location = new System.Drawing.Point(12, 12);
            this.ClickThruCheckbox.Name = "ClickThruCheckbox";
            this.ClickThruCheckbox.Size = new System.Drawing.Size(144, 16);
            this.ClickThruCheckbox.TabIndex = 0;
            this.ClickThruCheckbox.Text = "복사 윈도우 클릭 통과";
            this.ClickThruCheckbox.UseVisualStyleBackColor = true;
            this.ClickThruCheckbox.CheckedChanged += new System.EventHandler(this.ClickThru);
            // 
            // RectX
            // 
            this.RectX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RectX.Location = new System.Drawing.Point(95, 43);
            this.RectX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.RectX.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.RectX.Name = "RectX";
            this.RectX.Size = new System.Drawing.Size(105, 17);
            this.RectX.TabIndex = 1;
            this.RectX.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // lbl_X
            // 
            this.lbl_X.AutoSize = true;
            this.lbl_X.Location = new System.Drawing.Point(12, 42);
            this.lbl_X.Name = "lbl_X";
            this.lbl_X.Size = new System.Drawing.Size(77, 12);
            this.lbl_X.TabIndex = 2;
            this.lbl_X.Text = "시작점 X(px)";
            // 
            // lbl_Y
            // 
            this.lbl_Y.AutoSize = true;
            this.lbl_Y.Location = new System.Drawing.Point(12, 65);
            this.lbl_Y.Name = "lbl_Y";
            this.lbl_Y.Size = new System.Drawing.Size(77, 12);
            this.lbl_Y.TabIndex = 4;
            this.lbl_Y.Text = "시작점 Y(px)";
            // 
            // RectY
            // 
            this.RectY.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RectY.Location = new System.Drawing.Point(95, 66);
            this.RectY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.RectY.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.RectY.Name = "RectY";
            this.RectY.Size = new System.Drawing.Size(105, 17);
            this.RectY.TabIndex = 3;
            this.RectY.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // lbl_W
            // 
            this.lbl_W.AutoSize = true;
            this.lbl_W.Location = new System.Drawing.Point(36, 88);
            this.lbl_W.Name = "lbl_W";
            this.lbl_W.Size = new System.Drawing.Size(53, 12);
            this.lbl_W.TabIndex = 6;
            this.lbl_W.Text = "넓이(px)";
            // 
            // RectW
            // 
            this.RectW.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RectW.Location = new System.Drawing.Point(95, 89);
            this.RectW.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.RectW.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.RectW.Name = "RectW";
            this.RectW.Size = new System.Drawing.Size(105, 17);
            this.RectW.TabIndex = 5;
            this.RectW.Value = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.RectW.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // lbl_H
            // 
            this.lbl_H.AutoSize = true;
            this.lbl_H.Location = new System.Drawing.Point(36, 111);
            this.lbl_H.Name = "lbl_H";
            this.lbl_H.Size = new System.Drawing.Size(53, 12);
            this.lbl_H.TabIndex = 8;
            this.lbl_H.Text = "높이(px)";
            // 
            // RectH
            // 
            this.RectH.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RectH.Location = new System.Drawing.Point(95, 112);
            this.RectH.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.RectH.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.RectH.Name = "RectH";
            this.RectH.Size = new System.Drawing.Size(105, 17);
            this.RectH.TabIndex = 7;
            this.RectH.Value = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.RectH.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // ImageOpacity
            // 
            this.ImageOpacity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ImageOpacity.Location = new System.Drawing.Point(95, 135);
            this.ImageOpacity.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.ImageOpacity.Name = "ImageOpacity";
            this.ImageOpacity.Size = new System.Drawing.Size(105, 17);
            this.ImageOpacity.TabIndex = 9;
            this.ImageOpacity.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.ImageOpacity.ValueChanged += new System.EventHandler(this.OpacityChanged);
            // 
            // lbl_Opacity
            // 
            this.lbl_Opacity.AutoSize = true;
            this.lbl_Opacity.Location = new System.Drawing.Point(36, 135);
            this.lbl_Opacity.Name = "lbl_Opacity";
            this.lbl_Opacity.Size = new System.Drawing.Size(53, 12);
            this.lbl_Opacity.TabIndex = 10;
            this.lbl_Opacity.Text = "불투명도";
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(214, 167);
            this.Controls.Add(this.lbl_Opacity);
            this.Controls.Add(this.ImageOpacity);
            this.Controls.Add(this.lbl_H);
            this.Controls.Add(this.RectH);
            this.Controls.Add(this.lbl_W);
            this.Controls.Add(this.RectW);
            this.Controls.Add(this.lbl_Y);
            this.Controls.Add(this.RectY);
            this.Controls.Add(this.lbl_X);
            this.Controls.Add(this.RectX);
            this.Controls.Add(this.ClickThruCheckbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainFrm";
            this.Text = "Controller";
            this.Load += new System.EventHandler(this.Loaded);
            ((System.ComponentModel.ISupportInitialize)(this.RectX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RectY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RectW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RectH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageOpacity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ClickThruCheckbox;
        private System.Windows.Forms.NumericUpDown RectX;
        private System.Windows.Forms.Label lbl_X;
        private System.Windows.Forms.Label lbl_Y;
        private System.Windows.Forms.NumericUpDown RectY;
        private System.Windows.Forms.Label lbl_W;
        private System.Windows.Forms.NumericUpDown RectW;
        private System.Windows.Forms.Label lbl_H;
        private System.Windows.Forms.NumericUpDown RectH;
        private System.Windows.Forms.NumericUpDown ImageOpacity;
        private System.Windows.Forms.Label lbl_Opacity;
    }
}

