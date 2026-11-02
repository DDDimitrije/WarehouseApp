namespace WinFormsApp1
{
    partial class App
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            Mobidtb = new TextBox();
            brandtb = new TextBox();
            label5 = new Label();
            label6 = new Label();
            modeltb = new TextBox();
            pricetb = new TextBox();
            label7 = new Label();
            stocktb = new TextBox();
            label8 = new Label();
            label9 = new Label();
            ramcb = new ComboBox();
            romcb = new ComboBox();
            label10 = new Label();
            cameratb = new TextBox();
            label11 = new Label();
            panel1 = new Panel();
            label12 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            MobileDGV = new DataGridView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            button5 = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MobileDGV).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.HotTrack;
            label1.Location = new Point(304, 9);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(410, 47);
            label1.TabIndex = 2;
            label1.Text = "Warehouse Management";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Maroon;
            label2.Location = new Point(995, 9);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(25, 30);
            label2.TabIndex = 3;
            label2.Text = "X";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.DarkBlue;
            label3.Location = new Point(410, 57);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(171, 30);
            label3.TabIndex = 4;
            label3.Text = "Manage Mobiles";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.DarkBlue;
            label4.Location = new Point(30, 152);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(32, 30);
            label4.TabIndex = 5;
            label4.Text = "Id";
            // 
            // Mobidtb
            // 
            Mobidtb.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Mobidtb.Location = new Point(68, 149);
            Mobidtb.Margin = new Padding(4, 3, 4, 3);
            Mobidtb.Multiline = false;
            Mobidtb.Name = "Mobidtb";
            Mobidtb.Size = new Size(106, 33);
            Mobidtb.TabIndex = 6;
            Mobidtb.Text = "";
            // 
            // brandtb
            // 
            brandtb.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            brandtb.Location = new Point(276, 149);
            brandtb.Margin = new Padding(4, 3, 4, 3);
            brandtb.Multiline = false;
            brandtb.Name = "brandtb";
            brandtb.Size = new Size(160, 33);
            brandtb.TabIndex = 8;
            brandtb.Text = "";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.DarkBlue;
            label5.Location = new Point(200, 152);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(70, 30);
            label5.TabIndex = 7;
            label5.Text = "Brand";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.DarkBlue;
            label6.Location = new Point(470, 152);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(74, 30);
            label6.TabIndex = 9;
            label6.Text = "Model";
            // 
            // modeltb
            // 
            modeltb.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            modeltb.Location = new Point(550, 149);
            modeltb.Margin = new Padding(4, 3, 4, 3);
            modeltb.Multiline = false;
            modeltb.Name = "modeltb";
            modeltb.Size = new Size(160, 33);
            modeltb.TabIndex = 10;
            modeltb.Text = "";
            // 
            // pricetb
            // 
            pricetb.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pricetb.Location = new Point(805, 149);
            pricetb.Margin = new Padding(4, 3, 4, 3);
            pricetb.Multiline = false;
            pricetb.Name = "pricetb";
            pricetb.Size = new Size(128, 33);
            pricetb.TabIndex = 12;
            pricetb.Text = "";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.DarkBlue;
            label7.Location = new Point(740, 152);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(59, 30);
            label7.TabIndex = 11;
            label7.Text = "Price";
            // 
            // stocktb
            // 
            stocktb.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            stocktb.Location = new Point(102, 218);
            stocktb.Margin = new Padding(4, 3, 4, 3);
            stocktb.Multiline = false;
            stocktb.Name = "stocktb";
            stocktb.Size = new Size(101, 33);
            stocktb.TabIndex = 14;
            stocktb.Text = "";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.DarkBlue;
            label8.Location = new Point(30, 222);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(66, 30);
            label8.TabIndex = 13;
            label8.Text = "Stock";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.DarkBlue;
            label9.Location = new Point(227, 222);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(117, 30);
            label9.TabIndex = 15;
            label9.Text = "RAM In Gb";
            // 
            // ramcb
            // 
            ramcb.FormattingEnabled = true;
            ramcb.Items.AddRange(new object[] { "1", "2", "4", "6", "8", "16", "32", "64" });
            ramcb.Location = new Point(352, 228);
            ramcb.Margin = new Padding(4, 3, 4, 3);
            ramcb.Name = "ramcb";
            ramcb.Size = new Size(121, 23);
            ramcb.TabIndex = 17;
            ramcb.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // romcb
            // 
            romcb.FormattingEnabled = true;
            romcb.Items.AddRange(new object[] { "8", "16", "32", "64", "128", "256" });
            romcb.Location = new Point(612, 228);
            romcb.Margin = new Padding(4, 3, 4, 3);
            romcb.Name = "romcb";
            romcb.Size = new Size(121, 23);
            romcb.TabIndex = 19;
            romcb.SelectedIndexChanged += romcb_SelectedIndexChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.DarkBlue;
            label10.Location = new Point(490, 222);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(119, 30);
            label10.TabIndex = 18;
            label10.Text = "ROM In Gb";
            // 
            // cameratb
            // 
            cameratb.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cameratb.Location = new Point(903, 218);
            cameratb.Margin = new Padding(4, 3, 4, 3);
            cameratb.Multiline = false;
            cameratb.Name = "cameratb";
            cameratb.Size = new Size(87, 33);
            cameratb.TabIndex = 21;
            cameratb.Text = "";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.DarkBlue;
            label11.Location = new Point(750, 222);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(147, 30);
            label11.TabIndex = 20;
            label11.Text = "Camera In MP";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Highlight;
            panel1.Controls.Add(label12);
            panel1.Location = new Point(-1, 318);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1034, 42);
            panel1.TabIndex = 22;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.DarkBlue;
            label12.Location = new Point(432, 4);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(147, 30);
            label12.TabIndex = 21;
            label12.Text = "Mobiles Stock";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaption;
            button1.Font = new Font("Gadugi", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(227, 269);
            button1.Margin = new Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new Size(130, 33);
            button1.TabIndex = 23;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ActiveCaption;
            button2.Font = new Font("Gadugi", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(365, 269);
            button2.Margin = new Padding(4, 3, 4, 3);
            button2.Name = "button2";
            button2.Size = new Size(130, 33);
            button2.TabIndex = 24;
            button2.Text = "Update";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.ActiveCaption;
            button3.Font = new Font("Gadugi", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.Location = new Point(503, 269);
            button3.Margin = new Padding(4, 3, 4, 3);
            button3.Name = "button3";
            button3.Size = new Size(130, 33);
            button3.TabIndex = 25;
            button3.Text = "Remove";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = SystemColors.ActiveCaption;
            button4.Font = new Font("Gadugi", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.Location = new Point(641, 269);
            button4.Margin = new Padding(4, 3, 4, 3);
            button4.Name = "button4";
            button4.Size = new Size(130, 33);
            button4.TabIndex = 26;
            button4.Text = "Clear";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // MobileDGV
            // 
            MobileDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            MobileDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            MobileDGV.Location = new Point(-1, 355);
            MobileDGV.MultiSelect = false;
            MobileDGV.Name = "MobileDGV";
            MobileDGV.ReadOnly = true;
            MobileDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            MobileDGV.Size = new Size(1034, 298);
            MobileDGV.TabIndex = 27;
            MobileDGV.CellContentClick += MobileDGV_CellContentClick;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // button5
            // 
            button5.BackColor = SystemColors.ActiveCaption;
            button5.Font = new Font("Gadugi", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button5.Location = new Point(13, 12);
            button5.Margin = new Padding(4, 3, 4, 3);
            button5.Name = "button5";
            button5.Size = new Size(28, 27);
            button5.TabIndex = 28;
            button5.Text = "↩";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // App
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            ClientSize = new Size(1280, 720);
            Controls.Add(button5);
            Controls.Add(MobileDGV);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(panel1);
            Controls.Add(cameratb);
            Controls.Add(label11);
            Controls.Add(romcb);
            Controls.Add(label10);
            Controls.Add(ramcb);
            Controls.Add(label9);
            Controls.Add(stocktb);
            Controls.Add(label8);
            Controls.Add(pricetb);
            Controls.Add(label7);
            Controls.Add(modeltb);
            Controls.Add(label6);
            Controls.Add(brandtb);
            Controls.Add(label5);
            Controls.Add(Mobidtb);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "App";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "App";
            Load += App_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)MobileDGV).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox Mobidtb;
        private TextBox brandtb;
        private Label label5;
        private Label label6;
        private TextBox modeltb;
        private TextBox pricetb;
        private Label label7;
        private TextBox stocktb;
        private Label label8;
        private Label label9;
        private ComboBox ramcb;
        private ComboBox romcb;
        private Label label10;
        private TextBox cameratb;
        private Label label11;
        private Panel panel1;
        private Label label12;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private DataGridView MobileDGV;
        private ContextMenuStrip contextMenuStrip1;
        private Button button5;
    }
}