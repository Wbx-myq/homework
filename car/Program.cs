using Car;

namespace car
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarManager CM = new CarManager();
            UserManager UM = new UserManager();
            RentReturnClass RR = new RentReturnClass();
            string num = "";
            while (num != "0")
            {
                Tips();
                num = Console.ReadLine();
                switch (num)
                {
                    case "0":
                        Console.WriteLine("退出系统");
                        break;
                    case "1":
                        CM.Add();
                        break;
                    case "2":
                        CM.SearchAll();
                        break;
                    case "3":
                        CM.SearchOne();
                        break;
                    case "4":
                        CM.SearchStatus();
                        break;
                    case "5":
                        UM.Add();
                        break;
                    case "6":
                        UM.SearchAll();
                        break;
                    case "7":
                        UM.SearchOne();
                        break;
                    case "8":
                        RR.Rent();
                        break; 
                    case "9":
                        RR.Return();
                        break;
                    case "10":
                        RR.SearchAll();
                        break;
                    default:
                        Console.WriteLine("输入错误，请重新输入");
                        break;
                        
                }
            }
        }

        static void Tips()
        {
            // 提示界面
            Console.WriteLine("==欢迎来到神车系统==");
            Console.WriteLine("请选择操作编号：");
            Console.WriteLine("0：退出系统");
            Console.WriteLine("1：新增车辆");
            Console.WriteLine("2：查看所有车辆信息");
            Console.WriteLine("3：查看某辆车");
            Console.WriteLine("4：查看所有空闲车辆");
            Console.WriteLine("5：新增客户");
            Console.WriteLine("6：查看所有客户");
            Console.WriteLine("7：查看某个客户");
            Console.WriteLine("8：租车");
            Console.WriteLine("9：还车");
            Console.WriteLine("10：查看租还车记录");
        }
    }
}
