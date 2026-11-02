using System.Data;
using Microsoft.Data.SqlClient;

namespace WinFormsApp1
{
    internal sealed class UserManagementForm : MovableResizableForm
    {
        private readonly bool isInitialSetup;
        private readonly TextBox usernameTextBox = new();
        private readonly TextBox passwordTextBox = new();
        private readonly TextBox confirmPasswordTextBox = new();
        private readonly CheckBox showPasswordCheckBox = new();
        private readonly DataGridView usersGrid = new();
        private readonly Button addButton = new();
        private readonly Button changeButton = new();
        private readonly Button deleteButton = new();

        internal UserManagementForm(bool isInitialSetup = false)
        {
            this.isInitialSetup = isInitialSetup;
            Text = isInitialSetup ? "Set Up Administrator" : "Manage Users";
            ClientSize = new Size(1280, 720);
            MinimumSize = new Size(800, 480);
            StartPosition = FormStartPosition.CenterParent;

            Panel entryPanel = new() { Dock = DockStyle.Top, Height = 205, Padding = new Padding(20) };
            Button backButton = new();
            ConfigureBackButton(backButton);
            backButton.Click += BackButton_Click;
            Label titleLabel = new()
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                Location = new Point(112, 15),
                Text = isInitialSetup ? "Create the first administrator" : "Manage user accounts"
            };
            Label usernameLabel = CreateLabel("Username", 20, 66);
            usernameTextBox.Location = new Point(125, 64);
            usernameTextBox.Size = new Size(180, 28);
            Label passwordLabel = CreateLabel("New password (optional)", 330, 66);
            passwordTextBox.Location = new Point(490, 64);
            passwordTextBox.Size = new Size(155, 28);
            passwordTextBox.UseSystemPasswordChar = true;
            showPasswordCheckBox.AutoSize = true;
            showPasswordCheckBox.Location = new Point(650, 68);
            showPasswordCheckBox.Text = "Show";
            showPasswordCheckBox.CheckedChanged += ShowPasswordCheckBox_CheckedChanged;
            Label confirmPasswordLabel = CreateLabel("Confirm new password", 20, 112);
            confirmPasswordTextBox.Location = new Point(165, 110);
            confirmPasswordTextBox.Size = new Size(150, 28);
            confirmPasswordTextBox.UseSystemPasswordChar = true;
            addButton.Location = new Point(330, 150);
            addButton.Size = new Size(110, 36);
            addButton.Text = isInitialSetup ? "Create Admin" : "Add User";
            addButton.Click += AddButton_Click;
            changeButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            changeButton.Location = new Point(450, 150);
            changeButton.Size = new Size(140, 36);
            changeButton.Text = "Change Selected";
            changeButton.Enabled = false;
            changeButton.Click += ChangeButton_Click;
            deleteButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            deleteButton.Location = new Point(600, 150);
            deleteButton.Size = new Size(140, 36);
            deleteButton.Text = "Delete Selected";
            deleteButton.Enabled = false;
            deleteButton.Click += DeleteButton_Click;

            entryPanel.Controls.AddRange(
            [
                backButton,
                titleLabel,
                usernameLabel,
                usernameTextBox,
                passwordLabel,
                passwordTextBox,
                showPasswordCheckBox,
                confirmPasswordLabel,
                confirmPasswordTextBox,
                addButton,
                changeButton,
                deleteButton
            ]);
            CenterControlsHorizontally(740,
                backButton, titleLabel, usernameLabel, usernameTextBox, passwordLabel,
                passwordTextBox, showPasswordCheckBox, confirmPasswordLabel,
                confirmPasswordTextBox, addButton, changeButton, deleteButton);

            usersGrid.Dock = DockStyle.Fill;
            usersGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            usersGrid.ReadOnly = true;
            usersGrid.AllowUserToAddRows = false;
            usersGrid.AllowUserToDeleteRows = false;
            usersGrid.MultiSelect = false;
            usersGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            usersGrid.SelectionChanged += UsersGrid_SelectionChanged;

            Controls.Add(usersGrid);
            Controls.Add(entryPanel);
            Theme.Apply(this);

            if (!isInitialSetup && !UserSession.IsAdmin)
            {
                throw new InvalidOperationException("Only an administrator can manage user accounts.");
            }

            Load += UserManagementForm_Load;
            FormClosed += UserManagementForm_FormClosed;
        }

        private void BackButton_Click(object? sender, EventArgs e)
        {
            Close();
        }

        private void ShowPasswordCheckBox_CheckedChanged(object? sender, EventArgs e)
        {
            passwordTextBox.UseSystemPasswordChar = !showPasswordCheckBox.Checked;
            confirmPasswordTextBox.UseSystemPasswordChar = !showPasswordCheckBox.Checked;
        }

