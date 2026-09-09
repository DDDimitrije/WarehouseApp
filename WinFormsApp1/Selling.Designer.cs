namespace WinFormsApp1
{
    partial class Selling
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Selling));
            label1 = new Label();
            label4 = new Label();
            label2 = new Label();
            label3 = new Label();
            label6 = new Label();
            BillTb = new RichTextBox();
            ProductTb = new RichTextBox();
            PriceTb = new RichTextBox();
            QuantityTb = new RichTextBox();
            label5 = new Label();
            label7 = new Label();
            label8 = new Label();
            button2 = new Button();
            MobileDGV = new DataGridView();
            AccessoryDGV = new DataGridView();
            label9 = new Label();
            BillDGV = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            button1 = new Button();
            AmountLbl = new Label();
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            printPreviewDialog1 = new PrintPreviewDialog();
            button5 = new Button();
            ClientNameTb = new RichTextBox();
            label10 = new Label();
            panel1 = new Panel();
            SellamtLbl = new Label();
            label12 = new Label();
            label11 = new Label();
            label13 = new Label();
            ((System.ComponentModel.ISupportInitialize)MobileDGV).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AccessoryDGV).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BillDGV).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.HotTrack;
            label1.Location = new Point(350, 9);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(392, 47);
            label1.TabIndex = 6;
            label1.Text = "Warehouse Managment";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(35, 177);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(66, 30);
            label4.TabIndex = 23;
            label4.Text = "Bill Id";
            label4.Click += label4_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(35, 273);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(59, 30);
            label2.TabIndex = 24;
            label2.Text = "Price";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(35, 225);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(89, 30);
            label3.TabIndex = 24;
            label3.Text = "Product";
            label3.Click += label3_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(35, 321);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(96, 30);
            label6.TabIndex = 26;
            label6.Text = "Quantity";
            label6.Click += label6_Click;
            // 
            // BillTb
            // 
            BillTb.BackColor = SystemColors.ScrollBar;
            BillTb.Location = new Point(139, 179);
            BillTb.Name = "BillTb";
            BillTb.Size = new Size(100, 28);
            BillTb.TabIndex = 27;
            BillTb.Text = "";
            BillTb.TextChanged += richTextBox1_TextChanged;
            // 
            // ProductTb
            // 
            ProductTb.BackColor = SystemColors.ScrollBar;
            ProductTb.Location = new Point(139, 227);
            ProductTb.Name = "ProductTb";
            ProductTb.Size = new Size(100, 28);
            ProductTb.TabIndex = 28;
            ProductTb.Text = "";
            ProductTb.TextChanged += richTextBox2_TextChanged;
            // 
            // PriceTb
            // 
            PriceTb.BackColor = SystemColors.ScrollBar;
            PriceTb.Location = new Point(139, 275);
            PriceTb.Name = "PriceTb";
            PriceTb.Size = new Size(100, 28);
            PriceTb.TabIndex = 29;
            PriceTb.Text = "";
            PriceTb.TextChanged += richTextBox3_TextChanged;
            // 
            // QuantityTb
            // 
            QuantityTb.BackColor = SystemColors.ScrollBar;
            QuantityTb.Location = new Point(139, 323);
            QuantityTb.Name = "QuantityTb";
            QuantityTb.Size = new Size(100, 28);
            QuantityTb.TabIndex = 30;
            QuantityTb.Text = "";
            QuantityTb.TextChanged += richTextBox4_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(509, 56);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(75, 30);
            label5.TabIndex = 31;
            label5.Text = "Selling";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(524, 104);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(88, 30);
            label7.TabIndex = 32;
            label7.Text = "Mobiles";
            label7.Click += label7_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(814, 104);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(122, 30);
            label8.TabIndex = 33;
            label8.Text = "Accessories";
            label8.Click += label8_Click;
            // 
            // button2
            // 
            button2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button2.BackColor = Color.FromArgb(192, 255, 255);
            button2.Cursor = Cursors.Hand;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Gadugi", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(149, 392);
            button2.Margin = new Padding(4, 3, 4, 3);
            button2.Name = "button2";
            button2.Size = new Size(106, 36);
            button2.TabIndex = 35;
            button2.Text = "Add To Bill";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // MobileDGV
            // 
            MobileDGV.AllowUserToResizeColumns = false;
            MobileDGV.AllowUserToResizeRows = false;
            MobileDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            MobileDGV.BorderStyle = BorderStyle.None;
            MobileDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            MobileDGV.Location = new Point(440, 141);
            MobileDGV.MultiSelect = false;
            MobileDGV.Name = "MobileDGV";
            MobileDGV.ReadOnly = true;
            MobileDGV.RowHeadersVisible = false;
            MobileDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            MobileDGV.Size = new Size(257, 295);
            MobileDGV.TabIndex = 38;
            MobileDGV.CellContentClick += MobileDGV_CellContentClick;
            // 
            // AccessoryDGV
            // 
            AccessoryDGV.AllowUserToResizeColumns = false;
            AccessoryDGV.AllowUserToResizeRows = false;
            AccessoryDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            AccessoryDGV.BorderStyle = BorderStyle.None;
            AccessoryDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            AccessoryDGV.Location = new Point(747, 141);
            AccessoryDGV.MultiSelect = false;
            AccessoryDGV.Name = "AccessoryDGV";
            AccessoryDGV.ReadOnly = true;
            AccessoryDGV.RowHeadersVisible = false;
            AccessoryDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            AccessoryDGV.Size = new Size(257, 295);
            AccessoryDGV.TabIndex = 39;
            AccessoryDGV.CellContentClick += AccessoryDGV_CellContentClick;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.Black;
            label9.Location = new Point(185, 440);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(41, 30);
            label9.TabIndex = 40;
            label9.Text = "Bill";
            // 
            // BillDGV
            // 
            BillDGV.AllowUserToResizeColumns = false;
            BillDGV.AllowUserToResizeRows = false;
            BillDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            BillDGV.BorderStyle = BorderStyle.None;
            BillDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            BillDGV.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5 });
            BillDGV.Location = new Point(35, 473);
            BillDGV.MultiSelect = false;
            BillDGV.Name = "BillDGV";
            BillDGV.ReadOnly = true;
            BillDGV.RowHeadersVisible = false;
            BillDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            BillDGV.Size = new Size(341, 199);
            BillDGV.TabIndex = 41;
            // 
            // Column1
            // 
            Column1.HeaderText = "Id";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // Column2
            // 
            Column2.HeaderText = "Product";
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            // 
            // Column3
            // 
            Column3.HeaderText = "Price";
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            // 
            // Column4
            // 
            Column4.HeaderText = "Quantity";
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            // 
            // Column5
            // 
            Column5.HeaderText = "Total";
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            // 
            // button1
            // 
            button1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button1.BackColor = Color.FromArgb(192, 255, 255);
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Gadugi", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(481, 664);
            button1.Margin = new Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new Size(106, 36);
            button1.TabIndex = 42;
            button1.Text = "Print";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // AmountLbl
            // 
            AmountLbl.AutoSize = true;
            AmountLbl.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AmountLbl.ForeColor = Color.Black;
            AmountLbl.Location = new Point(489, 618);
            AmountLbl.Margin = new Padding(4, 0, 4, 0);
            AmountLbl.Name = "AmountLbl";
            AmountLbl.Size = new Size(91, 30);
            AmountLbl.TabIndex = 43;
            AmountLbl.Text = "Amount";
            // 
            // printDocument1
            // 
            printDocument1.PrintPage += printDocument1_PrintPage;
            // 
            // printPreviewDialog1
            // 
            printPreviewDialog1.AutoScrollMargin = new Size(0, 0);
            printPreviewDialog1.AutoScrollMinSize = new Size(0, 0);
            printPreviewDialog1.ClientSize = new Size(400, 300);
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.Enabled = true;
            printPreviewDialog1.Icon = (Icon)resources.GetObject("printPreviewDialog1.Icon");
            printPreviewDialog1.Name = "printPreviewDialog1";
            printPreviewDialog1.Visible = false;
            printPreviewDialog1.Load += printPreviewDialog1_Load;
            // 
            // button5
            // 
            button5.BackColor = SystemColors.ActiveCaption;
            button5.Font = new Font("Gadugi", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button5.Location = new Point(13, 9);
            button5.Margin = new Padding(4, 3, 4, 3);
            button5.Name = "button5";
            button5.Size = new Size(28, 27);
            button5.TabIndex = 44;
            button5.Text = "↩";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // ClientNameTb
            // 
            ClientNameTb.BackColor = SystemColors.ScrollBar;
            ClientNameTb.Location = new Point(139, 131);
            ClientNameTb.Name = "ClientNameTb";
            ClientNameTb.Size = new Size(100, 28);
            ClientNameTb.TabIndex = 46;
            ClientNameTb.Text = "";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.Black;
            label10.Location = new Point(35, 129);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(67, 30);
            label10.TabIndex = 45;
            label10.Text = "Client";
            // 
            // panel1
            // 
            panel1.Controls.Add(SellamtLbl);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(label11);
            panel1.Location = new Point(692, 473);
            panel1.Name = "panel1";
            panel1.Size = new Size(282, 145);
            panel1.TabIndex = 47;
            // 
            // SellamtLbl
            // 
            SellamtLbl.AutoSize = true;
            SellamtLbl.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SellamtLbl.ForeColor = Color.Black;
            SellamtLbl.Location = new Point(94, 59);
            SellamtLbl.Margin = new Padding(4, 0, 4, 0);
            SellamtLbl.Name = "SellamtLbl";
            SellamtLbl.Size = new Size(91, 30);
            SellamtLbl.TabIndex = 48;
            SellamtLbl.Text = "Amount";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.Black;
            label12.Location = new Point(4, 59);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(48, 30);
            label12.TabIndex = 47;
            label12.Text = "Rsd";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.Black;
            label11.Location = new Point(69, -1);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(138, 30);
            label11.TabIndex = 46;
            label11.Text = "Sells Amount";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Cursor = Cursors.Hand;
            label13.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.Maroon;
            label13.Location = new Point(1055, 9);
            label13.Margin = new Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new Size(25, 30);
            label13.TabIndex = 48;
            label13.Text = "X";
            label13.Click += label13_Click;
            // 
            // Selling
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(1093, 718);
            Controls.Add(label13);
            Controls.Add(panel1);
            Controls.Add(ClientNameTb);
            Controls.Add(label10);
            Controls.Add(button5);
            Controls.Add(AmountLbl);
            Controls.Add(button1);
            Controls.Add(BillDGV);
            Controls.Add(label9);
            Controls.Add(AccessoryDGV);
            Controls.Add(MobileDGV);
            Controls.Add(button2);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(QuantityTb);
            Controls.Add(PriceTb);
            Controls.Add(ProductTb);
            Controls.Add(BillTb);
            Controls.Add(label6);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label4);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Selling";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Selling";
            Load += Selling_Load;
            ((System.ComponentModel.ISupportInitialize)MobileDGV).EndInit();
            ((System.ComponentModel.ISupportInitialize)AccessoryDGV).EndInit();
            ((System.ComponentModel.ISupportInitialize)BillDGV).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        #endregion

        private Label label1;
        private Label label4;
        private Label label2;
        private Label label3;
        private Label label6;
        private RichTextBox BillTb;
        private RichTextBox ProductTb;
        private RichTextBox PriceTb;
        private RichTextBox QuantityTb;
        private Label label5;
        private Label label7;
        private Label label8;
        private Button button2;
        private DataGridView MobileDGV;
        private DataGridView AccessoryDGV;
        private Label label9;
        private DataGridView BillDGV;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private Button button1;
        private Label AmountLbl;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private PrintPreviewDialog printPreviewDialog1;
        private Button button5;
        private RichTextBox ClientNameTb;
        private Label label10;
        private Panel panel1;
        private Label label11;
        private Label SellamtLbl;
        private Label label12;
        private Label label13;
    }
}