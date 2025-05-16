using System;
using System.Windows.Forms;

namespace Dawn_of_War_Widescreen_Fix
{
    public partial class MainForm : Form
    {
        private readonly AttributeStorage attributeStorage;

        public MainForm()
        {
            InitializeComponent();
            attributeStorage = new AttributeStorage();
            this.DragEnter += new DragEventHandler(Form_DragEnter);
            this.DragDrop += new DragEventHandler(Form_DragDrop);


            var monitors = MonitorResolution.GetAll();
            if (monitors.Count > 0)
            {
                var monitorToUse = MonitorResolution.DifferentResolutionMonitorssPresent(monitors) ? MonitorResolution.GetScreenFromUser(monitors) : monitors[0];
                attributeStorage.Width = monitorToUse.Width;
                attributeStorage.Height = monitorToUse.Height;
                labelResolution.Text = attributeStorage.Width + " x" + attributeStorage.Height;
            } else {
                MessageBox.Show("No screen detected.", "Critical Error");
                Environment.Exit(0);
            }
        }

        static void Form_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        void Form_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[]) e.Data.GetData(DataFormats.FileDrop);

            attributeStorage.FileStorage.SetFilePath(files[0]);
            if (attributeStorage.FileStorage.CheckFilePath())
            {
                labelPath.Text = "Valid \u2714";
            }
            else
            {
                labelPath.Text = "Invalid \u2715";
            }
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (!attributeStorage.FileStorage.CheckFilePath())
            {
                MessageBox.Show("Please set a valid path", "Invalid path", MessageBoxButtons.OK);
                return;
            }

            attributeStorage.CalculateAspectRatioString();
            attributeStorage.CalculateAspectRatio();

            switch (attributeStorage.AspectRatio)
            {
                case "16/9":
                    attributeStorage.ReplacementString = "398EE33F";
                break;
 
                case "16/10":
                    attributeStorage.ReplacementString = "CCCCCD3F";
                break;

                default:
                    DialogResult result = MessageBox.Show("Your aspect ratio is not tested by the developer. Try anyway?", "Not tested aspect ratio detected", MessageBoxButtons.YesNo);
                    if (result != DialogResult.Yes)
                    {
                        return;
                    }
                break;
            }

            if (attributeStorage.CheckAspectRatioValues()) {
                String attributeStorageCheck = attributeStorage.CheckFileStorage();
                if (attributeStorageCheck.Length > 0) {
                    MessageBox.Show(attributeStorageCheck, "Storage element error", MessageBoxButtons.OK);
                    return;
                }

                FileRunner runner = new FileRunner(attributeStorage);
                if (backupCheckbox.Checked) {
                    runner.BackupFiles();
                }
                if (runner.ProcessFiles()) {
                    btnStart.Text = "Done";
                    btnStart.Enabled = false;
                    notifyIcon.ShowBalloonTip(1000);
                }
            }
            else
            {
                MessageBox.Show("Error while checking the aspect ratio values.", "Error", MessageBoxButtons.OK);
            }
        }

        private void ButtonManualOverride_Click(object sender, EventArgs e)
        {
            using (var resolutionOverrideWindow = new ResolutionOverride(attributeStorage.Width, attributeStorage.Height))
            {
                resolutionOverrideWindow.ShowDialog();
                attributeStorage.Width = resolutionOverrideWindow.GetOverrideWidth();
                attributeStorage.Height = resolutionOverrideWindow.GetOverrideHeight();
            }

            labelResolution.Text = attributeStorage.Width + " x" + attributeStorage.Height;
        }
    }
}