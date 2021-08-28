using System;
using System.Collections.Generic;

namespace HomeWork3_10_2_
{
    class Program
    {
        static void Main(string[] args)
        {
            //Задани2. Повышение уровня сложности игры или увеличение числа игроков

            Console.Write("Введите произвольное положительное целое число: "); int gameNumber = int.Parse(Console.ReadLine());
            Console.Write("Введите произвольное минимальное положительное целое число: "); int minUserTry = int.Parse(Console.ReadLine());
            Console.Write("Введите произвольное максимальное положительное целое число: "); int maxUserTry = int.Parse(Console.ReadLine());

            List<string> names = new List<string>();
            int i = 1;
            string name="";
            string revansh = "";
            bool f = false;
            while((name != "+") || (i <= 2))
            {
                Console.Write("Пожалуйста, представьтесь: "); name = Console.ReadLine();
                names.Add(name);
                i++;
            }

            i = 1;
            while((revansh == "да") && (f == false))
            {
                while((gameNumber != 0) && (f == false))
                {
                    foreach(string n in names)
                    {
                        Console.Write($"{names[i]}, введите произвольное положительное целое число от {minUserTry} до {maxUserTry}: "); int userTry = int.Parse(Console.ReadLine());
                        if (userTry > 1)
                        {
                            if (gameNumber > userTry)
                            {
                                if ((userTry >= minUserTry) && (userTry <= maxUserTry))
                                {
                                    gameNumber -= userTry;
                                }
                                else
                                {
                                    i++;
                                    continue;
                                }
                            }
                            else
                            {
                                f = true;
                                Console.WriteLine("Объявляется ничья");
                                break;
                            }
                        }
                    }
                    i = 0;
                }
                Console.WriteLine($"Победитель {names[i]}!");
                Console.Write($"{names[i]}, Вы согласны на реванш? введите 'да' или 'нет': "); revansh = Console.ReadLine();
            }
        }
    }
}
