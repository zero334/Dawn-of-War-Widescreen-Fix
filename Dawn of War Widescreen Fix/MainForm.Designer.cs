namespace Dawn_of_War_Widescreen_Fix
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnStart = new System.Windows.Forms.Button();
            this.groupBoxResolution = new System.Windows.Forms.GroupBox();
            this.labelResolution = new System.Windows.Forms.Label();
            this.buttonManualOverride = new System.Windows.Forms.Button();
            this.labelPatchingResolution = new System.Windows.Forms.Label();
            this.labelDragNotification = new System.Windows.Forms.Label();
            this.groupBoxPath = new System.Windows.Forms.GroupBox();
            this.labelPath = new System.Windows.Forms.Label();
            this.labelPathIndicator = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.backupCheckbox = new System.Windows.Forms.CheckBox();
            this.GroupBoxOptions = new System.Windows.Forms.GroupBox();
            this.groupBoxResolution.SuspendLayout();
            this.groupBoxPath.SuspendLayout();
            this.GroupBoxOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(235, 162);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(160, 48);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // groupBoxResolution
            // 
            this.groupBoxResolution.Controls.Add(this.labelResolution);
            this.groupBoxResolution.Controls.Add(this.buttonManualOverride);
            this.groupBoxResolution.Controls.Add(this.labelPatchingResolution);
            this.groupBoxResolution.Location = new System.Drawing.Point(235, 12);
            this.groupBoxResolution.Name = "groupBoxResolution";
            this.groupBoxResolution.Size = new System.Drawing.Size(160, 117);
            this.groupBoxResolution.TabIndex = 5;
            this.groupBoxResolution.TabStop = false;
            this.groupBoxResolution.Text = "Resolution Options";
            // 
            // labelResolution
            // 
            this.labelResolution.AutoSize = true;
            this.labelResolution.Location = new System.Drawing.Point(6, 29);
            this.labelResolution.Name = "labelResolution";
            this.labelResolution.Size = new System.Drawing.Size(115, 13);
            this.labelResolution.TabIndex = 7;
            this.labelResolution.Text = "Resolution placeholder";
            // 
            // buttonManualOverride
            // 
            this.buttonManualOverride.Location = new System.Drawing.Point(6, 71);
            this.buttonManualOverride.Name = "buttonManualOverride";
            this.buttonManualOverride.Size = new System.Drawing.Size(148, 40);
            this.buttonManualOverride.TabIndex = 6;
            this.buttonManualOverride.Text = "Manual override";
            this.buttonManualOverride.UseVisualStyleBackColor = true;
            this.buttonManualOverride.Click += new System.EventHandler(this.ButtonManualOverride_Click);
            // 
            // labelPatchingResolution
            // 
            this.labelPatchingResolution.AutoSize = true;
            this.labelPatchingResolution.Location = new System.Drawing.Point(6, 16);
            this.labelPatchingResolution.Name = "labelPatchingResolution";
            this.labelPatchingResolution.Size = new System.Drawing.Size(100, 13);
            this.labelPatchingResolution.TabIndex = 5;
            this.labelPatchingResolution.Text = "Patching resolution:";
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
            this.groupBoxPath.Location = new System.Drawing.Point(12, 12);
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
            // backupCheckbox
            // 
            this.backupCheckbox.AutoSize = true;
            this.backupCheckbox.Location = new System.Drawing.Point(9, 26);
            this.backupCheckbox.Name = "backupCheckbox";
            this.backupCheckbox.Size = new System.Drawing.Size(171, 17);
            this.backupCheckbox.TabIndex = 10;
            this.backupCheckbox.Text = "Create backup of patched files";
            this.backupCheckbox.UseVisualStyleBackColor = true;
            // 
            // GroupBoxOptions
            // 
            this.GroupBoxOptions.Controls.Add(this.backupCheckbox);
            this.GroupBoxOptions.Location = new System.Drawing.Point(12, 135);
            this.GroupBoxOptions.Name = "GroupBoxOptions";
            this.GroupBoxOptions.Size = new System.Drawing.Size(217, 75);
            this.GroupBoxOptions.TabIndex = 11;
            this.GroupBoxOptions.TabStop = false;
            this.GroupBoxOptions.Text = "General Options";
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(407, 218);
            this.Controls.Add(this.GroupBoxOptions);
            this.Controls.Add(this.groupBoxPath);
            this.Controls.Add(this.groupBoxResolution);
            this.Controls.Add(this.btnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dawn of War Widescreen Fix";
            this.groupBoxResolution.ResumeLayout(false);
            this.groupBoxResolution.PerformLayout();
            this.groupBoxPath.ResumeLayout(false);
            this.groupBoxPath.PerformLayout();
            this.GroupBoxOptions.ResumeLayout(false);
            this.GroupBoxOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox groupBoxResolution;
        private System.Windows.Forms.Label labelDragNotification;
        private System.Windows.Forms.GroupBox groupBoxPath;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.Label labelPathIndicator;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.CheckBox backupCheckbox;
        private System.Windows.Forms.GroupBox GroupBoxOptions;
        private System.Windows.Forms.Label labelPatchingResolution;
        private System.Windows.Forms.Button buttonManualOverride;
        private System.Windows.Forms.Label labelResolution;
    }
}

