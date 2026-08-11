using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace homework06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //提取一句话中所有的中文姓名
            //string str = "hello, I am 刘德华,your name is 黎明?";
            //var reg = @"[\u4e00-\u9fa5]{2,}";
            //MatchCollection name = Regex.Matches(str, reg);
            //foreach (Match match in name) Console.WriteLine(match);

            //替换所有多余空格
            //string str = "abc  dd  ee  ff  gg  HH  h j k";
            //var reg = @"\s{2,}";
            //Console.WriteLine(Regex.Replace(str,reg," "));

            //身份证号码
            //string str = "我的身份证号是: 360731200111052112,你的身份证是: 42108320041119211X";
            //// 书写正则, 找到字符串中的身份证号及 出生年,月,日
            ////第 1‑6 位：地址码（出生地行政区划）, 第 7‑14 位：出生日期码 YYYYMMDD（8 位）, 第 15‑17 位：顺序码（同地区同生日的排序）, 第 18 位：校验码（校验位，算法算出来）
            //var reg = @"(\d{6})(\d{4})(\d{2})(\d{2})(\d{3})(\d|X)";
            //foreach (Match item in Regex.Matches(str, reg))
            //{
            //    Console.WriteLine($"完整的身份证号：{item}");
            //    Console.WriteLine($"出生年：{item.Groups[2]}");
            //    Console.WriteLine($"出生月：{item.Groups[3]}");
            //    Console.WriteLine($"出生日：{item.Groups[4]}");
            //}


            //密码强度检测：强中弱（字母、数字、特殊符号）
            //请输入密码（字母、数字、特殊符号）
            Console.WriteLine("请输入密码：");
            string password = Console.ReadLine();
            //密码中可以有数字,字母,特殊符号;长度要求8~15 
            //如果只有一种则 强度为弱
            //如果只有两种则 强度为中
            //如果两种都有则 强度为强
            var reg = @"[0-9]+";
            var reg1 = @"[A-Z]+";
            var reg2 = @"[a-z]+";
            var reg3 = @"[^0-9A-Za-z]+";
            var reg4 = @"[A-Za-z]+";
            //验证密码长度是否符合,并输出密码强度
            if (password.Length >= 8 && password.Length <= 15 && Regex.IsMatch(password, reg4))
            {
                if (Regex.IsMatch(password, reg) && Regex.IsMatch(password, reg1) && Regex.IsMatch(password, reg2) && Regex.IsMatch(password, reg3))
                {
                    Console.WriteLine("密码强度为强");
                }
                else if (Regex.IsMatch(password, reg) && Regex.IsMatch(password, reg1) && Regex.IsMatch(password, reg3) || Regex.IsMatch(password, reg) && Regex.IsMatch(password, reg2) && Regex.IsMatch(password, reg3))
                {
                    Console.WriteLine("密码强度为中");
                }
                else if (Regex.IsMatch(password, reg) && Regex.IsMatch(password, reg1) && Regex.IsMatch(password, reg2))
                {
                    Console.WriteLine("密码强度为较弱");
                }
                else if (Regex.IsMatch(password, reg) || Regex.IsMatch(password, reg1) || Regex.IsMatch(password, reg2) || Regex.IsMatch(password, reg3))
                {
                    Console.WriteLine("密码强度为弱");
                }
                else Console.WriteLine();
            }
            else
            {
                Console.WriteLine("密码格式不对");
            }


            //if (password.Length >= 8 && password.Length <= 15 )
            //{
            //    if (Regex.IsMatch(password, reg) && Regex.IsMatch(password, reg1) && Regex.IsMatch(password, reg2) && Regex.IsMatch(password, reg3))
            //    {
            //        Console.WriteLine("密码强度为强");
            //    }
            //    else if (Regex.IsMatch(password, reg) && Regex.IsMatch(password, reg4) || Regex.IsMatch(password, reg) && Regex.IsMatch(password, reg3) || Regex.IsMatch(password, reg3) && Regex.IsMatch(password, reg4))
            //    {
            //        Console.WriteLine("密码强度为中");
            //    }
            //    else if (Regex.IsMatch(password, reg) ||  Regex.IsMatch(password, reg4) || Regex.IsMatch(password, reg3))
            //    {
            //        Console.WriteLine("密码强度为弱");
            //    }
            //    else Console.WriteLine();
            //}
            //else
            //{
            //    Console.WriteLine("密码格式不对");
            //}

        }
    }
}
