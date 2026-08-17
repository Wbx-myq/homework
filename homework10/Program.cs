using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace homework10
{
    internal class Program
    {
        // 用户实体类
        class User
        {
            [JsonPropertyName("username")]
            public string Username { get; set; }

            [JsonPropertyName("password")]
            public string Password { get; set; }

            [JsonPropertyName("datetime")]
            public string Datetime { get; set; }
        }

        static void Main(string[] args)
        {
            //作业:  使用读写文件配合命令行窗口  模拟实现注册功能
            //要求输入用户名和密码,完成注册; (注册的用户信息记录在user.txt文件中, 一行一个用户信息 数据之间通过 === 分隔)
            //string filePath = "./users.txt";
            //Console.WriteLine("==== 用户注册系统（纯Func实现）====");
            //Console.Write("请输入用户名：");
            //string userName = Console.ReadLine().Trim();
            //Console.Write("请输入密码：");
            //string password = Console.ReadLine().Trim();

            //// Func1：检测用户名
            //Func<string, bool> CheckUserExist = (username) =>
            //{
            //    if (!File.Exists(filePath)) return false;
            //    foreach (var line in File.ReadAllLines(filePath))
            //    {
            //        string[] arr = line.Split("===");
            //        if (arr[0] == username) return true;
            //    }
            //    return false;
            //};

            //// Func2：执行注册，返回注册结果文本
            //Func<string, string, string> Register = (uname, pwd) =>
            //{
            //    if (CheckUserExist(uname))
            //        return "注册失败：用户名已存在！";

            //    using (var sw = File.AppendText(filePath))
            //    {
            //        sw.WriteLine($"{uname}==={pwd}");
            //    }
            //    return "注册成功！";
            //};

            //if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
            //{
            //    Console.WriteLine("用户名密码不能为空！");
            //}
            //else
            //{
            //    string result = Register(userName, password);
            //    Console.WriteLine(result);
            //}

            //Console.ReadKey();


            //扩展练习:  使用读写文件配合命令行窗口  模拟实现注册登录功能
            //进入就是菜单栏界面, 1注册,2登录,0退出
            //输入1 进入注册, 要求输入用户名,密码, 用户输入用户名和密码 则实现注册功能, 要求校验用户名和密码
            //输入2 进入登录, 要求输入用户名, 密码, 输入后完成登录校验功能; 登录成功提示 登录成功
            //输入0 退出程序,
            //-用户注册成功的用户信息 以文件的形式存储在user.json中(要求以json形式存储)
            //- [{ username: "",password: "",datetime: "时间戳"}]
            //-用户操作日志user.log: 用户每次操作都要有日志记录, 记录操作,用户名,操作方式,时间,如果有异常的,记录异常
            string userJsonFile = "./user.json";
            string logFile = "./user.log";

            //==================== 全部 Func / Action 定义开始 ====================

            // 写入日志：操作名称、用户名、异常对象
            Action<string, string, Exception> WriteLog = (operate, uname, ex) =>
            {
                string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string logLine;
                if (ex == null)
                {
                    logLine = $"[{now}] 操作:{operate} | 用户名:{uname} | 无异常";
                }
                else
                {
                    logLine = $"[{now}] 操作:{operate} | 用户名:{uname} | 异常:{ex.Message}";
                }
                File.AppendAllText(logFile, logLine + Environment.NewLine);
            };

            // 读取用户列表，返回匿名对象集合 List<匿名类型>
            Func<List<dynamic>> LoadUsers = () =>
            {
                if (!File.Exists(userJsonFile))
                {
                    return new List<dynamic>();
                }
                string jsonText = File.ReadAllText(userJsonFile);
                if (string.IsNullOrWhiteSpace(jsonText))
                {
                    return new List<dynamic>();
                }
                return JsonSerializer.Deserialize<List<dynamic>>(jsonText) ?? new List<dynamic>();
            };

            // 保存用户集合到json
            Action<List<dynamic>> SaveUsers = userList =>
            {
                var opt = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(userList, opt);
                File.WriteAllText(userJsonFile, json);
            };

            // 判断用户名是否存在
            Func<string, bool> UserExists = username =>
            {
                var users = LoadUsers();
                foreach (var u in users)
                {
                    if (u.username == username)
                        return true;
                }
                return false;
            };

            // 注册函数：传入用户名、密码，返回结果文本
            Func<string, string, string> Register = (uname, pwd) =>
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(uname) || string.IsNullOrWhiteSpace(pwd))
                    {
                        WriteLog("注册", uname, new Exception("用户名或密码为空"));
                        return "注册失败：用户名和密码不能为空！";
                    }

                    if (UserExists(uname))
                    {
                        WriteLog("注册", uname, new Exception("用户名已存在"));
                        return "注册失败：用户名已被占用！";
                    }

                    var userList = LoadUsers();
                    // 使用匿名对象代替自定义class
                    var newUser = new
                    {
                        username = uname,
                        password = pwd,
                        datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")
                    };
                    userList.Add(newUser);
                    SaveUsers(userList);

                    WriteLog("注册", uname, null);
                    return "✅ 注册成功！";
                }
                catch (Exception err)
                {
                    WriteLog("注册", uname, err);
                    return $"注册出错：{err.Message}";
                }
            };

            // 登录函数：传入用户名、密码，返回结果文本
            Func<string, string, string> Login = (uname, pwd) =>
            {
                try
                {
                    var userList = LoadUsers();
                    bool loginOk = false;
                    foreach (var item in userList)
                    {
                        if (item.username == uname && item.password == pwd)
                        {
                            loginOk = true;
                            break;
                        }
                    }

                    if (!loginOk)
                    {
                        WriteLog("登录", uname, new Exception("用户名或密码错误"));
                        return "❌ 登录失败：用户名或密码不正确";
                    }

                    WriteLog("登录", uname, null);
                    return "✅ 登录成功！";
                }
                catch (Exception err)
                {
                    WriteLog("登录", uname, err);
                    return $"登录出错：{err.Message}";
                }
            };

            //==================== Func定义结束，主菜单循环 ====================

            while (true)
            {
                Console.WriteLine("\n======== 用户操作系统 ========");
                Console.WriteLine("1. 用户注册");
                Console.WriteLine("2. 用户登录");
                Console.WriteLine("0. 退出程序");
                Console.Write("请输入选择：");
                string select = Console.ReadLine()?.Trim() ?? "";

                switch (select)
                {
                    case "1":
                        Console.WriteLine("\n--- 用户注册 ---");
                        Console.Write("用户名：");
                        string regName = Console.ReadLine().Trim();
                        Console.Write("密码：");
                        string regPwd = Console.ReadLine().Trim();
                        Console.WriteLine(Register(regName, regPwd));
                        break;

                    case "2":
                        Console.WriteLine("\n--- 用户登录 ---");
                        Console.Write("用户名：");
                        string loginName = Console.ReadLine().Trim();
                        Console.Write("密码：");
                        string loginPwd = Console.ReadLine().Trim();
                        Console.WriteLine(Login(loginName, loginPwd));
                        break;

                    case "0":
                        WriteLog("程序退出", "", null);
                        Console.WriteLine("程序退出！");
                        return;

                    default:
                        Console.WriteLine("输入无效，请输入 0、1、2");
                        break;
                }
            }


        }
    }
}

