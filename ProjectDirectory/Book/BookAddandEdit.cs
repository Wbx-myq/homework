using AntdUI;
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
    public partial class BookAddandEdit : Form
    {
        private String Id {  get; set; }

        public BookAddandEdit()
        {
            InitializeComponent();
        }

        public BookAddandEdit(string text)
        {
            InitializeComponent();
            button1.Text = text;
            label1.Text = "图书" + text;
            button1.Click += AddBook;
        }

        public BookAddandEdit(string text , string Id)
        {
            InitializeComponent();
            button1.Text = text;
            label1.Text = "图书" + text;

            this.Id = Id;

            ShowData(Id);
            button1.Click += EditBook;
        }

        MySql mySql = new MySql("text");
        private async void AddBook(object sender, EventArgs e)
        {
            string sql = "insert into book(BookName,BookAuthor,BookPrice,BookLabel) values(@BookName,@BookAuthor,@BookPrice,@BookLabel) ";
            await mySql.Connection(sql, Cmd =>
            {
                Cmd.Parameters.AddWithValue("@BookName", inp1.Text);
                Cmd.Parameters.AddWithValue("@BookAuthor", inp2.Text);
                Cmd.Parameters.AddWithValue("@BookPrice", inpnum1.Value);
                Cmd.Parameters.AddWithValue("@BookLabel", inp3.Text.Replace("\r\n", "|"));

                int rows = Cmd.ExecuteNonQuery(); 
                if (rows >= 0)
                {
                    MessageBox.Show("新增成功！");
                    this.Close();
                    
                }
                else
                {
                    MessageBox.Show("新增失败！");
                }

                return true;
            });
        }

        private async void EditBook(object sender, EventArgs e)
        {
            string sql = "update book set BookName = @BookName,BookAuthor = @BookAuthor,BookPrice = @BookPrice,BookLabel = @BookLabel where Id = @Id ";
            await mySql.Connection(sql, Cmd =>
            {
                Cmd.Parameters.AddWithValue("@BookName", inp1.Text);
                Cmd.Parameters.AddWithValue("@BookAuthor", inp2.Text);
                Cmd.Parameters.AddWithValue("@BookPrice", inpnum1.Value);
                Cmd.Parameters.AddWithValue("@BookLabel", inp3.Text.Replace("\r\n", "|"));

                Cmd.Parameters.AddWithValue("@Id", Id);

                int rows = Cmd.ExecuteNonQuery();
                if (rows >= 0)
                {
                    MessageBox.Show("编辑成功！");
                    this.Close();

                }
                else
                {
                    MessageBox.Show("编辑失败！");
                }
                return true;
            });
        }

        private async void ShowData(string Id) 
        {

            string sql = "select * from book where Id = @Id";

            await mySql.Connection(sql, Cmd =>
            {
                Cmd.Parameters.AddWithValue("@Id", Id);
                MySqlDataReader Reader = Cmd.ExecuteReader();

                bool IsRead = Reader.Read();
                if (!IsRead)
                {
                    MessageBox.Show("编辑失败!!!");
                    this.Close();
                    return false;
                }
                
                inp1.Text = Reader.GetString("BookName");
                inp2.Text = Reader.GetString("BookAuthor");
                inpnum1.Value = (decimal)Reader.GetDouble("BookPrice"); 
                inp3.Text = Reader.GetString("BookLabel").Replace("|", "\n");

                return true;
            });

            
        }
    }
}
