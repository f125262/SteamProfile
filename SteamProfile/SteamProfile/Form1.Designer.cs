namespace SteamProfile
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblFile = new System.Windows.Forms.Label();
            this.btnSelectVideo = new System.Windows.Forms.Button();
            this.btnShowPath = new System.Windows.Forms.Button();
            this.Fps = new System.Windows.Forms.NumericUpDown();
            this.Pfps = new System.Windows.Forms.Button();
            this.btnConvert = new System.Windows.Forms.Button();
            this.scaleValue = new System.Windows.Forms.NumericUpDown();
            this.Workshop = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Fps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleValue)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.ForeColor = System.Drawing.SystemColors.Control;
            this.lblFile.Image = ((System.Drawing.Image)(resources.GetObject("lblFile.Image")));
            this.lblFile.Location = new System.Drawing.Point(61, 80);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(18, 13);
            this.lblFile.TabIndex = 0;
            this.lblFile.Text = "ㅤ";
            this.lblFile.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnSelectVideo
            // 
            this.btnSelectVideo.BackColor = System.Drawing.SystemColors.Control;
            this.btnSelectVideo.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSelectVideo.FlatAppearance.BorderSize = 2;
            this.btnSelectVideo.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnSelectVideo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnSelectVideo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnSelectVideo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelectVideo.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSelectVideo.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectVideo.Image")));
            this.btnSelectVideo.Location = new System.Drawing.Point(64, 96);
            this.btnSelectVideo.Name = "btnSelectVideo";
            this.btnSelectVideo.Size = new System.Drawing.Size(75, 23);
            this.btnSelectVideo.TabIndex = 1;
            this.btnSelectVideo.Text = "Select Video";
            this.btnSelectVideo.UseVisualStyleBackColor = false;
            this.btnSelectVideo.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnShowPath
            // 
            this.btnShowPath.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnShowPath.FlatAppearance.BorderSize = 2;
            this.btnShowPath.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnShowPath.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnShowPath.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnShowPath.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnShowPath.ForeColor = System.Drawing.SystemColors.Control;
            this.btnShowPath.Image = ((System.Drawing.Image)(resources.GetObject("btnShowPath.Image")));
            this.btnShowPath.Location = new System.Drawing.Point(145, 96);
            this.btnShowPath.Name = "btnShowPath";
            this.btnShowPath.Size = new System.Drawing.Size(75, 23);
            this.btnShowPath.TabIndex = 2;
            this.btnShowPath.Text = "Show Path";
            this.btnShowPath.UseVisualStyleBackColor = true;
            this.btnShowPath.Click += new System.EventHandler(this.btnShowPath_Click);
            // 
            // Fps
            // 
            this.Fps.BackColor = System.Drawing.Color.DarkSlateGray;
            this.Fps.ForeColor = System.Drawing.SystemColors.Window;
            this.Fps.Location = new System.Drawing.Point(64, 125);
            this.Fps.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.Fps.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Fps.Name = "Fps";
            this.Fps.Size = new System.Drawing.Size(47, 20);
            this.Fps.TabIndex = 3;
            this.Fps.Tag = "";
            this.Fps.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.Fps.ValueChanged += new System.EventHandler(this.Fps_ValueChanged);
            // 
            // Pfps
            // 
            this.Pfps.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Pfps.FlatAppearance.BorderSize = 2;
            this.Pfps.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.Pfps.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.Pfps.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.Pfps.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Pfps.ForeColor = System.Drawing.SystemColors.Control;
            this.Pfps.Image = ((System.Drawing.Image)(resources.GetObject("Pfps.Image")));
            this.Pfps.Location = new System.Drawing.Point(164, 125);
            this.Pfps.Name = "Pfps";
            this.Pfps.Size = new System.Drawing.Size(75, 23);
            this.Pfps.TabIndex = 4;
            this.Pfps.Text = "Confirm";
            this.Pfps.UseVisualStyleBackColor = true;
            this.Pfps.Click += new System.EventHandler(this.Pfps_Click);
            // 
            // btnConvert
            // 
            this.btnConvert.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnConvert.FlatAppearance.BorderSize = 2;
            this.btnConvert.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.btnConvert.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnConvert.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnConvert.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConvert.ForeColor = System.Drawing.SystemColors.Control;
            this.btnConvert.Image = ((System.Drawing.Image)(resources.GetObject("btnConvert.Image")));
            this.btnConvert.Location = new System.Drawing.Point(226, 96);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(75, 23);
            this.btnConvert.TabIndex = 5;
            this.btnConvert.Text = "Start";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // scaleValue
            // 
            this.scaleValue.BackColor = System.Drawing.Color.DarkSlateGray;
            this.scaleValue.Cursor = System.Windows.Forms.Cursors.Default;
            this.scaleValue.ForeColor = System.Drawing.SystemColors.Control;
            this.scaleValue.Location = new System.Drawing.Point(64, 151);
            this.scaleValue.Maximum = new decimal(new int[] {
            1444,
            0,
            0,
            0});
            this.scaleValue.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.scaleValue.Name = "scaleValue";
            this.scaleValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.scaleValue.Size = new System.Drawing.Size(47, 20);
            this.scaleValue.TabIndex = 6;
            this.scaleValue.Value = new decimal(new int[] {
            480,
            0,
            0,
            0});
            this.scaleValue.ValueChanged += new System.EventHandler(this.scaleValue_ValueChanged);
            // 
            // Workshop
            // 
            this.Workshop.AutoSize = true;
            this.Workshop.BackColor = System.Drawing.SystemColors.Desktop;
            this.Workshop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Workshop.BackgroundImage")));
            this.Workshop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Workshop.ForeColor = System.Drawing.SystemColors.Control;
            this.Workshop.Location = new System.Drawing.Point(64, 206);
            this.Workshop.Name = "Workshop";
            this.Workshop.Size = new System.Drawing.Size(159, 17);
            this.Workshop.TabIndex = 7;
            this.Workshop.Text = "Steam Workshop Showcase";
            this.Workshop.UseVisualStyleBackColor = false;
            this.Workshop.CheckedChanged += new System.EventHandler(this.Workshop_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(108, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "FPS";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.Location = new System.Drawing.Point(108, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Scale";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.BackgroundImage = global::SteamProfile.Properties.Resources.image;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Workshop);
            this.Controls.Add(this.scaleValue);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.Pfps);
            this.Controls.Add(this.Fps);
            this.Controls.Add(this.btnShowPath);
            this.Controls.Add(this.btnSelectVideo);
            this.Controls.Add(this.lblFile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Fps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Button btnSelectVideo;
        private System.Windows.Forms.Button btnShowPath;
        private System.Windows.Forms.NumericUpDown Fps;
        private System.Windows.Forms.Button Pfps;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.NumericUpDown scaleValue;
        private System.Windows.Forms.CheckBox Workshop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

