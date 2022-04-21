using BP202Stadiums.Data;
using BP202Stadiums.Models;
using System;

namespace BP202Stadiums
{
    class Program
    {
        static void Main(string[] args)
        {
            StadiumData stadiumData = new StadiumData();
            bool check = true;
            string ans;
            do
            {
                Console.WriteLine("1. Stadion elave et");
                Console.WriteLine("2. Stadionlara goster");
                Console.WriteLine("3.  Verilmiş id-li stadionu göstər");
                Console.WriteLine("4. Verilmiş id-li stadionu sil");
                Console.WriteLine("0. Quit");

                ans = Console.ReadLine();


                switch (ans)
                {
                    case "1":
                        Console.WriteLine("insert");
                        Console.WriteLine("Name daxil edin:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Price daxil et:");
                        int price = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Capacity daxil et:");
                        int cap = Convert.ToInt32(Console.ReadLine());

                        Stadiums stadium = new Stadiums
                        {
                            Capacity = cap,
                            Name = name,
                            HourPrice = price,
                        };

                        stadiumData.Insert(stadium);
                        break;
                    case "2":


                        var stadiums = stadiumData.Select();

                        foreach (var item in stadiums)
                        {
                            Console.WriteLine(item.Id + " - " + item.Name + " - " + item.HourPrice);
                        }

                        break;
                    case "3":
                        Console.WriteLine("Id daxil et:");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Stadiums std = stadiumData.GetById(id);
                        Console.WriteLine(std.Name);
                        break;
                    case "4":
                        Console.WriteLine("Id daxil et:");
                        int id2 = Convert.ToInt32(Console.ReadLine());
                        stadiumData.Delete(id2);
                        break;
                    case "0":
                        check = false;
                        break;
                    default:
                        Console.WriteLine("Dogru secim edin:");
                        break;
                }

            } while (check);
        
        }
        
    }
}
