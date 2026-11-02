using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Login : MovableResizableForm
    {
        private bool databaseReady;
        private bool isInitialSetup;

        public Login()
        {
            InitializeComponent();
            MinimumSize = new Size(541, 629);

            int horizontalOffset = (ClientSize.Width - 541) / 2;
            int verticalOffset = (ClientSize.Height - 629) / 2;
            foreach (Control control in new Control[] { label1, pictureBox1, UidTb, PassTb, button1, label2, label3, label4 })
            {
                control.Location = new Point(control.Left + horizontalOffset, control.Top + verticalOffset);
                control.Anchor = AnchorStyles.None;
            }

            Theme.Apply(this);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (isInitialSetup)
            {
                using UserManagementForm setupForm = new(isInitialSetup: true);
                if (setupForm.ShowDialog(this) == DialogResult.OK)
                {
                    UidTb.Clear();
                    PassTb.Clear();
                    Login_Load(this, EventArgs.Empty);
                }

                return;
            }

            UidTb.Clear();
            PassTb.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!databaseReady)
            {
                return;
            }

            if (UidTb.Text.Trim().Length == 0 || PassTb.Text.Length == 0)
            {
                MessageBox.Show(this, "Enter username and password.", "Missing information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (isInitialSetup)
            {
                MessageBox.Show(this, "Create the first administrator account before signing in.", "Administrator setup required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                if (UserRepository.TryAuthenticate(UidTb.Text.Trim(), PassTb.Text, out bool isAdmin))
                {
                    UserSession.IsAdmin = isAdmin;
                    Home home = new();
                    home.Show();
                    Hide();
                    return;
                }

                MessageBox.Show(this, "Incorrect username or password.", "Sign-in failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Microsoft.Data.SqlClient.SqlException exception)
            {
                MessageBox.Show(this, $"Unable to sign in using the database.\n\n{exception.Message}", "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            try
            {
                UserRepository.EnsureUsersTable();
                isInitialSetup = UserRepository.GetUserCount() == 0;
                databaseReady = true;
                label4.Text = isInitialSetup ? "Set up administrator" : "Clear";
            }
            catch (Microsoft.Data.SqlClient.SqlException exception)
            {
                databaseReady = false;
                button1.Enabled = false;
                label4.Enabled = false;
                MessageBox.Show(this, $"Unable to connect to the warehouse database. Check the SQL Server connection and try again.\n\n{exception.Message}", "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
