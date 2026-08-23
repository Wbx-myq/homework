using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace homework12
{
    internal class BookManager
    {
        // 属性：
        // 数据文件路径
        public string path { get; }
        // JSON序列化配置项
        public JsonSerializerOptions JsonOpts { get; }

        // 新增数据：强制要求 ==> 将list写入文件中
        public string AddBook(Dictionary<string, dynamic> bookDic)
        {

            // 判断图书是否已存在===>根据图书名判断(一个书名只有一本)

            // 新增的逻辑处理
            // 判断path路径是存在===> 不存在, 组装书籍list,序列化后 写入文件
            // 如果存在 =====> 先读取文件内容
            // 反序列化为list ====> 添加bookDic到list中
            // 序列化list ====> 写入文件
            List<Dictionary<string, dynamic>> bookList = new();
            if (!File.Exists(path)) return "还未有书籍记录，请添加";
            // 读取文件===>反序列化
            var json = File.ReadAllText(path);
            // 反序列化
            bookList = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(json);
            foreach (var item in bookList)
            {
                if (item["name"].ToString() == bookDic["name"])
                {
                    return "书籍已存在";
                }
            }
            bookList.Add(bookDic);
            //序列化
            string jsonStr = JsonSerializer.Serialize(bookList, JsonOpts);
            // 写入文件
            File.WriteAllText(path, jsonStr);

            return "新增数据成功!!!";
        }
        // 编辑数据
        public string EditBook(string bookName)
        {
            // 编辑的逻辑处理
            Console.WriteLine("--图书编辑--");
            List<Dictionary<string, object>> bookList = new();


            if (!File.Exists(path)) return "还未有书籍记录，请添加";
            var json = File.ReadAllText(path);
            bookList = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(json);
            if (bookList.Exists(item => item["name"].ToString() == bookName))
            {
                //编辑字典
                Console.WriteLine("请输入编辑书名");
                string editBookName = Console.ReadLine();
                Console.WriteLine("请输入编辑作者");
                string editAuthor = Console.ReadLine();
                Console.WriteLine("请输入编辑标签");
                string editMark = Console.ReadLine();
                Console.WriteLine("请输入编辑价格");
                double editPrice = double.Parse(Console.ReadLine());
                foreach (var item in bookList)
                {
                    if (item["name"].ToString() != bookName)
                    {
                        continue;
                    }
                    else
                    {
                        item["name"] = editBookName;
                        item["author"] = editAuthor;
                        item["mark"] = editMark;
                        item["price"] = editPrice;
                    }
                }
            }else return "书籍不存在";
            string jsonStr = JsonSerializer.Serialize(bookList, JsonOpts);
            File.WriteAllText(path, jsonStr);
            return "编辑成功";
        }
        // 删除数据
        public string RemoveBook(string bookName)
        {
            // 删除的逻辑处理
            List<Dictionary<string, object>> bookList = new();
            if (!File.Exists(path)) return "还未有书籍记录，请添加";
            var json = File.ReadAllText(path);
            bookList = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(json);
            int num = bookList.Count;
            for (int i =0; i < bookList.Count;i++)
            {
                if (bookList[i]["name"].ToString() == bookName)
                {
                    bookList.RemoveAt(i);
                }
            }
            if (num == bookList.Count) return "书籍不存在";
            string jsonStr = JsonSerializer.Serialize(bookList, JsonOpts);
            File.WriteAllText(path, jsonStr);
            return "删除书籍成功";
        }
        // 查询所有数据
        public List<Dictionary<string, object>> SearchBook() // 返回值根据情况修改
        {
            // 查询的逻辑处理
            List<Dictionary<string, object>> bookList = new();
            if (!File.Exists(path)) return bookList;
            var json = File.ReadAllText(path);
            bookList = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(json);
            return bookList;
        }
        // 根据图书名称查询当前图书数据：强制要求
        public List<Dictionary<string, object>> SearchBook(string bookName) // 返回值根据情况修改
        {
            // 按书名查询的逻辑处理
            List<Dictionary<string, object>> bookList = new();
            List<Dictionary<string, object>> newBookList = new();
            if (!File.Exists(path)) return bookList;
            var json = File.ReadAllText(path);
            bookList = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(json);
            foreach(var item in bookList)
            {
                if (item["name"].ToString() == bookName)
                {
                    newBookList.Add(item);
                } 
            }
            return newBookList;
        }
        //借阅图书功能
        public string BoorowBook(string bookName)
        {
            List<Dictionary<string, dynamic>> bookList = new();
            if (!File.Exists(path)) return "还没有书籍，请添加";
            var json = File.ReadAllText(path);
            bookList = JsonSerializer.Deserialize<List<Dictionary<string, dynamic>>>(json)!;

            // 遍历每一本书，找到书名匹配的那一本
            foreach (var item in bookList)
            {
                string name = item["name"].ToString();
                if (name == bookName)
                {
                    //找到了目标书籍
                    bool isBorrow = item["isBorrow"].GetBoolean();
                    if (isBorrow)
                    {
                        return "书籍已借阅";
                    }
                    // 只修改找到的这一本书
                    item["isBorrow"] = true;

                    //写回json文件
                    string jsonStr = JsonSerializer.Serialize(bookList, JsonOpts);
                    File.WriteAllText(path, jsonStr);
                    return "借阅成功";
                }
            }
            //循环走完没有return，代表没找到这本书
            return "没有找到该书籍";
        }    
        /// 还书业务方法，传入要还的书名，返回处理结果文本
        public string ReturnBook(string returnbook)
        {
            List<Dictionary<string, dynamic>> bookList = new();
            if (!File.Exists(path)) return "还没有书籍，请添加";
            var json = File.ReadAllText(path);
            bookList = JsonSerializer.Deserialize<List<Dictionary<string, dynamic>>>(json)!;

            //遍历找匹配书名的那一本书
            foreach (var item in bookList)
            {
                string bookName = item["name"].ToString();
                if (bookName == returnbook)
                {
                    bool isBorrow = item["isBorrow"].GetBoolean();
                    if (!isBorrow)
                    {
                        //这本书没有借出，不能还
                        return $"《{returnbook}》并未借出，无需还书";
                    }
                    //找到目标，只修改这一本
                    item["isBorrow"] = false;
                    string jsonStr = JsonSerializer.Serialize(bookList, JsonOpts);
                    File.WriteAllText(path, jsonStr);
                    return $"《{returnbook}》已还";
                }
            }
            //循环走完没return，代表找不到这本书
            return $"未找到书籍《{returnbook}》";
        }

        // 自定义实例构造函数
        public BookManager(string bookPath, JsonSerializerOptions Opts)
        {
            // 实例化初始化属性
            path = bookPath;
            JsonOpts = Opts;
        }
    }
}
