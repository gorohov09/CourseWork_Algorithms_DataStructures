﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_Algorithms_Data_Structures
{
    public class App
    {
        public static void Run(Storage repository)
        {
            Console.WriteLine("Консольный интерфейс для работы со структурой");
            while (true)
            {
                Console.WriteLine("Выбирите действия:");
                Console.WriteLine("0 - Выход из программы");
                Console.WriteLine("1 - Просмот структуры");
                Console.WriteLine("2 - Добавление аэропорта");
                Console.WriteLine("3 - Добавление самолета в аэропорт");
                Console.WriteLine("4 - Удаление аэропорта");
                Console.WriteLine("5 - Удаление самолета");
                Console.WriteLine("6 - Поиск аэропорта");
                Console.WriteLine("7 - Поиск самолета");

                Console.Write("Выбор: ");
                int choice = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if (choice == 1)
                {
                    AirCompany company = repository.GetMainStructure();

                    foreach (var airport in company)
                    {
                        Console.WriteLine($"Аэропорт {airport.Name}: ");
                        int number = 1;
                        Console.WriteLine($"  Самолеты:");
                        foreach (var airplane in airport)
                        {
                            Console.WriteLine($"    №{number} Бренд:{airplane.Brand} - Год выпуска:{airplane.YearofManufacture} ");
                            number++;
                        }
                        Console.WriteLine();
                    }
                }
                else if (choice == 2)
                {
                    Console.Write("Введите название аэропорта: ");
                    string name_airport = Console.ReadLine();
                    try
                    {
                        repository.AddAirport(name_airport);
                        Console.WriteLine("Аэропорт успешно добавлен!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (choice == 3)
                {
                    Console.Write("Введите бренд самолета: ");
                    string brand_airplane = Console.ReadLine();
                    Console.Write("Введите год производства самолета: ");
                    int year_airplane = int.Parse(Console.ReadLine());
                    Console.Write("Введите название аэропорта самолета: ");
                    string name_airport = Console.ReadLine();
                    try
                    {
                        repository.AddAirplane(brand_airplane, year_airplane, name_airport);
                        Console.WriteLine($"Самолет успешно добавлен в аэропорт: {name_airport}!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (choice == 4)
                {
                    try
                    {
                        repository.DeleteAirport();
                        Console.WriteLine("Аэропорт успешно удален!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (choice == 5)
                {
                    Console.Write("Введите название аэропорта самолета: ");
                    string name_airport = Console.ReadLine();
                    try
                    {
                        repository.DeleteAirplane(name_airport);
                        Console.WriteLine("Аэропорт успешно удален!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (choice == 6)
                {
                    Console.Write("Введите название аэропорта: ");
                    string name_airport = Console.ReadLine();
                    try
                    {
                        var airport = repository.ContainsAirport(name_airport);
                        Console.WriteLine($"Аэропорт {airport.Name} успешно найден. Кол-во самолетов в нем: {airport.Count}!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (choice == 7)
                {
                    Console.Write("Введите бренд самолета: ");
                    string brand_airplane = Console.ReadLine();
                    Console.Write("Введите год производства самолета: ");
                    int year_airplane = int.Parse(Console.ReadLine());
                    try
                    {
                        var airplane = repository.ContainsAirplane(brand_airplane, year_airplane, out string name_airport);

                        Console.WriteLine($"Самолет: {airplane.Brand}-{airplane.YearofManufacture} найден в аэропорту: {name_airport}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (choice == 0)
                    break;
            }

            Console.WriteLine("Программа завершила свою работу!");
        }
    }
}
