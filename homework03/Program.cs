using System.Data;

namespace homework03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //账号密码验证（练习分支嵌套）：账号规定是"admin"，密码规定是"123456"。让用户输入账号和密码，判断账号和密码是否正确，账号和密码都正确就输出登入成功；账号不对，就输出账号不存在；密码不对，就输出密码错误。
            //Console.WriteLine("请输入账号：");
            //string username = Console.ReadLine();
            //Console.WriteLine("请输入密码：");
            //string possword = Console.ReadLine();
            //if (username == "admin")
            //{
            //    if (possword == "123456")
            //    {
            //        Console.WriteLine("登陆成功");
            //    }
            //    else
            //    {
            //        Console.WriteLine("密码错误");
            //    }
            //}else
            //{
            //    Console.WriteLine("账号不存在");
            //}

            //选择菜单（add/edit/del）执行操作（练习多分支和switch）：提示用户选择菜单（add/edit/del），判断输入的是add，就输出新增成功；输入的是edit，就输出编辑成功；输入的是del，就输出删除成功。
            //Console.WriteLne("请选择操作菜单(add/edit/del)：");
            //string input = Console.ReadLine();
            //switch操作
            //string result = input switch
            //{
            //    "add" => "新增成功",
            //    "edit" => "编辑成功",
            //    "del" => "删除成功",
            //    _ => "输入错误，请输入 add、edit、del"
            //};
            //Console.WriteLine(result);

            //多分支操作
            //if (input == "add") {
            //    Console.WriteLine("新增成功");
            //}else if (input == "edit")
            //{
            //    Console.WriteLine("编辑成功");
            //}else if(input == "del")
            //{
            //    Console.WriteLine("删除成功");
            //}
            //else
            //{
            //    Console.WriteLine("输入错误，请输入 add、edit、del");
            //}

            //会员打折满1000打9折，普通用户满2000打9.5折（练习多分支和分支嵌套）：让用户输入自己的类型（VIP / USER）和消费金额，如果是VIP，判断消费金额是否达到1000，如果达到了，就输出他应该支付的金额，如果没有达到，也输出他应该支付的金额；如果是USER，判断消费金额是否达到2000，如果达到了和没有达到，都输出他应该支付的金额。
            //Console.WriteLine("请选择用户类型(VIP / USER)：");
            //string userType = Console.ReadLine();
            //Console.WriteLine("请输入消费的金额：");
            //double money = double.Parse(Console.ReadLine());
            //if (userType == "VIP")
            //    if (money >= 1000) Console.WriteLine($"你应支付的金额是{money * 0.9}");
            //    else Console.WriteLine($"你应支付的金额是{money}");
            //else if (userType == "USER")
            //    if (money >= 2000) Console.WriteLine($"你应支付的金额是{money * 0.95}");
            //    else Console.WriteLine($"你应支付的金额是{money}");
            //else Console.WriteLine("输入类型错误，请输入 VIP / USER");

            //通过月份判断季节（练习switch的穿透写法）：用户输入月份，判断月份如果是3、4、5月份，就输出这是春季；如果是6、7、8月份，就输出这是夏季；如果是9、10、11月份，就输出这是秋季，如果是12、1、2月份，就输出这是冬季。
            //Console.WriteLine("请输入月份：");
            //int month = int.Parse(Console.ReadLine());
            //switch (month)
            //{
            //    case 12:
            //    case 1:
            //    case 2: Console.WriteLine("冬季"); break;
            //    case 3:
            //    case 4:
            //    case 5: Console.WriteLine("春季"); break;
            //    case 6:
            //    case 7:
            //    case 8: Console.WriteLine("夏季"); break; 
            //    case 9:
            //    case 10:
            //    case 11: Console.WriteLine("秋季"); break;
            //    default: Console.WriteLine("输入月份错误，请重新输入1~12月份"); break;
            //}

            //快递运费（练习多分支）：输入快递重量，单位是Kg，如果重量小于1Kg，输出快递费10元；如果重量在1Kg~5Kg之间，就输出快递费20元；如果重量超过5Kg，就输出快递费50元。
            //Console.WriteLine("请输入快递重量：");
            //double b = double.Parse(Console.ReadLine());
            //if (b > 0)
            //    if (b < 1) Console.WriteLine("快递费10元");
            //    else if (b < 5) Console.WriteLine("快递费20元");
            //    else Console.WriteLine("快递费50元");
            //else Console.WriteLine("输入快递重量错误，重新输入");

            //会员等级优惠（练习多分支和switch）：输入会员等级，等级是3~5的整数，判断等级如果是5，输出终身免运费；等级是4，输出每月可领优惠券；等级是3，输出购物打9折，否则没有福利。
            //Console.WriteLine("请输入会员等级3~5：");
            //int v = int.Parse(Console.ReadLine());
            //多分支操作
            //if (v == 5) Console.WriteLine("终身免运费");
            //else if (v == 4) Console.WriteLine("每月可领优惠券");
            //else if (v == 3) Console.WriteLine("购物打9折");
            //else Console.WriteLine("没有福利");
            //switch操作
            //string result = v switch
            //{
            //    3 => "购物打9折",
            //    4 => "每月可领优惠券",
            //    5 => "终身免运费",
            //    _ => "没有福利"
            //};
            //Console.WriteLine(result);

            //自动售货机选商品（练习多分支和switch）：输入商品编号整数，1就输出已购买可乐；2输出已购买雪碧；3输出已购买矿泉水；否则输出无此商品。
            //Console.WriteLine("请输入商品编号1~3：");
            //int p = int.Parse(Console.ReadLine());
            //多分支操作
            //if (p == 1) Console.WriteLine("已购买可乐");
            //else if (p == 2) Console.WriteLine("已购买雪碧");
            //else if (p == 3) Console.WriteLine("已购买矿泉水");
            //else Console.WriteLine("无此商品");
            //switch操作
            //string result = p switch
            //{
            //    1 => "已购买可乐",
            //    2 => "已购买雪碧",
            //    3 => "已购买矿泉水",
            //    _ => "无此商品"
            //};
            //Console.WriteLine(result);

            //速度分级（练习多分支）：输入当前速度，如果在0~30，输出低速通过；30~60输出中速通过；60~100输出高速通过；100~120输出超速通过。
            Console.WriteLine("请输入当前速度：");
            int s = int.Parse(Console.ReadLine());
            if (!(s <= 0))
                if (s < 30) Console.WriteLine("低速通过");
                else if (s < 60) Console.WriteLine("中速通过");
                else if (s < 100) Console.WriteLine("高速通过");
                else if (s <= 120) Console.WriteLine("超速通过");
                else Console.WriteLine();
            else Console.WriteLine("速度输入错误，请重新输入大于0的速度");
        }
    }
}