        private void UserManagementForm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            if (!isInitialSetup && UserSession.IsAdmin)
            {
                Home home = new();
                home.Show();
            }
        }

        private static Label CreateLabel(string text, int x, int y)
        {
            return new Label
            {
                AutoSize = true,
                Location = new Point(x, y),
                Text = text
            };
        }

        private void UserManagementForm_Load(object? sender, EventArgs e)
        {
            if (isInitialSetup)
            {
                usersGrid.Visible = false;
                changeButton.Visible = false;
                deleteButton.Visible = false;
                return;
            }

            try
            {
                LoadUsers();
            }
            catch (SqlException exception)
            {
                MessageBox.Show(this, $"Unable to load users from the database.\n\n{exception.Message}", "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void AddButton_Click(object? sender, EventArgs e)
        {
            string username = usernameTextBox.Text.Trim();
            string password = passwordTextBox.Text;

            if (username.Length is 0 or > 50)
            {
                MessageBox.Show(this, "Enter a username containing 1 to 50 characters.", "Invalid username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password.Length < 8)
            {
                MessageBox.Show(this, "Use a password with at least 8 characters.", "Invalid password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmPasswordTextBox.Text)
            {
                MessageBox.Show(this, "The passwords do not match.", "Invalid password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (isInitialSetup)
                {
                    if (!UserRepository.CreateFirstAdmin(username, password))
                    {
                        MessageBox.Show(this, "An administrator has already been created. Close this window and sign in.", "Setup complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.Cancel;
                        Close();
                        return;
                    }

                    DialogResult = DialogResult.OK;
                    Close();
                    return;
                }

                UserRepository.AddUser(username, password);
                LoadUsers();
                ClearEntryFields();
                MessageBox.Show(this, "User added successfully.", "User added", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException exception) when (exception.Number is 2601 or 2627)
            {
                MessageBox.Show(this, "That username is already in use.", "Duplicate username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (SqlException exception)
            {
                MessageBox.Show(this, $"Unable to save the user.\n\n{exception.Message}", "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChangeButton_Click(object? sender, EventArgs e)
        {
            if (!TryGetSelectedUserId(out int userId))
            {
                MessageBox.Show(this, "Select a user to change.", "No user selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string username = usernameTextBox.Text.Trim();
            string password = passwordTextBox.Text;
            if (username.Length is 0 or > 50)
            {
                MessageBox.Show(this, "Enter a username containing 1 to 50 characters.", "Invalid username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password.Length > 0 && password.Length < 8)
            {
                MessageBox.Show(this, "Use a new password with at least 8 characters, or leave it blank to keep the current password.", "Invalid password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmPasswordTextBox.Text)
            {
                MessageBox.Show(this, "The new passwords do not match.", "Invalid password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (!UserRepository.UpdateUser(userId, username, password.Length == 0 ? null : password))
                {
                    MessageBox.Show(this, "The selected user no longer exists.", "User not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LoadUsers();
                    return;
                }

                LoadUsers();
                ClearEntryFields();
                MessageBox.Show(this, "User updated successfully.", "User updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException exception) when (exception.Number is 2601 or 2627)
            {
                MessageBox.Show(this, "That username is already in use.", "Duplicate username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (SqlException exception)
            {
                MessageBox.Show(this, $"Unable to update the user.\n\n{exception.Message}", "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteButton_Click(object? sender, EventArgs e)
        {
            if (!TryGetSelectedUserId(out int userId))
            {
                MessageBox.Show(this, "Select a user to delete.", "No user selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string username = Convert.ToString(usersGrid.SelectedRows[0].Cells["Username"].Value) ?? "this user";
            if (MessageBox.Show(this, $"Delete the account for '{username}'?", "Confirm deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                if (!UserRepository.DeleteUser(userId))
                {
                    MessageBox.Show(this, "The user was not deleted. It may no longer exist, or it may be the last administrator account.", "Unable to delete user", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LoadUsers();
                    return;
                }

                LoadUsers();
                ClearEntryFields();
                MessageBox.Show(this, "User deleted successfully.", "User deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException exception)
            {
                MessageBox.Show(this, $"Unable to delete the user.\n\n{exception.Message}", "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UsersGrid_SelectionChanged(object? sender, EventArgs e)
        {
            bool hasSelectedUser = !isInitialSetup && usersGrid.SelectedRows.Count == 1;
            changeButton.Enabled = hasSelectedUser;
            deleteButton.Enabled = hasSelectedUser;

            if (hasSelectedUser)
            {
                usernameTextBox.Text = Convert.ToString(usersGrid.SelectedRows[0].Cells["Username"].Value) ?? string.Empty;
                passwordTextBox.Clear();
                confirmPasswordTextBox.Clear();
            }
        }

        private bool TryGetSelectedUserId(out int userId)
        {
            userId = 0;
            return usersGrid.SelectedRows.Count == 1
                && usersGrid.SelectedRows[0].Cells["UserId"].Value is int selectedUserId
                && (userId = selectedUserId) > 0;
        }

        private void ClearEntryFields()
        {
            usernameTextBox.Clear();
            passwordTextBox.Clear();
            confirmPasswordTextBox.Clear();
        }

        private void LoadUsers()
        {
            usersGrid.DataSource = UserRepository.GetUsers();
        }
    }
}
