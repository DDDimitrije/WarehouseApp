using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Accessories : MovableResizableForm
    {
        public Accessories()
        {
            InitializeComponent();
            MinimumSize = new Size(950, 550);
            ConfigureBackButton(button5);
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label12.Dock = DockStyle.Fill;
            label12.TextAlign = ContentAlignment.MiddleCenter;
            AccessoryDGV.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.SetBounds(0, panel1.Top, ClientSize.Width, panel1.Height);
            AccessoryDGV.SetBounds(0, panel1.Bottom, ClientSize.Width, ClientSize.Height - panel1.Bottom);
            CenterControlsHorizontally(967,
                label4, AidTb, label5, AbrandTb, label6, AmodelTb, label7, ApriceTb,
                label8, AstockTb, button1, button2, button3, button4);
            CenterControlHorizontally(label1);
            CenterControlHorizontally(label3);
            Theme.Apply(this);
            RoundButton(button1, 25);
            RoundButton(button2, 25);
            RoundButton(button3, 25);
            RoundButton(button4, 25);
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-B0M9AK9\SQLEXPRESS;Initial Catalog=MobiWarehouseDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
        private void populate()
        {
            con.Open();
            String query = "select * from AccessorieTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            AccessoryDGV.DataSource = ds.Tables[0];
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (AidTb.Text == "" || AbrandTb.Text == "" || AmodelTb.Text == "" || ApriceTb.Text == "" || AstockTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    String sql = "insert into AccessorieTbl values(" + AidTb.Text + ",'" + AbrandTb.Text + "','" + AmodelTb.Text + "'," + AstockTb.Text + "," + ApriceTb.Text + ")";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Accessory added successfully.");
                    con.Close();
                    populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void AmodelTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void Accessories_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AidTb.Text = "";
            AbrandTb.Text = "";
            AmodelTb.Text = "";
            ApriceTb.Text = "";
            AstockTb.Text = "";

        }

        private void AccessoryDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = AccessoryDGV.Rows[e.RowIndex];

            AidTb.Text = AccessoryDGV.SelectedRows[0].Cells[0].Value.ToString();
            AbrandTb.Text = AccessoryDGV.SelectedRows[0].Cells[1].Value.ToString();
            AmodelTb.Text = AccessoryDGV.SelectedRows[0].Cells[2].Value.ToString();
            AstockTb.Text = AccessoryDGV.SelectedRows[0].Cells[3].Value.ToString();
            ApriceTb.Text = AccessoryDGV.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (AidTb.Text == "")
            {
                MessageBox.Show("Enter the accessory to be removed.");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "delete from AccessorieTbl where AId=" + AidTb.Text + "";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Accessory removed.");
                    con.Close();
                    populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (AidTb.Text == "" || AbrandTb.Text == "" || AmodelTb.Text == "" || AstockTb.Text == "" || ApriceTb.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    con.Open();
                    String sql = "update AccessorieTbl set Abrand='" + AbrandTb.Text + "',AModel='" + AmodelTb.Text + "',AStock=" + AstockTb.Text + ",APrice=" + ApriceTb.Text + "where AId=" + AidTb.Text + ";";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Accessory update successfully.");
                    con.Close();
                    populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
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

        private void button5_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
    }

}
