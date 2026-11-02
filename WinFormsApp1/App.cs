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
    public partial class App : MovableResizableForm
    {
        public App()
        {
            InitializeComponent();
            MinimumSize = new Size(1000, 550);
            ConfigureBackButton(button5);
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label12.Dock = DockStyle.Fill;
            label12.TextAlign = ContentAlignment.MiddleCenter;
            MobileDGV.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.SetBounds(0, panel1.Top, ClientSize.Width, panel1.Height);
            MobileDGV.SetBounds(0, 360, ClientSize.Width, ClientSize.Height - 360);
            CenterControlsHorizontally(1020,
                label4, Mobidtb, label5, brandtb, label6, modeltb, label7, pricetb,
                label8, stocktb, label9, ramcb, label10, romcb, label11, cameratb,
                button1, button2, button3, button4);
            CenterControlHorizontally(label1);
            CenterControlHorizontally(label3);
            Theme.Apply(this);
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-B0M9AK9\SQLEXPRESS;Initial Catalog=MobiWarehouseDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void populate()
        {
            con.Open();
            String query = "select * from MobileTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            MobileDGV.DataSource = ds.Tables[0];
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Mobidtb.Text == "" || brandtb.Text == "" || modeltb.Text == "" || pricetb.Text == "" || stocktb.Text == "" || cameratb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    String sql = "insert into MobileTbl values('" + Mobidtb.Text + "','" + brandtb.Text + "','" + modeltb.Text + "','" + pricetb.Text + "','" + stocktb.Text + "','" + ramcb.SelectedItem.ToString() + "','" + romcb.SelectedItem.ToString() + "','" + cameratb.Text + "')";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Mobile added successfully.");
                    con.Close();
                    populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void romcb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void App_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void MobileDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = MobileDGV.Rows[e.RowIndex];

            Mobidtb.Text = MobileDGV.SelectedRows[0].Cells[0].Value.ToString();
            brandtb.Text = MobileDGV.SelectedRows[0].Cells[1].Value.ToString();
            modeltb.Text = MobileDGV.SelectedRows[0].Cells[2].Value.ToString();
            pricetb.Text = MobileDGV.SelectedRows[0].Cells[3].Value.ToString();
            stocktb.Text = MobileDGV.SelectedRows[0].Cells[4].Value.ToString();
            ramcb.SelectedItem = MobileDGV.SelectedRows[0].Cells[5].Value.ToString();
            romcb.SelectedItem = MobileDGV.SelectedRows[0].Cells[6].Value.ToString();
            cameratb.Text = MobileDGV.SelectedRows[0].Cells[7].Value.ToString();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Mobidtb.Text = "";
            brandtb.Text = "";
            modeltb.Text = "";
            pricetb.Text = "";
            stocktb.Text = "";
            cameratb.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Mobidtb.Text == "")
            {
                MessageBox.Show("Select the mobile to be deleted.");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "delete from MobileTbl where MobId=" + Mobidtb.Text + "";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Mobile Deleted.");
                    con.Close();
                    populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Mobidtb.Text == "" || brandtb.Text == "" || modeltb.Text == "" || pricetb.Text == "" || stocktb.Text == "" || cameratb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    String sql = "update MobileTbl set Mbrand='" + brandtb.Text + "',MModel='" + modeltb.Text + "',MPrice=" + pricetb.Text + ",MStock=" + stocktb.Text + ",MRam=" + ramcb.SelectedItem.ToString() + ",MRom=" + romcb.SelectedItem.ToString() + ",MCam=" + cameratb.Text + " where MobId=" + Mobidtb.Text + ";";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Mobile updated successfully.");
                    con.Close();
                    populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
    }
}
