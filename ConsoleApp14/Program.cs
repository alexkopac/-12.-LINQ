using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{

//4
    public class Phone
    {
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public decimal Price { get; set; }
        public int ReleaseYear { get; set; }

        public Phone(string model, string manufacturer, decimal price, int releaseYear)
        {
            Model = model;
            Manufacturer = manufacturer;
            Price = price;
            ReleaseYear = releaseYear;
        }

        public override string ToString()
        {
            return $"Model: {Model}, Manufacturer: {Manufacturer}, Price: {Price}, Release Year: {ReleaseYear}";
        }
    }
//2
    public class Device : IEquatable<Device>
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public decimal Cost { get; set; }

        public Device(string name, string manufacturer, decimal cost)
        {
            Name = name;
            Manufacturer = manufacturer;
            Cost = cost;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Manufacturer: {Manufacturer}, Cost: {Cost}";
        }


        public bool Equals(Device other)
        {
            if (other is null)
                return false;

            return Manufacturer.Equals(other.Manufacturer, StringComparison.OrdinalIgnoreCase);
        }

        public override bool Equals(object obj) => Equals(obj as Device);
        public override int GetHashCode() => Manufacturer?.GetHashCode() ?? 0;
    }

    public class Program
    {
        public static List<Device> ArrayDifference(List<Device> first, List<Device> second)
        {
            return first.Except(second).ToList();
        }

        public static List<Device> ArrayIntersection(List<Device> first, List<Device> second)
        {
            return first.Intersect(second).ToList();
        }

        public static List<Device> ArrayUnion(List<Device> first, List<Device> second)
        {
            return first.Union(second).ToList();
        }

        public static void PrintDeviceArray(string arrayName, List<Device> devices)
        {
            Console.WriteLine($"\n--- {arrayName} ---");
            if (devices.Count == 0)
            {
                Console.WriteLine("Array is empty.");
            }
            else
            {
                foreach (var device in devices)
                {
                    Console.WriteLine(device);
                }
            }
        }
//2
        public static void Main(string[] args)
        {

            List<Device> devices1 = new List<Device>()
        {
             new Device("Смартфон A1", "Samsung", 500),
             new Device("Ноутбук X", "Apple", 1200),
             new Device("Планшет T", "Samsung", 300),
             new Device("Наушники Z", "Sony", 150),
             new Device("Смарт-часы W", "Xiaomi", 200)
        };


            List<Device> devices2 = new List<Device>()
        {
            new Device("Смартфон S2", "Apple", 600),
            new Device("Планшет M", "Samsung", 350),
            new Device("Телевизор L", "Sony", 800),
            new Device("Фитнес-браслет B", "Xiaomi", 50),
            new Device("Смартфон C3", "Google", 700)
        };

            PrintDeviceArray("Первый массив устройств", devices1);
            PrintDeviceArray("Второй массив устройств", devices2);


            List<Device> difference1_2 = ArrayDifference(devices1, devices2);
            PrintDeviceArray("Разница (производители из первого массива отсутствуют во втором)", difference1_2);


            List<Device> difference2_1 = ArrayDifference(devices2, devices1);
            PrintDeviceArray("Разница (производители из второго массива отсутствуют в первом)", difference2_1);


            List<Device> intersection = ArrayIntersection(devices1, devices2);
            PrintDeviceArray("Пересечение (устройства с общими производителями в обоих массивах)", intersection);


            List<Device> union = ArrayUnion(devices1, devices2);
            PrintDeviceArray("Объединение (все уникальные устройства по производителю из обоих массивов)", union);



            List<Phone> phones = new List<Phone>()
        {

                //4
            new Phone("iPhone 15 Pro Max", "Apple", 1500, 2023),
            new Phone("Samsung Galaxy S23 Ultra", "Samsung", 1300, 2023),
            new Phone("Xiaomi 13 Pro", "Xiaomi", 1100, 2022),
            new Phone("Google Pixel 8 Pro", "Google", 1200, 2023),
            new Phone("iPhone SE (2022)", "Apple", 450, 2022),
            new Phone("Samsung Galaxy A14", "Samsung", 200, 2023),
            new Phone("Xiaomi Redmi 12C", "Xiaomi", 150, 2023),
            new Phone("Nokia 3310", "HMD Global", 50, 2000),
            new Phone("Motorola RAZR V3", "Motorola", 600, 2004),
            new Phone("Siemens C65", "Siemens", 300, 2003),
            new Phone("iPhone 6s", "Apple", 700, 2015),
            new Phone("Samsung Galaxy S7", "Samsung", 800, 2016),
            new Phone("Xiaomi Mi 9", "Xiaomi", 500, 2019),
            new Phone("Google Pixel 3", "Google", 650, 2018),
            new Phone("Huawei P30 Pro", "Huawei", 900, 2019)
        };

            Console.WriteLine("--- All Phones ---");
            foreach (var phone in phones)
            {
                Console.WriteLine(phone);
            }
            Console.WriteLine();

            
            Console.WriteLine("--- Top 5 Most Expensive Phones ---");
            phones.OrderByDescending(p => p.Price).Take(5).ToList().ForEach(Console.WriteLine);
            Console.WriteLine();

            
            Console.WriteLine("--- Top 5 Cheapest Phones ---");
            phones.OrderBy(p => p.Price).Take(5).ToList().ForEach(Console.WriteLine);
            Console.WriteLine();

            
            Console.WriteLine("--- Top 3 Oldest Phones ---");
            phones.OrderBy(p => p.ReleaseYear).Take(3).ToList().ForEach(Console.WriteLine);
            Console.WriteLine();

            
            Console.WriteLine("--- Top 3 Newest Phones ---");
            phones.OrderByDescending(p => p.ReleaseYear).Take(3).ToList().ForEach(Console.WriteLine);
            Console.WriteLine();
        }




        }
}
