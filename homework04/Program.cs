namespace homework04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //计算100以内偶数的和
            //int sum = 0;
            //for (int i= 1; i <= 100; i++)
            //{
            //    if(i % 2 ==0)
            //    {
            //        sum += i;
            //    }
            //}
            //Console.WriteLine($"100以内偶数的和{sum}");

            //显示出1000-2000年中所有的闰年，并以每行四个数的形式输出
            //int count = 0; 
            //for (int i = 1000; i <= 2000; i++)
            //{
            //    // 闰年判断条件
            //    if (i % 4 == 0 && i % 100 != 0 || i % 400 == 0)
            //    {
            //        Console.Write($"{i}是闰年\t");
            //        count++;
            //        // 满4个就换行
            //        if (count % 4 == 0)
            //        {
            //            Console.WriteLine();
            //        }
            //    }
            //}

            //输出一个倒三角形
            //for (int j = 9; j >= 1; j--)
            //{
            //    {
            //        Console.Write("*"); 
            //    }
            //    Console.WriteLine(); 
            //}

            //用循环计算下面的结果

            //用循环计算下面的结果1 - 1/2 + 1/3 - 1/4 + ... - 1/100
            //double num = 0;
            //for (double i = 1; i <= 100; i++)
            //{
            //    num += Math.Pow(-1, i - 1)*1/i;
            //}
            //Console.WriteLine($"1 - 1/2 + 1/3 - 1/4 + ... - 1/100={num}");

            //求10以内所有数字的阶乘的和
            //int p = 1;
            //int sum = 0;
            //for (int i = 1; i <= 10; i++)
            //{
            //    p *= i;
            //    sum += p;
            //}
            //Console.WriteLine($"10以内所有数字的阶乘的和{sum}");

            //篮球从5米高的地方掉下来，每次弹起的高度是原来的30%，经过几次弹起，篮球的高度小于0.1米。
            //int n = 0;
            //double height = 5;
            //while (height > 0.1) 
            //{
            //    n++;
            //    height *= 0.3;
            //    Console.WriteLine($"第{n}次弹起，高度：{height:F4}");
            //}
            //Console.WriteLine($"经过{n}次弹起");

            //有一个棋盘，有64个方格，在第一个方格里面放1粒芝麻重量是0.00001kg，第二个里面放2粒，第三个里面放4，棋盘上放的所有芝麻的重量
            //double num = 0;
            //double weight = 0;
            //for (int i = 1; i <= 64; i++) {
            //    num += Math.Pow(2, i - 1);
            //    weight = num * 0.00001;
            //}
            //Console.WriteLine($"棋盘共有芝麻的数量是{num}");
            //Console.WriteLine($"棋盘上放的所有芝麻的重量是{weight}kg");

            //某人在银行有50000元存款。银行每月都要收取服务费，存款大于5000元时每个月收取总额的5%，总额不大于5000元的时候不收服务费；假设这个人存了以后从来都不用，用循环计算银行要扣这个人的手续费能扣多少次？每次扣取后剩余多少钱？
            //int count = 0;
            //double money = 50000;
            //while (money > 5000) 
            //{
            //    money *= 0.95;
            //    count++;
            //    Console.WriteLine($"第{count}次扣取后，剩余{money}");
            //}

            //猴子摘桃，猴子摘了x个桃，每天吃一半，再多吃一个，第7天吃的时候剩下一个了，猴子摘了多少桃子？
            //int i = 1;
            //for (int day = 1; day < 7 ; day++) 
            //{
            //    i= (i + 1) * 2;
            //}
            //Console.WriteLine($"猴子摘了{i}桃子");

            //有个皮球，每次落地弹起都是高度的一半，如果从10米高的地方丢下，第十次弹起时，皮球总过经历了多少距离。
            //double heigth1 = 10;
            //double sumHeigth = 10;
            //for (int i = 1; i < 10; i++) 
            //{

            //    heigth1 *= 0.5;
            //    sumHeigth += heigth1 * 2;
            //}
            //Console.WriteLine($"皮球总过经历了{sumHeigth}距离");
        }
    }
}
