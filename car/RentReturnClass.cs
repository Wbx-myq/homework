using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Car
{
    internal class RentReturnClass
    {
        private string carPath { get; } = "./Car.json";
        private string userPath { get; } = "./user.json";
        private string Path { get; } = "./rentreturn.json";
        private JsonSerializerOptions JsonOpt { get; } = new JsonSerializerOptions
        {
            WriteIndented = true,
            AllowTrailingCommas = true,
            // 在JSON序列化的时候中文不变
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        };
        //租车
        public void Rent()
        {
            // 提示输入
            Console.WriteLine("请输入车辆ID");
            int CarId = int.Parse(Console.ReadLine());
            Console.WriteLine("请输入客户ID");
            int UserId = int.Parse(Console.ReadLine());
            List<User> users = new List<User>();
            List<Car> cars = new List<Car>();
            List<RentReturn> rentReturns = new List<RentReturn>();
            if (File.Exists(this.userPath))
            {
                string userStr = File.ReadAllText(this.userPath);
                users = JsonSerializer.Deserialize<List<User>>(userStr);
            }

            if (File.Exists(this.carPath))
            {
                string carStr = File.ReadAllText(this.carPath);
                cars = JsonSerializer.Deserialize<List<Car>>(carStr);
            }

            if (File.Exists(this.Path))
            {
                string rrStr = File.ReadAllText(this.Path);
                rentReturns = JsonSerializer.Deserialize<List<RentReturn>>(rrStr);
            }
            //判断 客户ID是否已存在 ==》列表的Exists
            if (users.Exists(item => item.Id == UserId))
            {
                // 判断 车辆ID是否已存在 ==》列表的Exists
                if (cars.Exists(item => item.Id == CarId))
                {

                    if (cars.Find(car => car.Id == CarId).Status)
                    {
                        foreach (Car car in cars)
                        {
                            car.Status = false;
                            string jsonCarStr = JsonSerializer.Serialize(cars, this.JsonOpt);
                            File.WriteAllText(this.carPath, jsonCarStr);
                            Console.WriteLine("租车成功");
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("该车已出租");

                    }
                }
                else
                {
                    Console.WriteLine("车辆ID输入错误，请重新输入");
                    return;
                }
            }
            else
            {
                Console.WriteLine("客户ID输入错误，请重新输入");
                return;
            }
            string rentTime = DateTime.Now.ToString();
            RentReturn RR = new RentReturn(rentReturns.Count + 1, CarId, UserId, rentTime, "", 0);
            rentReturns.Add(RR);
            string jsonrrStr = JsonSerializer.Serialize(rentReturns, this.JsonOpt);
            File.WriteAllText(this.Path, jsonrrStr);
            //Console.WriteLine("租车成功");
        }
        //还车
        public void Return()
        {
            Console.WriteLine("请输入租车ID:");
            int RentId = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            List<RentReturn> rentReturns = new List<RentReturn>();
            if (!File.Exists(this.Path))
            {
                Console.WriteLine("还没有租车记录，请先租车");
                return;
            }
            if (File.Exists(this.carPath))
            {
                string carStr = File.ReadAllText(this.carPath);
                cars = JsonSerializer.Deserialize<List<Car>>(carStr);
            }

            string rrStr = File.ReadAllText(this.Path);
            rentReturns = JsonSerializer.Deserialize<List<RentReturn>>(rrStr);

            if (rentReturns.Count == 0)
            {
                Console.WriteLine("还没有租车记录，请先租车");
            }
            RentReturn rR = rentReturns.Find(rr => rr.Id == RentId);
            if (rR.Id != RentId)
            {
                Console.WriteLine("租车ID不存在！");
                return;
            }
            Car C = cars.Find(c => c.Id == rR.CarId);
            if (!string.IsNullOrEmpty(rR.ReturnTime))
            {
                Console.WriteLine("没有租借车辆记录"); 
            }
            foreach (Car car in cars)
            {
                C.Status = true;
                string jsonCarStr = JsonSerializer.Serialize(cars, this.JsonOpt);
                File.WriteAllText(this.carPath, jsonCarStr);
                string returnTime = DateTime.Now.ToString();
                double price = car.Price;
                TimeSpan diff = DateTime.Now - DateTime.Parse(rR.RentTime);
                double payMoney = (double)diff.TotalHours * price;
                RentReturn RR = new RentReturn(rR.Id, rR.CarId, rR.UserId, rR.RentTime, returnTime, payMoney);
                for(int i = 0; i < rentReturns.Count; i++)
                {
                    if (rentReturns[i].Id == rR.Id)
                    {
                        rentReturns[i] = RR;
                        break;
                    }
                }
                string jsonrrStr = JsonSerializer.Serialize(rentReturns, this.JsonOpt);
                File.WriteAllText(this.Path, jsonrrStr);
                Console.WriteLine("还车成功");
                break;
            }
        }
        //查看租还车记录
        public void SearchAll()
        {
            List<RentReturn> rentReturns = new List<RentReturn>();
            if (!File.Exists(this.Path))
            {
                Console.WriteLine("还没有租车记录，请先租车");
                return;
            }
            string rrStr = File.ReadAllText(this.Path);
            rentReturns = JsonSerializer.Deserialize<List<RentReturn>>(rrStr);

            if (rentReturns.Count == 0)
            {
                Console.WriteLine("还没有租车记录，请先租车");
            }
            foreach (RentReturn r in rentReturns)
            {
                Console.WriteLine($"租车记录ID: {r.Id} -- 车辆ID: {r.CarId} -- 客户ID: {r.UserId} -- 租赁时间: {r.RentTime} -- 还车时间: {r.ReturnTime} -- 费用: {r.PayMoney}");
            }
        }
    }
}
