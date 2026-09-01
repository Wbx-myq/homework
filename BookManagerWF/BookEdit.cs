using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using dayWF06.Controls;

namespace dayWF06.book
{
    public partial class BookEdit : Form
    {
        public BookEdit()
        {
            InitializeComponent();
        }

        public BookEdit(string Id)
        {
            InitializeComponent();
            string jsonStr = "";
            List<BookInfo> bookInfos = new List<BookInfo>();
            if (!File.Exists("./book.json")) return;
            jsonStr = File.ReadAllText("./book.json");
            bookInfos = JsonSerializer.Deserialize<List<BookInfo>>(jsonStr);
            if (bookInfos == null || bookInfos.Count == 0) return;
            BookInfo books = bookInfos.Find(item => item.Id == Id);
            if (books == null) return;
            ucBook1.editBooksearch(books);

            ucBook1.EditComplete += EditBook;
        }

        private void EditBook(BookInfo book)
        {
            string jsonStr = "";
            List<BookInfo> bookInfos = new List<BookInfo>();

            if (!File.Exists("./book.json")) return;
            jsonStr = File.ReadAllText("./book.json");
            bookInfos = JsonSerializer.Deserialize<List<BookInfo>>(jsonStr);

            if (bookInfos == null || bookInfos.Count == 0) return;

            foreach (BookInfo bookInfo in bookInfos) 
            {
                bookInfo.BookName = book.BookName;
                bookInfo.BookAuthor = book.BookAuthor;
                bookInfo.BookPrice = book.BookPrice;
                bookInfo.BookLabel = book.BookLabel;
            }

            jsonStr = JsonSerializer.Serialize(bookInfos, new JsonSerializerOptions
            {
                WriteIndented = true,
                AllowTrailingCommas = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });

            File.WriteAllText("./book.json", jsonStr);

            MessageBox.Show("编辑成功");
            this.Close();

        }
    }
}
