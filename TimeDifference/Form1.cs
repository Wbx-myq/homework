namespace TimeDifference
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer MyTimer1 { get; set; }
        public Form1()
        {
            InitializeComponent();
            show();
            ShowTime();
        }

        private void ShowTime()
        {
            MyTimer1 = new System.Windows.Forms.Timer();
            MyTimer1.Interval = 1000;
            MyTimer1.Tick += (object snender, EventArgs e) => show();

            MyTimer1.Start();
        }

        private void show()
        {
            // 获取当前时间对象
            DateTime dt = DateTime.Now;
            DateTime d1 = DateTime.Parse("2026-10-01 00:00:00");
            TimeSpan timeSpan = d1 - dt;
            //获取天数
            var day = timeSpan.Days.ToString();
            // 获取小时
            var hour = timeSpan.Hours.ToString();
            // 分钟
            var minute = timeSpan.Minutes.ToString();
            // 秒速
            var second = timeSpan.Seconds.ToString();

            pictureBox4.Image = Image.FromFile(@"./images/maohao.png");
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox7.Image = Image.FromFile(@"./images/maohao.png");
            pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox10.Image = Image.FromFile(@"./images/maohao.png");
            pictureBox10.SizeMode = PictureBoxSizeMode.StretchImage;
            // @"./images/数字.png"
            string timeStr = day.PadLeft(3, '0') + hour.PadLeft(2, '0') + minute.PadLeft(2, '0') + second.PadLeft(2, '0');
            //组织一下控件在数组中
            var picArr = new PictureBox[] {
                    pictureBox1,pictureBox2,pictureBox3,
                    pictureBox5,pictureBox6,pictureBox8,
                    pictureBox9,pictureBox11,pictureBox12
                };
            for (int i = 0; i < picArr.Length; i++)
            {
                picArr[i].SizeMode = PictureBoxSizeMode.StretchImage;
                picArr[i].Image = Image.FromFile(@"./images/" + timeStr[i] + ".png");
            }

        }
    }
}
