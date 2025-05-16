using System;
using System.Windows.Forms;

namespace Dawn_of_War_Widescreen_Fix
{
    public partial class ResolutionOverride : Form
    {
        public ResolutionOverride(int width, int height)
        {
            InitializeComponent();
            this.numericUpDownWidth.Value = width;
            this.numericUpDownHeight.Value = height;
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        public int GetOverrideWidth()
        {
            return (int)this.numericUpDownWidth.Value;
        }

        public int GetOverrideHeight()
        {
            return (int)this.numericUpDownHeight.Value;
        }
    }
}
