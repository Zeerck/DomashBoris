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
                float x = float.Parse(Console.ReadLine());

                Console.WriteLine("Введите y: ");
                float y = float.Parse(Console.ReadLine());

                float xSum, ySum;

                xSum = x * x;
                ySum = y * y;

                if ((xSum + ySum) > 4 & y < 6)
                {
                    Console.WriteLine("Точка входит в фигуру\n\nНажмите X чтобы выйти или B для продолжения работы в программе");

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
                else if ((xSum + ySum) < 4 || y >= 6)
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
                else
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
        }
    }
}
