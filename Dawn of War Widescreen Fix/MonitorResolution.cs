using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public static class MonitorResolution
{
    private const int ENUM_CURRENT_SETTINGS = -1;

    /// <summary>
    /// Win32 DEVMODE struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    private struct DEVMODE
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string dmDeviceName;
        public ushort dmSpecVersion;
        public ushort dmDriverVersion;
        public ushort dmSize;
        public ushort dmDriverExtra;
        public int dmFields;
        public int dmPositionX;
        public int dmPositionY;
        public int dmDisplayOrientation;
        public int dmDisplayFixedOutput;
        public short dmColor;
        public short dmDuplex;
        public short dmYResolution;
        public short dmTTOption;
        public short dmCollate;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string dmFormName;
        public short dmLogPixels;
        public int dmBitsPerPel;
        public int dmPelsWidth;
        public int dmPelsHeight;
        public int dmDisplayFlags;
        public int dmDisplayFrequency;
        public int dmICMMethod;
        public int dmICMIntent;
        public int dmMediaType;
        public int dmDitherType;
        public int dmReserved1;
        public int dmReserved2;
        public int dmPanningWidth;
        public int dmPanningHeight;
    }

    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    private static extern bool EnumDisplaySettings(string deviceName, int modeNum, ref DEVMODE devMode);

    /// <summary>Represents the physical resolution of a monitor.</summary>
    public class Monitor
    {
        public string DeviceName { get; }
        public int Width { get; }
        public int Height { get; }

        public Monitor(string deviceName, int width, int height)
        {
            DeviceName = deviceName;
            Width = width;
            Height = height;
        }

        public override string ToString() => $"{DeviceName}: {Width}×{Height}";
    }

    /// <summary>Retrieves the physical resolutions of all connected monitors, independent of any Windows DPI scaling settings.</summary>
    public static IReadOnlyList<Monitor> GetAll()
    {
        bool apiError = false;
        List<Monitor> list = new List<Monitor>();
        foreach (Screen screen in Screen.AllScreens)
        {
            DEVMODE dm = new DEVMODE
            {
                dmSize = (ushort)Marshal.SizeOf(typeof(DEVMODE))
            };

            if (EnumDisplaySettings(screen.DeviceName, ENUM_CURRENT_SETTINGS, ref dm))
            {
                list.Add(new Monitor(screen.DeviceName, dm.dmPelsWidth, dm.dmPelsHeight));
            } else {
                // Fallback to logical if API call fails
                list.Add(new Monitor(screen.DeviceName, screen.Bounds.Width, screen.Bounds.Height));
                apiError = true;
            }
        }
        if (apiError)
        {
            MessageBox.Show("EnumDisplaySettings error. Fallback to logical API, which does not take DPI scaling into account!", "Warning", MessageBoxButtons.OK);
        }
        return list;
    }

    public static bool DifferentResolutionMonitorssPresent(IReadOnlyList<Monitor> monitors)
    {
        if (monitors == null || monitors.Count < 2)
        {
            return false;
        }
        Monitor firstMonitor = monitors[0];
        int firstWidth = firstMonitor.Width, firstHeight = firstMonitor.Height;
        for (int i = 1; i < monitors.Count; i++)
        {
            Monitor current = monitors[i];
            if (current.Width != firstWidth || current.Height != firstHeight)
            {
                return true;
            }
        }
        return false;
    }

    public static Monitor GetScreenFromUser(IReadOnlyList<Monitor> options)
    {
        Monitor selectedOption = null;

        using (Form form = new Form())
        {
            form.Text = "Select Resolution";
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterParent;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AutoSize = true;
            form.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            form.ControlBox = false;
            form.BackColor = Color.FromName("ControlDarkDark");

            // Main container panel
            TableLayoutPanel mainPanel = new TableLayoutPanel
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Dock = DockStyle.Fill,
                ColumnCount = 1
            };

            // Add information label
            Label infoLabel = new Label
            {
                Text = "Multiple screens with different resolutions detected.\nPlease select the resolution for the patch:",
                AutoSize = true,
                Margin = new Padding(10, 10, 10, 2),
                Font = new Font(form.Font, FontStyle.Bold)
            };

            // Radio buttons container
            FlowLayoutPanel radioPanel = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.TopDown,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                WrapContents = false
            };

            // Add radio buttons
            List<RadioButton> radioButtons = new List<RadioButton>();
            foreach (var option in options)
            {
                RadioButton rb = new RadioButton
                {
                    Text = option.ToString(),
                    AutoSize = true,
                    Margin = new Padding(10, 5, 5, 5)
                };
                radioPanel.Controls.Add(rb);
                radioButtons.Add(rb);
            }

            // Preselect first radio button
            if (radioButtons.Count > 0)
            {
                radioButtons[0].Checked = true;
            }

            // OK button container
            FlowLayoutPanel buttonPanel = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.RightToLeft,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Margin = new Padding(0, 15, 10, 10)
            };

            Button okButton = new Button
            {
                Text = "OK",
                DialogResult = DialogResult.OK,
                Margin = new Padding(5),
                BackColor = Color.FromName("ControlLight")
            };

            buttonPanel.Controls.Add(okButton);


            mainPanel.Controls.Add(infoLabel);
            mainPanel.Controls.Add(radioPanel);
            mainPanel.Controls.Add(buttonPanel);
            form.Controls.Add(mainPanel);

            form.MaximumSize = new Size(600, Screen.PrimaryScreen.WorkingArea.Height);

            form.AcceptButton = okButton;

            if (form.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < radioButtons.Count; i++)
                {
                    RadioButton rb = radioButtons[i];
                    if (rb.Checked)
                    {
                        selectedOption = options[i];
                        break;
                    }
                }
            }
        }

        return selectedOption;
    }
}