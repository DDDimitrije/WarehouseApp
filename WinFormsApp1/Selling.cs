using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Microsoft.Data.SqlClient;

namespace WinFormsApp1
{
    public partial class Selling : MovableResizableForm
    {
        public Selling()
        {
            InitializeComponent();
            MinimumSize = new Size(1032, 680);
            ConfigureBackButton(button5);
            MobileDGV.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            AccessoryDGV.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            BillDGV.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            CenterControlsHorizontally(1034,
                label4, label2, label3, label6, BillTb, ProductTb, PriceTb, QuantityTb,
                label7, label8, button2, label9, button1, AmountLbl,
                ClientNameTb, label10);
            int layoutOffset = (ClientSize.Width - 1034) / 2;
            BillDGV.Left += layoutOffset;
            MobileDGV.Left += layoutOffset;
            AccessoryDGV.Left += layoutOffset;
            panel1.Left += layoutOffset;
            CenterControlHorizontally(label1);
            CenterControlHorizontally(label5);
            AmountLbl.Anchor = AnchorStyles.Bottom;
            button1.Anchor = AnchorStyles.Bottom;
            Theme.Apply(this);

            RoundButton(button2, 15);
            RoundButton(button1, 15);

        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-B0M9AK9\SQLEXPRESS;Initial Catalog=MobiWarehouseDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
        private void populate()
        {
            con.Open();
            String query = "select Mbrand,MModel,Mprice from MobileTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            MobileDGV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void populateAccessory()
        {
            con.Open();
            String query = "select ABrand,AModel,APrice from AccessorieTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            AccessoryDGV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void insertBill()
        {
            if (ClientNameTb.Text == "" || BillTb.Text == "" || ProductTb.Text == "" || PriceTb.Text == "" || QuantityTb.Text == "")
            {
                MessageBox.Show("Missing Information.");
            }
            else
            {
                int amount = Convert.ToInt32(AmountLbl.Text);
                try
                {
                    con.Open();
                    String sql = "insert into BillTbl values(" + BillTb.Text + ",'" + ClientNameTb.Text + "'," + amount + ")";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();

                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Selling_Load(object sender, EventArgs e)
        {
            populate();
            populateAccessory();
            Sum();
        }

        private void Sum()
        {
            string query = "select sum(Amt) from BillTbl";
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            SellamtLbl.Text = dt.Rows[0][0].ToString();
            con.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        int n = 0, GrdTotal = 0;
        private void button2_Click(object sender, EventArgs e)
        {

            if (QuantityTb.Text == "" || PriceTb.Text == "")
            {
                MessageBox.Show("Enter the Quantity.");
            }
            else
            {
                int total = Convert.ToInt32(QuantityTb.Text) * Convert.ToInt32(PriceTb.Text);
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(BillDGV);
                newRow.Cells[0].Value = n + 1;
                newRow.Cells[1].Value = ProductTb.Text;
                newRow.Cells[2].Value = PriceTb.Text;
                newRow.Cells[3].Value = QuantityTb.Text;
                newRow.Cells[4].Value = total;
                BillDGV.Rows.Add(newRow);
                n++;
                GrdTotal = GrdTotal + total;
                AmountLbl.Text = "" + GrdTotal;
            }
        }

        private void MobileDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ProductTb.Text = MobileDGV.SelectedRows[0].Cells[0].Value.ToString() + MobileDGV.SelectedRows[0].Cells[1].Value.ToString();
            PriceTb.Text = MobileDGV.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void AccessoryDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ProductTb.Text = AccessoryDGV.SelectedRows[0].Cells[0].Value.ToString() + AccessoryDGV.SelectedRows[0].Cells[1].Value.ToString();
            PriceTb.Text = AccessoryDGV.SelectedRows[0].Cells[2].Value.ToString();
        }

        int prodid, prodqty, prodprice, tottal, pos = 60;
        string prodname;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Warehouse", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Red, new Point(80));
            e.Graphics.DrawString("ID PRODUCT PRICE QUANTITY TOTAL", new Font("Century Gothic", 9, FontStyle.Bold), Brushes.Red, new Point(26, 40));
            foreach (DataGridViewRow row in BillDGV.Rows)
            {
                prodid = Convert.ToInt32(row.Cells["Column1"].Value);
                prodname = "" + row.Cells["Column2"].Value;
                prodprice = Convert.ToInt32(row.Cells["Column3"].Value);
                prodqty = Convert.ToInt32(row.Cells["Column4"].Value);
                tottal = Convert.ToInt32(row.Cells["Column5"].Value);
                e.Graphics.DrawString("" + prodid, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(26, pos));
                e.Graphics.DrawString("" + prodname, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(45, pos));
                e.Graphics.DrawString("" + prodprice, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(120, pos));
                e.Graphics.DrawString("" + prodqty, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(170, pos));
                e.Graphics.DrawString("" + tottal, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(235, pos));
                pos = pos + 20;
            }
            e.Graphics.DrawString("Grand Total: RSD" + GrdTotal, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Crimson, new Point(50, pos + 50));
            e.Graphics.DrawString("----------------------Warehouse----------------------", new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Crimson, new Point(10, pos + 85));
            BillDGV.Rows.Clear();
            BillDGV.Refresh();
            pos = 100;
            GrdTotal = 0;
            n = 0;
            insertBill();
            Sum();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 285, 600);
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
