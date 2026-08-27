using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homeworkWF01
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            //textBox1.KeyPress += TextBox1_KeyPress;
            textBox1.KeyDown += TextBox1_KeyDown;

            panel1.MouseLeave += panel1_MouseLeave;
            panel1.MouseEnter += panel1_MouseEnter;

            textBox2.TextChanged += textBox2_TextChanged;

            listBox1.Items.AddRange(CobItems.ToArray());
            textBox3.TextChanged += textBox3_TextChanged;

            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
        }

        private void TextBox1_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back || e.KeyCode == Keys.X)
            {
                e.SuppressKeyPress = true;
            }
        }

        //private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if(e.KeyChar == (char)8 || e.KeyChar == (char)127)
        //    {
        //        e.Handled = true;
        //    }
        //}

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            panel1.Width += 300;
            panel1.Height += 200;
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            panel1.Width -= 300;
            panel1.Height -= 200;
        }

        private int maxlength = 10;
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            //EventArgs as Args
            // 只要输入了内容，或删除一个字符都会执行
            if(textBox2.Text.Length > maxlength)
            {
                // 截取Text内容
                string str = textBox2.Text.Substring(0, 10);
                textBox2.Text = str;
                // 设置光标位置
                textBox2.SelectionStart = maxlength;
                // 阻止输入
                label3.Visible = true;
            }
            else
            {
                label3.Visible = false;
            }
        }

        private List<string> CobItems = new List<string>
        {
        "11112222333","22222","1111144444","222222444","444444","333333"
        };
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string keywords = textBox3.Text;
            List<string> resList = CobItems.FindAll(item => item.Contains(keywords));
            listBox1.Items.Clear();
            listBox1.Items.AddRange(resList.ToArray());

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = listBox1.SelectedItem.ToString();
            label5.Text = str;
        }
    }
}
