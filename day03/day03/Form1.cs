namespace day03
{
    public partial class Form1 : Form
    {
        //底部页码按钮集合 button1(1),button2(2),button3(3)
        private List<Button> btnList = new List<Button>();

        //底部页码label集合 label1(1),label2(2)
        private List<Label> labList = new List<Label>();

        //图片路径数组
        public string[] picArr = { @"./images/cat.jpg", @"./images/bird.jpg", @"./images/eagle.jpg" };
        private int currentIndex = 0;

        public Form1()
        {
            InitializeComponent();
            InitCarousel();
        }

        public void InitCarousel()
        {
            //把3个页码按钮加入集合
            btnList.Clear();
            btnList.AddRange([button1, button2, button3]);

            labList.Clear();
            labList.AddRange([label1, label2]);

            //绑定页码按钮点击事件，初始化样式
            foreach (var btn in btnList)
            {
                btn.Click += Btn_Click;
                btn.BackColor = Color.DarkGray;
                btn.ForeColor = Color.Black;
            }

            //初始图片、初始高亮第一个页码
            currentIndex = 0;
            pictureBox1.Image = Image.FromFile(picArr[currentIndex]);
            btnList[0].BackColor = Color.Cyan;
            btnList[0].ForeColor = Color.White;

            foreach (var lab in labList)
            {
                //左右箭头是Label！==> label1 < 上一张 -- label2 > 下一张
                lab.Click += label_Click;
                
                //给Label鼠标悬浮手型，提示可以点击
                lab.Cursor = Cursors.Hand;
            }
        }

        //底部数字页码按钮点击
        private void Btn_Click(object sender, EventArgs e)
        {
            Button clickBtn = sender as Button;

            //清空全部高亮
            foreach (var b in btnList)
            {
                b.BackColor = Color.DarkGray;
                b.ForeColor = Color.Black;
            }
            //当前按钮高亮
            clickBtn.BackColor = Color.Cyan;
            clickBtn.ForeColor = Color.White;

            currentIndex = btnList.IndexOf(clickBtn);
            UpdateCarouselUI();
        }
        //左右箭头Label
        private void label_Click(object sender, EventArgs e)
        {
            Label clicklab = sender as Label;
           
            if (clicklab.Text == "<")
            {
                // label1 < 上一张
                currentIndex = currentIndex == 0 ? picArr.Length - 1 : --currentIndex;
            }
            else if (clicklab.Text == ">")
            {
                //label2 > 下一张
                currentIndex = currentIndex == picArr.Length - 1 ? 0 : ++currentIndex;
            }
            
            UpdateCarouselUI();
        }

        //统一更新图片+页码高亮
        private void UpdateCarouselUI()
        {
            pictureBox1.Image = Image.FromFile(picArr[currentIndex]);

            foreach (var b in btnList)
            {
                b.BackColor = Color.DarkGray;
                b.ForeColor = Color.Black;
            }
            btnList[currentIndex].BackColor = Color.Cyan;
            btnList[currentIndex].ForeColor = Color.White;
        }
    }
}
