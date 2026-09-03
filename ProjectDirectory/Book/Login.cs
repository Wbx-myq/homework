using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectDirectory.Book
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        MySql mySql = new MySql("text");

        public event Action<string> LoginMark;

        private async void button1_Click(object sender, EventArgs e)
        {
            if (input1.Text.Trim() == "" || input2.Text.Trim() == "")
            {
                MessageBox.Show("用户名或密码不能为空");
                return;
            }
            string sql = "select  * from user where username = @username and password = @password ";
            
            await mySql.Connection(sql, Cmd =>
            {
                Cmd.Parameters.AddWithValue("@username", input1.Text);
                Cmd.Parameters.AddWithValue("@password", input2.Text);

                MySqlDataReader Reader = Cmd.ExecuteReader();
                bool IsLogin = Reader.Read();

                if (IsLogin)
                {
                    MessageBox.Show("登陆成功");
                    LoginMark.Invoke("已登录");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("用户名或密码错误!!!");
                    LoginMark.Invoke("未登录");
                    this.Close();
                }

                return true;
            });
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Hide();
            register.FormClosing += (object sender, FormClosingEventArgs e) =>
            {
                this.Show();
            };
        }
    }
}
