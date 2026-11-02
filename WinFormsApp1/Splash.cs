namespace WinFormsApp1
{
    public partial class Splash : MovableResizableForm
    {
        public Splash()
        {
            InitializeComponent();
            MinimumSize = new Size(700, 350);
            progressBar1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Resize += (_, _) => LayoutSplash();
            LayoutSplash();
            Theme.Apply(this);
        }

        private void LayoutSplash()
        {
            int contentHeight = label1.Height + 12 + pictureBox1.Height;
            int contentTop = Math.Max(24, (ClientSize.Height - contentHeight) / 2 - 35);
            label1.Location = new Point((ClientSize.Width - label1.Width) / 2, contentTop);
            pictureBox1.Location = new Point(
                (ClientSize.Width - pictureBox1.Width) / 2,
                label1.Bottom + 12);

            int horizontalMargin = Math.Max(32, ClientSize.Width / 20);
            int verticalMargin = Math.Max(24, ClientSize.Height / 12);
            progressBar1.SetBounds(
                horizontalMargin,
                ClientSize.Height - verticalMargin - progressBar1.Height,
                Math.Max(100, ClientSize.Width - horizontalMargin * 2),
                progressBar1.Height);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        int startpoint = 10;
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            startpoint += 5;
            progressBar1.Value = startpoint;
            if (progressBar1.Value == 100)
            {
                progressBar1.Value = 0;
                timer1.Stop();
                Login log = new Login();
                log.Show();
                this.Hide();
            }
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
