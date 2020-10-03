using System;

namespace domash_figure_9
{
    class df9
    {
        static void Main()
        {
        m1:
            try
            {
                Console.Clear();
                Console.WriteLine("Введите x: ");
                int x = int.Parse(Console.ReadLine());

                Console.WriteLine("Введите y: ");
                int y = int.Parse(Console.ReadLine());

                if ((y == 0) && (x >= 2 && x <= 6) || ((y == 1) && (x == 5)) || ((y == 2) && (x == 1 || x == 4)) || ((y == 3) && (x == 3)) || ((y == 4) && (x == 0 || x == 2)) || ((y == 5) && (x == 1 || x == 0)) || ((y == 6) && (x == 0)))
                {
                    Console.WriteLine("Точка на границе фигуры\n\nНажмите X чтобы выйти или B для продолжения работы в программе");

                    ConsoleKeyInfo key = Console.ReadKey(true);

                    if (key.Key == ConsoleKey.X)
                    {
                        Environment.Exit(0);
                    }
                    if (key.Key == ConsoleKey.B)
                    {
                        goto m1;
                    }
                }
                else if (((y == 1) && (x >= 2 && x <= 4)) || ((y == 2) && (x == 2 || x == 3)) || ((y == 3) && (x == 1 || x == 2)) || ((y == 4) && (x == 1)))
                {
                    Console.WriteLine("Точка в фигуре\n\nНажмите X чтобы выйти или B для продолжения работы в программе");

                    ConsoleKeyInfo key = Console.ReadKey(true);

                    if (key.Key == ConsoleKey.X)
                    {
                        Environment.Exit(0);
                    }
                    if (key.Key == ConsoleKey.B)
                    {
                        goto m1;
                    }
                }
                else
                {
                    Console.WriteLine("Точка вне фигуры\n\nНажмите X чтобы выйти или B для продолжения работы в программе");

                    ConsoleKeyInfo key = Console.ReadKey(true);

                    if (key.Key == ConsoleKey.X)
                    {
                        Environment.Exit(0);
                    }
                    if (key.Key == ConsoleKey.B)
                    {
                        goto m1;
                    }
                }
            }

            catch (FormatException)
            {
                Console.WriteLine("Не верный тип вводимых данных. Допускаются только цифры\n\nНажмите X чтобы выйти или B для продолжения работы в программе");

                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.X)
                {
                    Environment.Exit(0);
                }
                if (key.Key == ConsoleKey.B)
                {
                    goto m1;
                }
            }
            /* Предыдущая форма программы
             * Проблема в точке y == 1 && x == 6 (а так же последующих y == 2 && x == 5 и т.д.), которая считается "В фигуре", а должна считаться как "вне фигуры"
             * Точка y == 2 && x == 1, считывалась правильно
             * Картинка с заданием находится под названием "image.png"
             * Более гениальных идей чем просто выборкой отметить точки "на границе" и "в фигуре" у меня нет
             * 
             * int xSum = x * x, ySum = y * y;
             *
             * if ((xSum + ySum) > 4 & y < 6)
             * 
             * else if ((xSum + ySum) < 4 || y >= 6)
             * 
             * else
             * 
             * Last comment by Zeerck
             */
        }
    }
}
