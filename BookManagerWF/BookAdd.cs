using AntdUI;
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

namespace dayWF06.book
{
    public partial class BookAdd : Form
    {
        public BookAdd()
        {
            InitializeComponent();
            ucBook1.sendDada += AddBook;
        }

        private void AddBook(BookInfo books)
        {
            List<BookInfo> bookInfos = new List<BookInfo>();
            string jsonStr = "";
            if (File.Exists("./book.json"))
            {
                jsonStr = File.ReadAllText("./book.json");
                bookInfos = JsonSerializer.Deserialize<List<BookInfo>>(jsonStr);
            }
            bookInfos.Add(books);

            jsonStr = JsonSerializer.Serialize(bookInfos , new JsonSerializerOptions
            {
                WriteIndented = true,
                AllowTrailingCommas = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });

            File.WriteAllText("./book.json" ,jsonStr);

            MessageBox.Show("新增成功");
            this.Close();
        }
    }
}
