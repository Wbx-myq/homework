using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Car
{
    internal class CarManager
    {
        private string Path { get; } = "./Car.json";
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
            //输入新增车辆信息
            Console.WriteLine("请输入车牌号：");
            string Card = Console.ReadLine();
            Console.WriteLine("请输入车类型：");
            string Type = Console.ReadLine();
            Console.WriteLine("请输入时租费：");
            string Price = Console.ReadLine();
            List<Car> cars = new List<Car>();
            int num = cars.Count;
            //判断文件是否存在
            if (File.Exists(Path))
            {
                string jsonStr = File.ReadAllText(this.Path);
                cars = JsonSerializer.Deserialize<List<Car>>(jsonStr);
                // 判断 车牌是否已存在 ==》列表的Exists
                if (cars.Exists(item => item.Card == Card))
                {
                    Console.WriteLine("新增失败，车牌已存在");
                    return;
                }
            }
            // 将接受的数据组装成Car实例对象，然后添加到list中 ---> 序列化list---》写入json文件
            Car CAdd = new Car(cars.Count + 1, Card, Type, true, double.Parse(Price));
            // true 表示空闲 false表示已租出
            cars.Add(CAdd);
            string resStr = JsonSerializer.Serialize(cars, this.JsonOpt);
            File.WriteAllText(this.Path, resStr);
            //判断是否添加成功
            if(num <= cars.Count)
            {
                Console.WriteLine("新增车辆成功");
            }
        }
        //查看所有车辆信息方法
        public void SearchAll()
        {
            List<Car> cars = new List<Car>();
            //判断文件是否存在
            if (!File.Exists(Path))
            {
                Console.WriteLine("还未有车辆信息，请先添加");
                return;
            }
            {
                string jsonStr = File.ReadAllText(this.Path);
                cars = JsonSerializer.Deserialize<List<Car>>(jsonStr);
                // 判断 列表是否存在
                if (cars.Count == 0)
                {
                    Console.WriteLine("还未有车辆信息，请先添加");
                    return;
                }

               foreach (Car car in cars) 
               {
                    string statusStr = car.Status ? "空闲" : "已出租";
                    Console.WriteLine($"id : {car.Id} -- 车牌 : {car.Card} -- 类型 : {car.Type} -- 状态 : {statusStr} -- 时租费 : {car.Price} ");
               }
            }
            string resStr = JsonSerializer.Serialize(cars, this.JsonOpt);
            File.WriteAllText(this.Path, resStr);
        }
        //查看某辆车
        public void SearchOne()
        {
            //获取车辆信息
            Console.WriteLine("请输入车牌号：");
            string Card = Console.ReadLine();
            List<Car> cars = new List<Car>();
            //判断文件是否存在
            if (!File.Exists(Path))
            {
                Console.WriteLine("还未有车辆信息，请先添加");
                return;
            }
            {
                string jsonStr = File.ReadAllText(this.Path);
                cars = JsonSerializer.Deserialize<List<Car>>(jsonStr);
                // 判断 列表是否存在
                if (cars.Count == 0)
                {
                    Console.WriteLine("还未有车辆信息，请先添加");
                    return;
                }

                if (cars.Exists(car => car.Card == Card))
                {
                    foreach (Car car in cars)
                    {
                        string statusStr = car.Status ? "空闲" : "已出租";
                        Console.WriteLine($"id : {car.Id} -- 车牌 : {car.Card} -- 类型 : {car.Type} -- 状态 : {statusStr} -- 时租费 : {car.Price} ");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("车辆不存在");
                } 
            }
            string resStr = JsonSerializer.Serialize(cars, this.JsonOpt);
            File.WriteAllText(this.Path, resStr);
        }
        //查看所有空闲车辆
        public void SearchStatus()
        {
            List<Car> cars = new List<Car>();
            //判断文件是否存在
            if (!File.Exists(Path))
            {
                Console.WriteLine("还未有车辆信息，请先添加");
                return;
            }
            {
                string jsonStr = File.ReadAllText(this.Path);
                cars = JsonSerializer.Deserialize<List<Car>>(jsonStr);
                // 判断 列表是否存在
                if (cars.Count == 0)
                {
                    Console.WriteLine("还未有车辆信息，请先添加");
                    return;
                }

                if (cars.Exists(car => car.Status))
                {
                    foreach (Car car in cars)
                    {
                        Console.WriteLine($"id : {car.Id} -- 车牌 : {car.Card} -- 类型 : {car.Type} -- 时租费 : {car.Price} ");
                        break;
                    }
                    
                }
                else
                {
                    Console.WriteLine("\"没有空闲车辆信息\"");

                }

                
            }
            string resStr = JsonSerializer.Serialize(cars, this.JsonOpt);
            File.WriteAllText(this.Path, resStr);
        }
    }
}
