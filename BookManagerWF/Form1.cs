using dayWF06.book;
namespace dayWF06
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            //新增图书
            button1.Click += Button1_Click;
            //编辑图书
            button2.Click += Button2_Click;
            //查询图书
            button3.Click += Button3_Click;

        }
        //新增图书
        private void Button1_Click(object sender, EventArgs e)
        {
            new book.BookAdd().Show();
        }
        //编辑图书
        private void Button2_Click(object sender, EventArgs e)
        {
            new book.BookEdit().Show();
        }
        //查询图书
        private void Button3_Click(object sender, EventArgs e)
        {
            new book.BookSearch().Show();
        }
    }
}
