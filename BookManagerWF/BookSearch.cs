using AntdUI;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Reflection.Metadata.BlobBuilder;

namespace dayWF06.book
{
    public partial class BookSearch : Form
    {
        public BookSearch()
        {
            InitializeComponent();
            SearchBook();
        }
        private void SearchBook()
        {
            string jsonStr = File.ReadAllText("./book.json");
            List<BookInfo> books = JsonSerializer.Deserialize<List<BookInfo>>(jsonStr);
            table1.DataSource = books;

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
                new AntdUI.Column("IsBorrow", "是否借阅"){
                    // val 单元的值, cel: 行数据, index 行号
                    Render = (object val,object cel,int index) =>
                    {
                        return (bool)val?"已借阅":"书架中";
                    }
                },
            };

            table1.Columns.Add(new AntdUI.Column("Handler", "操作")
            {
                Render = (object val, object cel, int index) => "删除"
            });
            table1.Columns.Add(new AntdUI.Column("Handler2", "操作")
            {
                Render = (object val, object cel, int index) => "编辑"
            });

            // 绑定事件
            table1.CellClick += Table1_CellClick;
        }

        private void Table1_CellClick(object sender, TableClickEventArgs e)
        {
            //拿到当前这一行的图书
            BookInfo books = (e.Record as BookInfo);
            
            if (e.ColumnIndex.ToString() == "6")
            {
                if (books == null) return;

                //确认弹窗
                if (MessageBox.Show($"确定删除《{books.BookName}》？", "删除确认",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }

                //删除文件里的书籍数据
                string jsonStr = "";
                List<BookInfo> bookInfos = new List<BookInfo>();
                //如果文件不存在
                if (!File.Exists("./book.json")) return;
                jsonStr = File.ReadAllText("./book.json");
                bookInfos = JsonSerializer.Deserialize<List<BookInfo>>(jsonStr);
                if (bookInfos == null) return;
                var delBook = bookInfos.Find(item => item.Id == books.Id);
                if(delBook != null) bookInfos.Remove(delBook);

                jsonStr = JsonSerializer.Serialize(bookInfos, new JsonSerializerOptions
                {
                    WriteIndented = true,
                    AllowTrailingCommas = true,
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                });
                File.WriteAllText("./book.json", jsonStr);

                table1.DataSource = bookInfos;
                
            }
            else
            {
                if (books == null) return;

                //确认弹窗
                if (MessageBox.Show($"确定编辑《{books.BookName}》？", "编辑确认",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }
                else
                {
                    new book.BookEdit(books.Id).Show();
                }

                string jsonStr = File.ReadAllText("./book.json");
                List<BookInfo> bookInfos = JsonSerializer.Deserialize<List<BookInfo>>(jsonStr);
                if (bookInfos == null) return;
                table1.DataSource = bookInfos;
            }
        }
    }
}
