using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace homework12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 实例化图书对象
            BookManager BM = new BookManager("./book.json", new JsonSerializerOptions
            {
                WriteIndented = true, // 美化格式内容
                AllowTrailingCommas = true,
            });
            string num = "";
            while (num != "0")
            {
                // 提示信息
                Console.WriteLine("======欢迎来到图书管理系统======");
                Console.WriteLine("1: 新增图书");
                Console.WriteLine("2: 删除图书");
                Console.WriteLine("3: 编辑图书");
                Console.WriteLine("4: 查询所有图书");
                Console.WriteLine("5: 查询单个图书");
                Console.WriteLine("6: 借阅图书");
                Console.WriteLine("7: 还书");
                Console.WriteLine("0: 退出");
                num = Console.ReadLine();

                switch (num)
                {
                    case "1":
                        Console.WriteLine("----新增图书----");
                        Console.WriteLine("请输入书名");
                        string bookName = Console.ReadLine();
                        bool IsBookName = Regex.IsMatch(bookName, @"^[\u4e00-\u9fa5a-zA-Z0-9，。、· ]+$");
                        Console.WriteLine("请输入作者");
                        string author = Console.ReadLine();
                        bool IsAuthor = Regex.IsMatch(author, @"^[\u4e00-\u9fa5a-zA-Z· ]+$");
                        Console.WriteLine("请输入标签");
                        string mark = Console.ReadLine();
                        bool IsMark = Regex.IsMatch(mark, @"^[\u4e00-\u9fa5a-zA-Z0-9 ]+$");
                        
                        Console.WriteLine("请输入价格");
                        string priceStr = Console.ReadLine();
                        // @"^[1-9]+[0-9]*(\.[0-9]+)?$"
                        bool isPriceStr = Regex.IsMatch(priceStr, @"^[1-9]+[0-9]*(\.[0-9]+)?$");
                        Dictionary<string, dynamic> bookDic = new();
                        if (IsBookName && IsAuthor && IsMark && isPriceStr)
                        {
                            // 组装 书籍 字典
                            bookDic = new()
                            {
                                ["name"] = bookName,
                                ["author"] = author,
                                ["isBorrow"] = false,
                                ["id"] = new Random().NextDouble(),
                                ["mark"] = mark,
                                ["price"] = double.Parse(priceStr)
                            };
                            // 调用实例方法  实现 添加书籍
                            string res1 = BM.AddBook(bookDic);
                            Console.WriteLine(res1);
                        }
                        else Console.WriteLine("输入的价格格式有误");
                        break;
                    case "2":
                        Console.WriteLine("----删除图书----");
                        Console.WriteLine("请输入书名");
                        string removeBookName = Console.ReadLine();
                        string res = BM.RemoveBook(removeBookName);
                        Console.WriteLine(res);
                        break;
                    case "3":
                        Console.WriteLine("----编辑图书----");
                        Console.WriteLine("请输入书名");
                        string editBookName = Console.ReadLine();
                        res = BM.EditBook(editBookName);
                        Console.WriteLine(res);
                        break;
                    case "4":
                        Console.WriteLine("----查询所有图书----");
                        List<Dictionary<string, dynamic>> bookList = BM.SearchBook();
                        if (bookList.Count == 0)
                        {
                            Console.WriteLine("没有书籍，请添加");
                        }
                        else
                        {
                            foreach (var item in bookList) Console.WriteLine($"书名：{item["name"]} -- 作者：{item["author"]} -- 标签：{item["mark"]} -- 价格：{item["price"]}");
                        }
                        break;
                    case "5":
                        Console.WriteLine("----查询单个图书----");
                        Console.WriteLine("请输入书名");
                        string searchBookName = Console.ReadLine();
                        bookList = BM.SearchBook(searchBookName);
                        if (bookList.Count == 0)
                        {
                            Console.WriteLine("未查询到书籍");
                        }
                        else
                        {
                            foreach (var item in bookList) Console.WriteLine($"书名：{item["name"]} -- 作者：{item["author"]} -- 标签：{item["mark"]} -- 价格：{item["price"]}");
                        }
                        break;
                    case "6":
                        Console.WriteLine("----借阅图书----");
                        bookList = BM.SearchBook();
                        if (bookList.Count == 0)
                        {
                            Console.WriteLine("没有书籍，请添加");
                        }
                        else
                        {
                            foreach (var item in bookList) Console.WriteLine($"书名：{item["name"]} -- 作者：{item["author"]} -- 标签：{item["mark"]} -- 价格：{item["price"]}");
                        }
                        Console.WriteLine("请输入书名");
                        string borrowBookName = Console.ReadLine();
                        res = BM.BoorowBook(borrowBookName);
                        Console.WriteLine(res);
                        break;
                    //====菜单7：还书====
                    case "7":
                        Console.WriteLine("----还书----");
                        //获取借阅的书籍
                        bookList = BM.SearchBook();
                        int n = bookList.Count;
                        if (n == 0)
                        {
                            Console.WriteLine("没有书籍，请添加");
                        }
                        else
                        {
                            foreach (var item in bookList) 
                            {
                                if (item["isBorrow"].GetBoolean())
                                {
                                    Console.WriteLine($"书名：{item["name"]} -- 作者：{item["author"]} -- 标签：{item["mark"]} -- 价格：{item["price"]}");
                                }
                                else n--;
                            }
                            if(n == 0)
                            {
                                Console.WriteLine("没有借阅记录，请先借书");
                                break;
                            }
                        }
                        Console.WriteLine("请输入要还的书名");
                        string inputName = Console.ReadLine()!;
                        res = BM.ReturnBook(inputName);
                        Console.WriteLine(res);
                        break;
                    case "0":
                        Console.WriteLine("--**退出**--");
                        break;
                    default:
                        Console.WriteLine("****输入有误****");
                        break;
                }

                /*1. 对所有输入的数据进行校验
                    -可以先取出首尾两端的空白
                    - 不为空，长度要求校验
                    - 正则校验
                2.完善一个借阅功能
                    - 添加一个借阅功能的编号 比如： 5 + 输入5 进入借阅功能
                    - 将所有可借阅的书籍展示， 并要求用户输入借阅的书籍名称
                    - 输入要借阅的书籍，实现借阅
                3.完善一个还书功能
                */
            }
        }
    }
}
