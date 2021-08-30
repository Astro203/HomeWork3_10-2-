using System;
using System.Collections.Generic;

namespace HomeWork3_10_2_
{
    class Program
    {
        static void Main(string[] args)
        {
            //Задани2. Повышение уровня сложности игры или увеличение числа игроков

            Console.ForegroundColor = ConsoleColor.Green; //Цвет текста выводимый далее в консоль зеленый
            Console.WriteLine("Правила игры:");
            Console.WriteLine("Загадывается число от 12 до 120, причем случайным образом. Назовем его gameNumber.");
            Console.WriteLine("Игроки по очереди выбирают число от одного до четырех. Пусть это число обозначается как userTry.");
            Console.WriteLine("userTry после каждого хода вычитается из gameNumber, а само gameNumber выводится на экран.");
            Console.WriteLine("Если после хода игрока gameNumber равняется нулю, то походивший игрок объявляется победителем.");
            Console.WriteLine("Число четыре вводить нельзя, если userTry больше чем gameNumber");
            Console.ResetColor(); //Сброс цвета на стандартный
            Console.WriteLine();

            Console.Write("Введите произвольное положительное целое число: "); int gameNumber = int.Parse(Console.ReadLine()); //ввод начального числа
            Console.Write("Введите произвольное минимальное положительное целое число: "); int minUserTry = int.Parse(Console.ReadLine()); //ввод минимального числа для выбора игрока
            Console.Write("Введите произвольное максимальное положительное целое число: "); int maxUserTry = int.Parse(Console.ReadLine()); //ввод максимального числа для выбора игрока

            List<string> names = new List<string>(); //добавление списка имен игроков
            int i = 1;
            string name="";
            string revansh = "да";
            bool draw = false; //переменная для случая "ничья"
            Console.WriteLine("\nДалее введите имена игроков. Окончание заполнения - символ '+'"); //описание условия для завершения ввода имен игроков
            while(true) 
            {
                Console.Write("Пожалуйста, представьтесь: "); name = Console.ReadLine(); //ввод имени игрока
                if (name != "+") //если введенная строка не равна '+', то...
                {
                    names.Add(name); //добавить в список введенное имя
                    i++; //инкремент для подсчета количества игроков
                }
                else //если введенная строка равна '+', то...
                {
                    if (i <= 2) continue; //если количество игроков меньше трех, то переход на следующую итерацию цикла для повторного ввода имени
                    else break; //если число игроков три или более, то заввершение цикла (также при условии, что введен '+')
                }
            }

            Console.WriteLine(); //переход в консоли на строку ниже
            i = 0;
            while((revansh == "да") && (!draw)) //пока победитель соглашается на реванш или нет ничьей выполнять и нет "ничьей", выполнять...
            {
                while((gameNumber != 0) && (!draw)) //пока итоговый gameNumber не равен нулю и нет "ничьей", выполнять...
                {
                    foreach(var n in names) //цикл для очередности хода
                    {
                        Console.Write($"{names[i]}, введите произвольное положительное целое число от {minUserTry} до {maxUserTry}: "); int userTry = int.Parse(Console.ReadLine()); //ввод игроками числа между мин и макс
                        if (userTry >= 1) //если введенное число больше 1, то...
                        {
                            if (gameNumber >= userTry) //если введенное число больше итогового gameNumber, то...
                            {
                                if ((userTry >= minUserTry) && (userTry <= maxUserTry)) //если введенное число находится между мин и макс, то...
                                {
                                    gameNumber -= userTry; //вычитание из gameNumber введенного числа
                                    Console.WriteLine($"Оставшееся число: {gameNumber}"); //вывод оставшегося gameNumber
                                }
                                else //если число не входит в диапазон, то...
                                {
                                    i++; //индекс следующего игрока в списке
                                    Console.WriteLine("Переход хода");
                                    continue; //переход хода к следующему по списку игроку
                                }
                            }
                            else //если gameNumber < введенного числа, то...
                            {
                                draw = true; //достижение ситуации "ничья"
                                Console.WriteLine("Объявляется ничья"); //объявляется ничья
                                break; //завершение цикла очередности хода
                            }
                        }
                    }
                    i = 0; //индекс обнулен для обращения к первому игроку, при переходе хода от крайнего игрока в списке
                }
                Console.WriteLine($"Победитель {names[i + 1]}!"); //вывод имени победителя
                Console.Write($"{names[i + 1]}, Вы согласны на реванш? введите 'да' или 'нет': "); revansh = Console.ReadLine(); //предложение победителю реванша
            }
        }
    }
}
