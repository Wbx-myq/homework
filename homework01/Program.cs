namespace sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //计算任意两个输入数字的和
            Console.WriteLine("请输入数字n：");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("请输入数字m：");
            int m = int.Parse(Console.ReadLine());
            int sum = n + m;
            Console.WriteLine($"两数之和：{sum}");
            Console.WriteLine("---------分割线---------");
            Console.WriteLine();


            //华氏度和摄氏度的转换
            Console.WriteLine("请输入华氏度：");
            double dc;//摄氏度
            double df = double.Parse(Console.ReadLine());//华氏度
            dc = 5 / 9.0 * (df - 32);
            Console.WriteLine($"华氏度：{df:F3}");
            Console.WriteLine($"摄氏度：{dc:F3}");
            Console.WriteLine("---------分割线---------");
            Console.WriteLine();

            //通过数学运算交换两个整型变量的值
            Console.WriteLine("请输入数字一：");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("请输入数字二：");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine($"原来的数字一：{a}，原来的数字二：{b}");
            int c = a + b;//将 a 和 b 的值赋予 c
            b = c - b;//将赋值的 c 减去 b，b 赋值得到原值a
            a = c - b;//将赋值的 c 减去赋值的 b，a 赋值得到原值b
            Console.WriteLine($"交换后的数字一：{a},交换后的数字二：{b}");
            Console.WriteLine("---------分割线---------");
            Console.WriteLine();


            //为抵抗洪水，战士连续作战89小时，编程计算共多少天零多少小时？
            double h = 89;
            double t = Math.Floor(h / 24); 
            h = h % 24;
            Console.WriteLine($"战士连续作战共{t}天{h}小时");
            Console.WriteLine("---------分割线---------");
            Console.WriteLine();
        }
    }
}
