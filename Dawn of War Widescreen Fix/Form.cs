using System;
using System.Windows.Forms;

namespace Dawn_of_War_Widescreen_Fix
{
    public partial class Form : System.Windows.Forms.Form
    {
        readonly AttributeStorage attributeStorage;
        public Form()
        {
            InitializeComponent();
            attributeStorage = new AttributeStorage();
            this.DragEnter += new DragEventHandler(Form_DragEnter);
            this.DragDrop += new DragEventHandler(Form_DragDrop);
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

            if (radioButton1920.Checked)
            {
                attributeStorage.Width = 1920;
                attributeStorage.Height = 1080;
            }
            else if (radioButton1680.Checked)
            {
                attributeStorage.Width = 1680;
                attributeStorage.Height = 1050;
            }
            else if (radioButton1366.Checked)
            {
                attributeStorage.Width = 1366;
                attributeStorage.Height = 768;
            }
            else if (radioButtonAutoDetect.Checked)
            {
                attributeStorage.Width = (ushort) Screen.PrimaryScreen.Bounds.Width;
                attributeStorage.Height = (ushort) Screen.PrimaryScreen.Bounds.Height;
            }
            else
            {
                DialogResult result = MessageBox.Show("No resolution has been set.\nUse auto detection?", "No resolution set", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    attributeStorage.Width = (ushort)Screen.PrimaryScreen.Bounds.Width;
                    attributeStorage.Height = (ushort)Screen.PrimaryScreen.Bounds.Height;
                }
                else
                {
                    return;
                }
            }

            attributeStorage.CalculateAspectRatio();
                    
            switch (attributeStorage.AspectRatio)
            {
                case "16/9":
                    attributeStorage.ReplacementString  = "398EE33F";
                break;
 
                case "16/10":
                    attributeStorage.ReplacementString = "CCCCCD3F";
                break;

                default:
                    DialogResult result = MessageBox.Show("Your aspect ratio is not tested. Try anyway?", "Not tested aspect ratio detected", MessageBoxButtons.YesNo);
                    if (result != DialogResult.Yes)
                    {
                        return;
                    }
                    attributeStorage.CalculateAspectRatioString();
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
    }
}