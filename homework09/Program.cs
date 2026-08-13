using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace homework09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 作业1
            List<Dictionary<string, dynamic>> list = new() {
                new Dictionary<string, dynamic>(){
                    ["name"] = "zs",
                    ["age"] = 29,
                    ["isMan"] = true,
                    ["isSingle"] = true,
                    ["salary"] = 4200
                },
                new Dictionary<string, dynamic>(){
                    ["name"] = "ls",
                    ["age"] = 20,
                    ["isMan"] = false,
                    ["isSingle"] = true,
                    ["salary"] = 3400
                },
                new Dictionary<string, dynamic>(){
                    ["name"] = "ww",
                    ["age"] = 19,
                    ["isMan"] = true,
                    ["isSingle"] = false,
                    ["salary"] = 6000
                },
                new Dictionary<string, dynamic>(){
                    ["name"] = "zl",
                    ["age"] = 14,
                    ["isMan"] = false,
                    ["isSingle"] = true,
                    ["salary"] = 2000
                },
                new Dictionary<string, dynamic>(){
                    ["name"] = "sq",
                    ["age"] = 35,
                    ["isMan"] = true,
                    ["isSingle"] = false,
                    ["salary"] = 7000
                },
                new Dictionary<string, dynamic>(){
                    ["name"] = "zb",
                    ["age"] = 27,
                    ["isMan"] = false,
                    ["isSingle"] = true,
                    ["salary"] = 2900
                },
            };


            //// Find: 要求查找年龄小于20的
            //var Age = list.Find((item) =>
            //{

            //    return item["age"] < 20;
            //});

            //Console.WriteLine(Age["name"]);

            //// FindLast: 要求查找年龄大于25的
            //var lastAge = list.FindLast((item) =>
            //{

            //    return item["age"] > 25;
            //});
            //Console.WriteLine(lastAge["name"]);

            // FindAll: 找出性别男的
            //var genger = list.FindAll((item) =>
            //{
            //    return item["isMan"];

            //});
            //foreach (var item in genger) Console.WriteLine($"{item["name"]}是男的");

            //// FindIndex: 找出薪水大于5000
            //var salary = list.FindIndex((item) =>
            //{
            //    return item["salary"] > 5000;
            //});
            //Console.WriteLine(salary);

            //// FindLastIndex: 找出薪水小于3000
            //var lastSalary = list.FindLastIndex((item) =>
            //{
            //    return item["salary"] < 3000;
            //});
            //Console.WriteLine(lastSalary);

            //// Exists: 判断是否有薪水大于5000
            //var isSalary = list.Exists((item) =>
            //{
            //    return item["salary"] > 5000;
            //});
            //Console.WriteLine(isSalary);

            //// ForEach: 输出每个的 名字-年龄-薪水
            // list.ForEach((item) =>
            //{
            //    Console.WriteLine($"名字：{item["name"]} -- 年龄：{item["age"]} -- 薪水： {item["salary"]}");
            //});

            //// ConvertAll: 映射得到一个所以薪水的list
            //List<dynamic> newList = list.ConvertAll(item =>
            //{
            //    return item["salary"];
            //});
            //Console.WriteLine(string.Join(",",newList));

            //TrueForAll: 判断是否都成年
            //var isAge = list.ConvertAll(item =>
            //{
            //    return item["age"] > 18;
            //});
            //foreach (var item in isAge) Console.WriteLine(item);
            #endregion

            #region 作业2
            //封装一个函数 接收一个字符串; 返回一个字典,键是字符串的每个字符,键值是这个字符在字符串中出现的次数
            Func<string, Dictionary<string, int>> createDic = (str) =>
            {
                Dictionary<string, int> dic = new();
                for (int i = 0; i < str.Length; i++)
                {
                    if (dic.ContainsKey(str[i].ToString())) continue;
                    int count = 0;
                    for (int j = 0; j < str.Length; j++)
                    {
                        if (str[j] == str[i])
                        {
                            count++;
                        }
                    }
                    dic.Add(str[i].ToString(), count);
                }
                return dic;
            };
            Console.WriteLine("请输入一串字符：");
            string str = Console.ReadLine();
            foreach (var item in createDic(str)) Console.WriteLine(item);
            #endregion


        }
    }
}
