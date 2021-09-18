using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Onra2_Color_Picker
{
    public partial class Main : MaterialForm
    {
        [DllImport("user32.dll")]
        static extern bool GetCursorPos(ref Point lpPoint);

        [DllImport("User32.dll")]
        public static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("User32.dll")]
        public static extern void ReleaseDC(IntPtr hwnd, IntPtr dc);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern int BitBlt(IntPtr hDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);

        [DllImport("user32.dll", CharSet = CharSet.Auto),]
        public static extern int SystemParametersInfo(uint uiAction, uint uiParam, uint pvParam, uint fWinIni);

        Graphics g;
        Bitmap bmp;

        Form form2;

        public Main()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue700, Primary.Blue500, Primary.Blue700, Accent.Cyan700, TextShade.WHITE);
        }

        private void MouseMoveTimer_Tick(object sender, EventArgs e)
        {
            Point cursor = new Point();
            GetCursorPos(ref cursor);

            var c = GetColorAt(cursor);
            BackColor = c;

            labelRGB.Text = "R: " + c.R + " G: " + c.G + " B: " + c.B;
            Clipboard.SetText(c.R + ", " + c.G + ", " + c.B);

            var endWidth = pictureBox1.Width;
            var endHeight = pictureBox1.Height;

            const int scaleFactor = 5;

            var startWidth = endWidth / scaleFactor;
            var startHeight = endHeight / scaleFactor;

            bmp = new Bitmap(startWidth, startHeight);

            g = CreateGraphics();
            g = Graphics.FromImage(bmp);

            var xPos = Math.Max(0, MousePosition.X - (startWidth / 2));
            var yPos = Math.Max(0, MousePosition.Y - (startHeight / 2));

            g.CopyFromScreen(xPos, yPos, 0, 0, new Size(endWidth, endWidth));
            pictureBox1.Image = bmp;

            //move window
            Rectangle activeScreenDimensions = Screen.FromControl(this).Bounds;
            Left = (MousePosition.X < activeScreenDimensions.Width - this.Width) ? MousePosition.X + 20 : MousePosition.X - this.Width - 20;
            Top = (MousePosition.Y < activeScreenDimensions.Height - this.Height) ? MousePosition.Y + 20 : MousePosition.Y - this.Height - 20;
            TopMost = true;
        }

        private readonly Bitmap screenPixel = new Bitmap(1, 1, PixelFormat.Format32bppArgb);
        public Color GetColorAt(Point location)
        {
            using (Graphics gdest = Graphics.FromImage(screenPixel))
            {
                using (Graphics gsrc = Graphics.FromHwnd(IntPtr.Zero))
                {
                    IntPtr hSrcDC = gsrc.GetHdc();
                    IntPtr hDC = gdest.GetHdc();
                    int retval = BitBlt(hDC, 0, 0, 1, 1, hSrcDC, location.X, location.Y, (int)CopyPixelOperation.SourceCopy);
                    gdest.ReleaseHdc();
                    gsrc.ReleaseHdc();
                }
            }

            return screenPixel.GetPixel(0, 0);
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            Selection();
            MouseMoveTimer.Start();
        }

        private void Selection()
        {
            form2 = new Form
            {
                Opacity = 0.01,
                Cursor = Cursors.Cross,
                ControlBox = false,
                MaximizeBox = false,
                MinimizeBox = false,
                FormBorderStyle = FormBorderStyle.None,
                WindowState = FormWindowState.Maximized
            };
            form2.MouseUp += form2_MouseUp;

            form2.Show();
        }

        private void form2_MouseUp(object sender, MouseEventArgs e)
        {
            form2.Hide();
            form2.Close();
            MouseMoveTimer.Stop();
            Show();
            uint speed = 10;
            int res = SystemParametersInfo(113, 0, speed, 0);
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if ((ModifierKeys & Keys.Control) == Keys.Control)
            {
                uint speed = 3;
                int res = SystemParametersInfo(113, 0, speed, 0);
            }
            if ((ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                uint speed = 10;
                int res = SystemParametersInfo(113, 0, speed, 0);
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            uint speed = 10;
            int res = SystemParametersInfo(113, 0, speed, 0);
        }
    }
}
