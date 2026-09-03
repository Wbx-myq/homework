using AntdUI;
using MySqlConnector;
using ProjectDirectory.Book;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ProjectDirectory.Book
{
    public partial class BookShow : Form
    {
        MySql mySql = new MySql("text");

        public BookShow()
        {
            InitializeComponent();
            ShowData();
            table1.CellButtonClick += Table1_CellButtonClick;
        }

        private void Table1_CellButtonClick(object sender, TableButtonEventArgs e)
        {
            System.Data.DataRow books = e.Record as System.Data.DataRow;

            if (e.Btn.Text == "删除")
            {
                if (books == null) return;
                if (MessageBox.Show($"确定删除《{books["BookName"]}》？", "删除确认",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }
                Del(books["id"].ToString());
                ShowData(); // 删除完主动刷新表格
            }
            else if (e.Btn.Text == "编辑")
            {
                if (books == null) return;
                if (MessageBox.Show($"确定编辑《{books["BookName"]}》？", "编辑确认",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }

                BookAddandEdit BAE = new BookAddandEdit("编辑", books["Id"].ToString());
                BAE.FormClosing += (s, args) =>
                {
                    this.Show();
                    ShowData();
                };
                BAE.Show();
                this.Hide();
            }
            if (e.Btn.Text == "借阅")
            {
                // 借阅：设置IsBorrow=1
                if (books == null) return;
                if (MessageBox.Show($"确定借阅《{books["BookName"]}》？", "借阅确认",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }
                BorrowReturn(books["Id"].ToString(), "1");
                MessageBox.Show($"已借阅《{books["BookName"]}》");
                ShowData();

            }
            else if (e.Btn.Text == "归还")
            {
                // 归还：设置IsBorrow=0
                if (books == null) return;
                if (MessageBox.Show($"确定归还《{books["BookName"]}》？", "归还确认",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }
                BorrowReturn(books["Id"].ToString(), "0");
                MessageBox.Show($"已归还《{books["BookName"]}》");
                ShowData();
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            BookAddandEdit BAE = new BookAddandEdit("新增");
            BAE.Show();
            this.Hide();
            BAE.FormClosing += (object sender, FormClosingEventArgs e) =>
            {
                this.Show();
                ShowData();
            };
        }

       
        private async void ShowData()
        {
            string sql = "select * from book";

            await mySql.Connection(sql, Cmd =>
            {
                MySqlDataAdapter Ada = new MySqlDataAdapter(Cmd);
                DataTable dt = new DataTable();
                Ada.Fill(dt);

                table1.DataSource = dt;
                SetColumn();

                return true;
            });


        }

        private void SetColumn()
        {
            table1.Columns.Clear();
            table1.Columns = new AntdUI.ColumnCollection
            {
                new AntdUI.Column("Id", "编号")
                {
                    Render = (object val,object cel,int index ) =>(index+1).ToString()

                },
                new AntdUI.Column("BookName", "书名"),
                new AntdUI.Column("BookAuthor", "作者"),
                new AntdUI.Column("BookPrice", "价格"),
                new AntdUI.Column("BookLabel", "标签"),
                new AntdUI.Column("IsBorrow", "是否借阅")
                {
                    // val 单元的值, cel: 行数据, index 行号
                    Render = (object val,object cel,int index) =>
                    {
                        //return (bool)val?"已借阅":"书架中";
                       return val.ToString()=="1"?"已借阅":"书架中";
                    }
                },
            };

            var HandlerCol = new AntdUI.Column("handler", "操作");
            HandlerCol.SetAlign();
            HandlerCol.Render = (object val, object cel, int index) =>
            {
                var _btns = new AntdUI.CellLink[] {
                        new AntdUI.CellButton("edit", "编辑", AntdUI.TTypeMini.Default),
                        new AntdUI.CellButton("delete", "删除", AntdUI.TTypeMini.Default)
                   };
                return _btns;

            };
            table1.Columns.Add(HandlerCol);

            var RentReturnCol = new AntdUI.Column("RentReturn", "借阅归还");
            RentReturnCol.SetAlign();
            RentReturnCol.Render = (object val, object cel, int index) =>
            {
                if (cel == null)
                {
                    return new AntdUI.CellLink[0];
                }
                var row = cel as System.Data.DataRow;
                if (row == null)
                    return new AntdUI.CellLink[0];

                string isBorrowStr = row["IsBorrow"].ToString();
                AntdUI.CellLink[] _btns;

                if (isBorrowStr == "1")
                {
                    _btns = new AntdUI.CellLink[]
                    {
                        new AntdUI.CellButton("return", "归还", AntdUI.TTypeMini.Default)
                    };
                }
                else
                {
                    _btns = new AntdUI.CellLink[]
                    {
                        new AntdUI.CellButton("borrow", "借阅", AntdUI.TTypeMini.Default)
                    };
                }
                return _btns;
            };
            table1.Columns.Add(RentReturnCol);
        }

        private async void Del(string Id)
        {
            string sql = "DELETE FROM book WHERE Id = @Id";

            await mySql.Connection(sql, Cmd =>
            {
                Cmd.Parameters.AddWithValue("@Id", Id);

                int rows = Cmd.ExecuteNonQuery(); //受影响行数：删除成功返回1；找不到数据返回0
                if (rows >= 0)
                {
                    MessageBox.Show("删除成功！");
                }
                else
                {
                    MessageBox.Show("数据库没有找到该图书，删除失败！");
                }

                MySqlDataAdapter adapter = new MySqlDataAdapter(Cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                table1.DataSource = dt;
                ShowData();

                return true;
            });
        }

        private async void BorrowReturn(string Id ,string s)
        {
            string sql = "update book set IsBorrow = @IsBorrow where Id = @Id ";
            await mySql.Connection(sql, Cmd =>
            {
                Cmd.Parameters.AddWithValue("@IsBorrow", s); 

                Cmd.Parameters.AddWithValue("@Id", Id);

                int affectRows = Cmd.ExecuteNonQuery();
                return affectRows > 0;
                
            });


        }
    }
}
