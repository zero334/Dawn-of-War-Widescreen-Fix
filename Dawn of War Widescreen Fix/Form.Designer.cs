namespace Dawn_of_War_Widescreen_Fix
{
    partial class Form
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            this.btnStart = new System.Windows.Forms.Button();
            this.radioButton1920 = new System.Windows.Forms.RadioButton();
            this.radioButton1366 = new System.Windows.Forms.RadioButton();
            this.radioButton1680 = new System.Windows.Forms.RadioButton();
            this.groupBoxResolution = new System.Windows.Forms.GroupBox();
            this.radioButtonAutoDetect = new System.Windows.Forms.RadioButton();
            this.labelDragNotification = new System.Windows.Forms.Label();
            this.groupBoxPath = new System.Windows.Forms.GroupBox();
            this.labelPath = new System.Windows.Forms.Label();
            this.labelPathIndicator = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBoxResolution.SuspendLayout();
            this.groupBoxPath.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 153);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(160, 48);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // radioButton1920
            // 
            this.radioButton1920.AutoSize = true;
            this.radioButton1920.Location = new System.Drawing.Point(6, 42);
            this.radioButton1920.Name = "radioButton1920";
            this.radioButton1920.Size = new System.Drawing.Size(108, 17);
            this.radioButton1920.TabIndex = 1;
            this.radioButton1920.Text = "1920x1080 (16:9)";
            this.radioButton1920.UseVisualStyleBackColor = true;
            // 
            // radioButton1366
            // 
            this.radioButton1366.AutoSize = true;
            this.radioButton1366.Location = new System.Drawing.Point(6, 88);
            this.radioButton1366.Name = "radioButton1366";
            this.radioButton1366.Size = new System.Drawing.Size(108, 17);
            this.radioButton1366.TabIndex = 2;
            this.radioButton1366.Text = "1366x768 (16:10)";
            this.radioButton1366.UseVisualStyleBackColor = true;
            // 
            // radioButton1680
            // 
            this.radioButton1680.AutoSize = true;
            this.radioButton1680.Location = new System.Drawing.Point(6, 65);
            this.radioButton1680.Name = "radioButton1680";
            this.radioButton1680.Size = new System.Drawing.Size(108, 17);
            this.radioButton1680.TabIndex = 3;
            this.radioButton1680.Text = "1680x1050 (16:9)";
            this.radioButton1680.UseVisualStyleBackColor = true;
            // 
            // groupBoxResolution
            // 
            this.groupBoxResolution.Controls.Add(this.radioButtonAutoDetect);
            this.groupBoxResolution.Controls.Add(this.radioButton1366);
            this.groupBoxResolution.Controls.Add(this.radioButton1920);
            this.groupBoxResolution.Controls.Add(this.radioButton1680);
            this.groupBoxResolution.Location = new System.Drawing.Point(12, 12);
            this.groupBoxResolution.Name = "groupBoxResolution";
            this.groupBoxResolution.Size = new System.Drawing.Size(160, 117);
            this.groupBoxResolution.TabIndex = 5;
            this.groupBoxResolution.TabStop = false;
            this.groupBoxResolution.Text = "Resolution";
            // 
            // radioButtonAutoDetect
            // 
            this.radioButtonAutoDetect.AutoSize = true;
            this.radioButtonAutoDetect.Checked = true;
            this.radioButtonAutoDetect.Location = new System.Drawing.Point(6, 19);
            this.radioButtonAutoDetect.Name = "radioButtonAutoDetect";
            this.radioButtonAutoDetect.Size = new System.Drawing.Size(80, 17);
            this.radioButtonAutoDetect.TabIndex = 4;
            this.radioButtonAutoDetect.TabStop = true;
            this.radioButtonAutoDetect.Text = "Auto detect";
            this.radioButtonAutoDetect.UseVisualStyleBackColor = true;
            // 
            // labelDragNotification
            // 
            this.labelDragNotification.AutoSize = true;
            this.labelDragNotification.Location = new System.Drawing.Point(6, 23);
            this.labelDragNotification.Name = "labelDragNotification";
            this.labelDragNotification.Size = new System.Drawing.Size(200, 13);
            this.labelDragNotification.TabIndex = 6;
            this.labelDragNotification.Text = "Drag and drop the game into this window";
            // 
            // groupBoxPath
            // 
            this.groupBoxPath.Controls.Add(this.labelPath);
            this.groupBoxPath.Controls.Add(this.labelPathIndicator);
            this.groupBoxPath.Controls.Add(this.labelDragNotification);
            this.groupBoxPath.Location = new System.Drawing.Point(178, 12);
            this.groupBoxPath.Name = "groupBoxPath";
            this.groupBoxPath.Size = new System.Drawing.Size(217, 117);
            this.groupBoxPath.TabIndex = 9;
            this.groupBoxPath.TabStop = false;
            this.groupBoxPath.Text = "Path";
            // 
            // labelPath
            // 
            this.labelPath.Location = new System.Drawing.Point(44, 46);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(62, 13);
            this.labelPath.TabIndex = 10;
            this.labelPath.Text = "Not defined";
            // 
            // labelPathIndicator
            // 
            this.labelPathIndicator.AutoSize = true;
            this.labelPathIndicator.Location = new System.Drawing.Point(6, 46);
            this.labelPathIndicator.Name = "labelPathIndicator";
            this.labelPathIndicator.Size = new System.Drawing.Size(32, 13);
            this.labelPathIndicator.TabIndex = 9;
            this.labelPathIndicator.Text = "Path:";
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "The fix has been successfully applied";
            this.notifyIcon.BalloonTipTitle = "Successfully completed";
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Dawn of War Widescreen Fix";
            this.notifyIcon.Visible = true;
            // 
            // Form
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(407, 214);
            this.Controls.Add(this.groupBoxPath);
            this.Controls.Add(this.groupBoxResolution);
            this.Controls.Add(this.btnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dawn of War Widescreen Fix";
            this.groupBoxResolution.ResumeLayout(false);
            this.groupBoxResolution.PerformLayout();
            this.groupBoxPath.ResumeLayout(false);
            this.groupBoxPath.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.RadioButton radioButton1920;
        private System.Windows.Forms.RadioButton radioButton1366;
        private System.Windows.Forms.RadioButton radioButton1680;
        private System.Windows.Forms.GroupBox groupBoxResolution;
        private System.Windows.Forms.RadioButton radioButtonAutoDetect;
        private System.Windows.Forms.Label labelDragNotification;
        private System.Windows.Forms.GroupBox groupBoxPath;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.Label labelPathIndicator;
        private System.Windows.Forms.NotifyIcon notifyIcon;
    }
}

