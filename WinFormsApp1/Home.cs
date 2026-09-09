using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace WinFormsApp1
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            RoundButton(button1, 25);
            RoundButton(button2, 25);
            RoundButton(button3, 25);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            App app = new App();
            app.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Accessories acc = new Accessories();
            acc.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Selling sell = new Selling();
            sell.Show();
            this.Hide();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }
        // make form resizable
        private const int WM_NCHITTEST = 0x84;

        private const int HTLEFT = 10;
        private const int HTRIGHT = 11;
        private const int HTTOP = 12;
        private const int HTTOPLEFT = 13;
        private const int HTTOPRIGHT = 14;
        private const int HTBOTTOM = 15;
        private const int HTBOTTOMLEFT = 16;
        private const int HTBOTTOMRIGHT = 17;

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_NCHITTEST)
            {
                const int grip = 10;

                Point cursor = PointToClient(Cursor.Position);

                bool left = cursor.X <= grip;
                bool right = cursor.X >= ClientSize.Width - grip;
                bool top = cursor.Y <= grip;
                bool bottom = cursor.Y >= ClientSize.Height - grip;

                if (left && top)
                    m.Result = (IntPtr)HTTOPLEFT;
                else if (right && top)
                    m.Result = (IntPtr)HTTOPRIGHT;
                else if (left && bottom)
                    m.Result = (IntPtr)HTBOTTOMLEFT;
                else if (right && bottom)
                    m.Result = (IntPtr)HTBOTTOMRIGHT;
                else if (left)
                    m.Result = (IntPtr)HTLEFT;
                else if (right)
                    m.Result = (IntPtr)HTRIGHT;
                else if (bottom)
                    m.Result = (IntPtr)HTBOTTOM;
            }
        }

        // makes corners rounder
        private void UpdateRoundedCorners()
        {
            int radius = 25;

            using (GraphicsPath path = new GraphicsPath())
            {
                path.StartFigure();

                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(Width - radius, 0, radius, radius, 270, 90);
                path.AddArc(Width - radius, Height - radius, radius, radius, 0, 90);
                path.AddArc(0, Height - radius, radius, radius, 90, 90);

                path.CloseFigure();

                Region = new Region(path);
            }
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UpdateRoundedCorners();
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        // makes button rounder (need to be called in main for each button)
        private void RoundButton(Button button, int radius)
        {
            GraphicsPath path = new GraphicsPath();

            int d = radius * 2;

            path.AddArc(0, 0, d, d, 180, 90);
            path.AddArc(button.Width - d, 0, d, d, 270, 90);
            path.AddArc(button.Width - d, button.Height - d, d, d, 0, 90);
            path.AddArc(0, button.Height - d, d, d, 90, 90);

            path.CloseFigure();

            button.Region = new Region(path);
        }

        // make form movable
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam,int lParam);

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;
        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }
    }
}
