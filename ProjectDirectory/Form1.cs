namespace ProjectDirectory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string Mark { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Mark == "ÒÑµÇÂ¼")
            {
                Book.BookShow BS = new Book.BookShow();
                BS.Show();
                this.Hide(); 
                BS.FormClosing += (object sender, FormClosingEventArgs e) => this.Show();

            }
            else
            {
                Book.Login BL = new Book.Login();
                BL.Show();
                BL.LoginMark += Lg_LoginMark;
                this.Hide();
                BL.FormClosing += (object sender, FormClosingEventArgs e) => this.Show();
            }
                

        }

        private void Lg_LoginMark(string mark)
        {
            this.Mark = mark;
            label2.Text = mark;
        }
    }
}
