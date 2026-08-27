using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace day03
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            //光标移动
            this.MouseMove += this_MouseMove;
            
            textBox1.Leave += textBox1_Leave;

            textBox1.GotFocus += textBox1_GotFocus;

            comboBox1.GotFocus += comboBox1_GotFocus;

            comboBox1.Leave += comboBox1_Leave;

            textBox2.KeyPress += textBox2_KeyPress;
        }
        //只能输入数字
        private void textBox2_KeyPress(object? sender, KeyPressEventArgs e)
        {
            //if(Regex.IsMatch((e.KeyChar).ToString(),@"\d")) e.Handled = false;
            //else e.Handled = true;
            if (e.KeyChar < '0' || e.KeyChar > '9') e.Handled = true;
        }
        //下拉框操作
        private void comboBox1_Leave(object? sender, EventArgs e)
        {
            (sender as ComboBox).DroppedDown = false;
        }

        private void comboBox1_GotFocus(object? sender, EventArgs e)
        {
            (sender as ComboBox).DroppedDown = true;
        }
        //手机号通过不通过
        private void textBox1_GotFocus(object? sender, EventArgs e)
        {
            label4.Visible = false;
            label5.Visible = false;
        }

        private void textBox1_Leave(object? sender, EventArgs e)
        {
            string content = (sender as TextBox).ToString();
            if (Regex.IsMatch(content, @"1[1-9]\d{9}")) label4.Visible = true;
            else label5.Visible = true;
        }
        //光标坐标移动
        private void this_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = "光标X轴坐标：" + e.X.ToString();
            label2.Text = "光标Y轴坐标：" + e.Y.ToString();
        }
    }
}
