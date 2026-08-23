using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Car
{
    internal class UserManager
    {
        private string Path { get; } = "./user.json";
        private JsonSerializerOptions JsonOpt { get; } = new JsonSerializerOptions
        {
            WriteIndented = true,
            AllowTrailingCommas = true,
            // 在JSON序列化的时候中文不变
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        };

        //添加车辆方法
        public void Add()
        {
            // 提示输入客户信息
            Console.WriteLine("请输入客户姓名：");
            string userName = Console.ReadLine();
            Console.WriteLine("请输入身份证号：");
            string IdCard = Console.ReadLine();
            Console.WriteLine("请输入性别：");
            string gender = Console.ReadLine();
            Console.WriteLine("请输入手机号：");
            string telNum = Console.ReadLine();
            Console.WriteLine("请输入座右铭：");
            string motto = Console.ReadLine();

            // 验证手机号
            if (!Regex.IsMatch(telNum, @"^1\d{10}$"))
            {
                Console.WriteLine("输入手机格式错误！！！");
                return;
            }
            // 验证手机号
            if (!Regex.IsMatch(gender, @"男 | 女"))
            {
                Console.WriteLine("输入性别错误！！！");
                return;
            }
            List<User> users = new List<User>();
            int num = users.Count;
            //判断文件是否存在
            if (File.Exists(Path))
            {
                string jsonStr = File.ReadAllText(this.Path);
                users = JsonSerializer.Deserialize<List<User>>(jsonStr);
                // 判断 身份证号是否已存在 ==》列表的Exists
                if (users.Exists(item => item.IdCard == IdCard))
                {
                    Console.WriteLine("新增失败，客户已存在");
                    return;
                }
            }
            // 将接受的数据组装成User实例对象，然后添加到list中 ---> 序列化list---》写入json文件
            string regTime = DateTime.Now.ToString();
            User userObj = new User(users.Count + 1, userName, IdCard, regTime, gender, telNum, motto);
            users.Add(userObj);
            string resStr = JsonSerializer.Serialize(users, this.JsonOpt);
            File.WriteAllText(this.Path, resStr);
            //判断是否添加成功
            if (num <= users.Count)
            {
                Console.WriteLine("新增客户成功");
            }
        }
        //查看所有客户
        public void SearchAll()
        {
            List<User> users = new List<User>();
            //判断文件是否存在
            if (!File.Exists(Path))
            {
                Console.WriteLine("还未存在客户信息，请先添加");
                return;
            }
            string jsonStr = File.ReadAllText(this.Path);
            users = JsonSerializer.Deserialize<List<User>>(jsonStr);
            if (users.Count == 0)
            {
                Console.WriteLine("还未存在客户信息，请先添加");
                return;
            }
            foreach(User user in users)
            {
                Console.WriteLine($"ID: {user.Id} -- 姓名: {user.Name} -- 身份证: {user.IdCard} -- 性别: {user.Gender} -- 手机号: {user.PhoneNo} -- 座右铭: {user.Motto} ");
            }
            
            string resStr = JsonSerializer.Serialize(users, this.JsonOpt);
            File.WriteAllText(this.Path, resStr);
        }
        //查看某个客户
        public void SearchOne()
        {
            Console.WriteLine("请输入身份证号：");
            string IdCard = Console.ReadLine();
            List<User> users = new List<User>();
            //判断文件是否存在
            if (!File.Exists(Path))
            {
                Console.WriteLine("还未存在客户信息，请先添加");
                return;
            }
            string jsonStr = File.ReadAllText(this.Path);
            users = JsonSerializer.Deserialize<List<User>>(jsonStr);
            if (users.Count == 0)
            {
                Console.WriteLine("还未存在客户信息，请先添加");
                return;
            }
            if (users.Exists(user => user.IdCard == IdCard))
            {
                foreach (User user in users)
                {
                    Console.WriteLine($"ID: {user.Id} -- 姓名: {user.Name} -- 身份证: {user.IdCard} -- 性别: {user.Gender} -- 手机号: {user.PhoneNo} -- 座右铭: {user.Motto} ");
                    break;
                }
            }
            else
            {
                Console.WriteLine("客户不存在");
            }
            string resStr = JsonSerializer.Serialize(users, this.JsonOpt);
            File.WriteAllText(this.Path, resStr);
        }
    }
}
