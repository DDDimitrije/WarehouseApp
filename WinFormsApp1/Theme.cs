using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    internal static class Theme
    {
        private static readonly Color White = Color.White;
        private static readonly Color LightGray = Color.FromArgb(238, 238, 238);
        private static readonly Color MediumGray = Color.FromArgb(204, 204, 204);
        private static readonly Color DarkGray = Color.FromArgb(64, 64, 64);
        private static readonly Color TextGray = Color.FromArgb(55, 55, 55);

        internal static void Apply(Form form)
        {
            form.BackColor = White;
            form.ForeColor = TextGray;
            ApplyToControls(form.Controls);
        }

        private static void ApplyToControls(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                switch (control)
                {
                    case DataGridView grid:
                        StyleGrid(grid);
                        break;
                    case Button button:
                        button.BackColor = DarkGray;
                        button.ForeColor = White;
                        button.FlatStyle = FlatStyle.Flat;
                        button.FlatAppearance.BorderColor = DarkGray;
                        button.FlatAppearance.MouseOverBackColor = Color.FromArgb(90, 90, 90);
                        button.FlatAppearance.MouseDownBackColor = Color.FromArgb(45, 45, 45);
                        button.UseVisualStyleBackColor = false;
                        break;
                    case TableLayoutPanel tableLayoutPanel:
                        tableLayoutPanel.BackColor = White;
                        break;
                    case Panel panel:
                        panel.BackColor = LightGray;
                        break;
                    case RichTextBox richTextBox:
                        richTextBox.BackColor = White;
                        richTextBox.ForeColor = TextGray;
                        break;
                    case TextBox textBox:
                        textBox.BackColor = White;
                        textBox.ForeColor = TextGray;
                        break;
                    case ComboBox comboBox:
                        comboBox.BackColor = White;
                        comboBox.ForeColor = TextGray;
                        break;
                    case Label label:
                        label.ForeColor = DarkGray;
                        break;
                    case ProgressBar progressBar:
                        progressBar.BackColor = LightGray;
                        progressBar.ForeColor = DarkGray;
                        break;
                    default:
                        control.BackColor = White;
                        control.ForeColor = TextGray;
                        break;
                }

                if (control.HasChildren)
                {
                    ApplyToControls(control.Controls);
                }
            }
        }

        private static void StyleGrid(DataGridView grid)
        {
            grid.BackgroundColor = White;
            grid.BorderStyle = BorderStyle.FixedSingle;
            grid.GridColor = MediumGray;
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersDefaultCellStyle.BackColor = DarkGray;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = White;
            grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = DarkGray;
            grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = White;
            grid.DefaultCellStyle.BackColor = White;
            grid.DefaultCellStyle.ForeColor = TextGray;
            grid.DefaultCellStyle.SelectionBackColor = MediumGray;
            grid.DefaultCellStyle.SelectionForeColor = TextGray;
            grid.RowsDefaultCellStyle.BackColor = White;
            grid.RowsDefaultCellStyle.ForeColor = TextGray;
            grid.AlternatingRowsDefaultCellStyle.BackColor = LightGray;
            grid.AlternatingRowsDefaultCellStyle.ForeColor = TextGray;
        }
    }
}
