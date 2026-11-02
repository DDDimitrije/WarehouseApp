using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace WinFormsApp1
{
    public partial class Home : MovableResizableForm
    {
        public Home()
        {
            InitializeComponent();
            Button logoutButton = new()
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Location = new Point(20, 20),
                Size = new Size(110, 36),
                Text = "Logout"
            };
            logoutButton.Click += logoutButton_Click;
            Controls.Add(logoutButton);
            logoutButton.BringToFront();

            Button manageUsersButton = new()
            {
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                Location = new Point(ClientSize.Width - 170, ClientSize.Height - 62),
                Size = new Size(150, 36),
                Text = "Manage Users",
                Visible = UserSession.IsAdmin
            };
            manageUsersButton.Click += manageUsersButton_Click;
            Controls.Add(manageUsersButton);
            manageUsersButton.BringToFront();
            Theme.Apply(this);
            RoundButton(button1, 25);
            RoundButton(button2, 25);
            RoundButton(button3, 25);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logoutButton_Click(object? sender, EventArgs e)
        {
            UserSession.IsAdmin = false;
            Login login = new()
            {
                StartPosition = FormStartPosition.Manual,
                Location = Location
            };
            login.Show();
            Close();
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

        private void manageUsersButton_Click(object? sender, EventArgs e)
        {
            if (!UserSession.IsAdmin)
            {
                return;
            }

            UserManagementForm form = new()
            {
                StartPosition = FormStartPosition.Manual,
                Location = Location
            };
            form.Show();
            Close();
        }

        private void Home_Load(object sender, EventArgs e)
        {

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

    }
}
