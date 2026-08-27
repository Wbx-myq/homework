namespace homeworkWF01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Init();
        }
        private List<Dictionary<string, Control>> list = new List<Dictionary<string, Control>>();

        private List<TextBox> tb = new List<TextBox>();

        private List<Button> btn = new List<Button>();

        private void Init()
        {
            list.Add(new Dictionary<string, Control>()
            {
                ["price"] = label5,
                ["count"] = textBox1
            });
            list.Add(new Dictionary<string, Control>()
            {
                ["price"] = label7,
                ["count"] = textBox2
            });

            tb = [textBox1, textBox2];
            foreach (TextBox tb1 in tb)
            {
                tb1.TextChanged += Tb_TextChanged;
            }
            btn = [button1, button2, button3, button4];
            foreach (Button btn1 in btn)
            {
                btn1.MouseClick += Btn_MouseClick;
            }
        }


        private void Tb_TextChanged(object sender, EventArgs e)
        {
            int total = 0;

            foreach (Dictionary<string, Control> dict in list)
            {
                if (string.IsNullOrEmpty(dict["count"].Text.ToString()))
                {
                    total += int.Parse(dict["price"].Text.ToString()) * 0;
                    return;
                }
            }

            foreach (Dictionary<string, Control> dict in list)
            {
                int price = int.Parse(dict["price"].Text.ToString());
                int count = int.Parse(dict["count"].Text.ToString());
                total += price * count;
            }

            label9.Text = total.ToString();
        }

        private void Btn_MouseClick(object sender, MouseEventArgs e)
        {
            Button btnn = sender as Button;
            int count = 0;
            if (btnn != null)
            {
                if (btnn.Text.ToString() == "-")
                {
                    foreach (Dictionary<string, Control> dict in list)
                    {
                        count = int.Parse(dict["count"].Text.ToString());
                        count = count == 0 ? 0 : --count;
                        dict["count"].Text = count.ToString();
                    }
                }
                else
                {
                    foreach (Dictionary<string, Control> dict in list)
                    {
                        count = int.Parse(dict["count"].Text.ToString());
                        ++count;
                        dict["count"].Text = count.ToString();
                    }
                }
            }
        }
    }
}
