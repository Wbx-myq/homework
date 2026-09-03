using MySqlConnector;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace ProjectDirectory.Book
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            select1.Items = ["01班","02班","03班","04班"];
        }

        MySql mySql = new MySql("text");

        private async void RegisterUser(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(input1.Text) || string.IsNullOrWhiteSpace(input2.Text))
            {
                MessageBox.Show("用户名和密码不能为空！");
                return ;
            }
             
            if(Regex.IsMatch(input1.Text, @"[a-zA-Z\u4e00-\u9fa5]\d{2,15}")) 
            {
                MessageBox.Show("用户名格式不对，请重试！");
                return;
            }

            if (input2.Text.Length >= 6 && input2.Text.Length <= 15)
            {
                MessageBox.Show("密码格式不对，请重试！");
                return;
            }
            if (input2.Text != input3.Text)
            {
                MessageBox.Show("两次密码输入不一致！");
                return ;
            }

            if (select1.SelectedValue == null)
            {
                MessageBox.Show("班级未选择!");
                return;
            }

            string sqlName = "select * from user where username = @username";

            bool isName = await mySql.Connection(sqlName, Cmd =>
            {
                Cmd.Parameters.AddWithValue("@username", input1.Text);
                MySqlDataReader Reader = Cmd.ExecuteReader();
                bool isRead = Reader.Read();
                return !isRead;
            });

            if (!isName)
            {
                MessageBox.Show("用户名已存在，请重试！");
                return;
            }

            string sql = "insert into user(username,password,age,gender,banji) values(@username,@password,@age,@gender,@banji) ";
            await mySql.Connection(sql, Cmd =>
            {
                Cmd.Parameters.AddWithValue("@username", input1.Text);
                Cmd.Parameters.AddWithValue("@password", input2.Text);
                Cmd.Parameters.AddWithValue("@age", inputNumber1.Value);
                string genderVal = "";
                if (radio1.Checked) //男
                {
                    genderVal = "男";
                }
                else if (radio2.Checked) //女
                {
                    genderVal = "女";
                }
                Cmd.Parameters.AddWithValue("@gender", genderVal);
                Cmd.Parameters.AddWithValue("@banji", select1.SelectedValue);

                int rows = Cmd.ExecuteNonQuery();
                if (rows >= 0)
                {
                    MessageBox.Show("注册成功！");
                    this.Close();

                }
                else
                {
                    MessageBox.Show("注册失败！");
                }

                return true;

            });
        }

        
    }
}
