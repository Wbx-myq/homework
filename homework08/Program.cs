using System;
using System.Data.SqlTypes;
using System.Threading.Channels;

namespace homework08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //用函数封装一个猜数字的小游戏，函数中生成一个随机整数（0-100）作为目标数字，不停的让用户输入数字，距离目标数字偏大，就提示用户偏大，距离目标数字偏小就输出偏小，用户有5次输入的机会，5次没有猜对，输出GAME OVER，猜对了就输出WIN！
            // 封装猜数字游戏函数
            //var GuessGame = () =>
            //{
            //   Random rand = new Random();
            //   int n = rand.Next(0, 101); // [0,100]随机数
            //   int chance = 5; // 5次机会

            //   while (chance > 0)
            //   {
            //       Console.Write($"请输入数字，剩余{chance}次机会：");
            //       int num = int.Parse(Console.ReadLine());
            //       chance--;

            //       if (num > n)
            //       {
            //           Console.WriteLine("偏大");
            //       }
            //       else if (num < n)
            //       {
            //           Console.WriteLine("偏小");
            //       }
            //       else
            //       {
            //           Console.WriteLine("WIN!");
            //           return; // 猜对直接结束函数
            //       }
            //   }
            //   // 循环结束=机会用完
            //   Console.WriteLine($"GAME OVER：{n}");
            //};
            //GuessGame();

            //装修房间：参数1，圆的半径，计算圆的面积，每平方米收费200元，返回装修总价。计算这个半径的圆装修一半需要多少钱？
            //var area = () =>
            //{
            //    Console.Write($"请输入半径：");
            //    double r = double.Parse(Console.ReadLine());
            //    return ((r * r * Math.PI) / 2) * 200;
            //};
            //Console.WriteLine(area());

            //计算字符在字符串中出现的次数：参数1字符串，参数2某个字符，函数统计次数，并返回。
            //Func<string, string, int> fn = (str, s) =>
            //{
            //    int count = 0;
            //    for(int i  = 0; i < str.Length; i++)
            //    {
            //        string s1 = str[i].ToString();
            //        if (s1 == s)
            //        {
            //            count++;
            //        }
            //    }
            //    return count;
            //};
            //string str = "qwerysssssqqqqwwweee";
            //int n = fn(str, "r");
            //Console.WriteLine(n);

            //计算一个整型数组中，最小值第一次出现的下标。
            //int[] arr = [10, 20, 5, 30, 50, 6, 7];
            //Func<int[] , int> minIdex = (arr) =>
            //{
            //    int idx = 0;
            //    for (int i = 1; i < arr.Length; i++)
            //    {
            //        if (arr[i] < arr[idx]) idx = i;
            //    }
            //    return idx;
            //};
            //Console.WriteLine(minIdex(arr));

            //判断一个字符串是否为回文，返回布尔值类型。
            string str = "abcdcba";
            Func<string , bool> isPalindrome = (str) =>
            {
                char[] arrStr = str.ToArray();
                Array.Reverse(arrStr);
                string str1 = new string(arrStr);
                if( str1 == str) return true;
                else return false;
            };
            Console.WriteLine(isPalindrome(str));
        }
    }
}
