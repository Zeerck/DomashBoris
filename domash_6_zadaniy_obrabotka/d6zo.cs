using System;

namespace domash_6_zadaniy_obrabotka
{
    class d6zo
    {
         static void Main()
         {
            m1:
                Console.Clear();    //Очистка консоли

                Console.WriteLine("Выберите опцию (Используйте цифры и буквы на клавиатуре):\n\n" +
               "1. Задание 1: Вывод на экран сложения двух целых чисел\n" +
               "2. Задание 2: Вывод на экран суммы чисел в прямом и обратном порядке\n" +
               "3. Задание 3: Вывод на экран суммы трёх чисел\n" +
               "4. Задание 4: Вывод на экран произведения двух вещественных чисел (До 1 знака после запятой)\n" +
               "5. Задание 5: Вывод на экран результат деления чисел (До 3-х знаков поле запятой)\n" +
               "6. Задание 6: Вывод на экран трех вещественных числа (до 2-х знаков после запятой)\n" +
               "\nВыход: X\n");

            while (true) // Привет здесь !
            {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    if (key.Key == ConsoleKey.D1)
                    {
                        try
                        {
                            Console.Clear();

                            Console.WriteLine("Задание 1: Вывод на экран сложения двух целых чисел\n");

                            Console.Write("Введите a: ");
                            int a = int.Parse(Console.ReadLine());  

                            Console.Write("Введите b: ");
                            int b = int.Parse(Console.ReadLine());  

                            int c = a + b;

                            Console.WriteLine("Ответ: {0} + {1} = {2}\n\nНазад: B\nВыход: X\n", a, b, c);
                        }

                        catch (FormatException)
                        {
                            WriteError.Format();
                            goto m1;
                        }
                        catch (OverflowException)
                        {
                            WriteError.OverFlow();
                            goto m1;
                        }

                        ConsoleKeyInfo keyback = Console.ReadKey(true);

                        if (keyback.Key == ConsoleKey.B)
                        {
                            Console.Clear();
                            goto m1;
                        }
                        if (keyback.Key == ConsoleKey.X)
                        {
                            Environment.Exit(0);
                        }
                    }

                    if (key.Key == ConsoleKey.D2)
                    {
                        try
                        {
                            Console.Clear();

                            Console.WriteLine("Задание 2: Вывод на экран суммы чисел в прямом и обратном порядке\n");

                            Console.Write("Введите a: ");
                            int a = int.Parse(Console.ReadLine());

                            Console.Write("Введите b: ");
                            int b = int.Parse(Console.ReadLine());

                            Console.WriteLine("{0} + {1} = {1} + {0}\n\nНазад: B\nВыход: X\n", a, b);
                        }

                        catch (FormatException)
                        {
                            WriteError.Format();
                            goto m1;
                        }
                        catch (OverflowException)
                        {
                            WriteError.OverFlow();
                            goto m1;
                        }

                        ConsoleKeyInfo keyback = Console.ReadKey(true);

                        if (keyback.Key == ConsoleKey.B)
                        {
                            Console.Clear();
                            goto m1;
                        }
                        if (keyback.Key == ConsoleKey.X)
                        {
                            Environment.Exit(0);
                        }
                    }

                    if (key.Key == ConsoleKey.D3)
                    {
                        try
                        {
                            Console.Clear();

                            Console.WriteLine("Задание 3: Вывод на экран суммы трёх чисел\n");

                            Console.Write("Введите a: ");
                            int a = int.Parse(Console.ReadLine());

                            Console.Write("Введите b: ");
                            int b = int.Parse(Console.ReadLine());

                            Console.Write("Введите c: ");
                            int c = int.Parse(Console.ReadLine());

                            int d = a + b + c;

                            Console.WriteLine("Ответ: {0} + {1} + {2} = {3}\n\nНазад: B\nВыход: X\n", a, b, c, d);
                        }

                        catch (FormatException)
                        {
                            WriteError.Format();
                            goto m1;
                        }
                        catch (OverflowException)
                        {
                            WriteError.OverFlow();
                            goto m1;
                        }

                        ConsoleKeyInfo keyback = Console.ReadKey(true);

                        if (keyback.Key == ConsoleKey.B)
                        {
                            Console.Clear();
                            goto m1;
                        }
                        if (keyback.Key == ConsoleKey.X)
                        {
                            Environment.Exit(0);
                        }
                    }

                    if (key.Key == ConsoleKey.D4)
                    {
                        try
                        {
                            Console.Clear();

                            Console.WriteLine("Задание 4: Вывод на экран произведения двух вещественных чисел (До 1 знака после запятой)\n");

                            Console.Write("Введите а: ");
                            float a = float.Parse(Console.ReadLine());

                            Console.Write("Введите b: ");
                            float b = float.Parse(Console.ReadLine());

                            float c = a * b;

                            Console.WriteLine("Ответ: {0} * {1} = {2}\n\nНазад: B\nВыход: X\n", a, b, (float)Math.Round(c, 1));
                        }

                        catch (FormatException)
                        {
                            WriteError.Format();
                            goto m1;
                        }
                        catch (OverflowException)
                        {
                            WriteError.OverFlow();
                            goto m1;
                        }
                        catch (ArithmeticException)
                        {
                            WriteError.Arithmetic();
                            goto m1;
                        }

                        ConsoleKeyInfo keyback = Console.ReadKey(true);

                        if (keyback.Key == ConsoleKey.B)
                        {
                            Console.Clear();
                            goto m1;
                        }
                        if (keyback.Key == ConsoleKey.X)
                        {
                            Environment.Exit(0);
                        }
                    }

                    if (key.Key == ConsoleKey.D5)
                    {
                        try
                        {
                            Console.Clear();

                            Console.WriteLine("Задание 5: Вывод на экран результат деления чисел (До 3-х знаков поле запятой)\n");

                            Console.Write("Введите a: ");
                            decimal a = decimal.Parse(Console.ReadLine());

                            Console.Write("Введите b: ");
                            decimal b = decimal.Parse(Console.ReadLine());

                            decimal c = a / b;

                            Console.WriteLine("Ответ: {0} / {1} = {2}\n\nНазад: B\nВыход: X\n", a, b, (decimal)Math.Round(c, 3));
                        }

                        catch (DivideByZeroException)
                        {
                            WriteError.Zero();
                            goto m1;
                        }
                        catch (FormatException)
                        {
                            WriteError.Format();
                            goto m1;
                        }
                        catch (OverflowException)
                        {
                            WriteError.OverFlow();
                            goto m1;
                        }

                        ConsoleKeyInfo keyback = Console.ReadKey(true);

                        if (keyback.Key == ConsoleKey.B)
                        {
                            Console.Clear();
                            goto m1;
                        }
                        if (keyback.Key == ConsoleKey.X)
                        {
                            Environment.Exit(0);
                        }
                    }

                    if (key.Key == ConsoleKey.D6)
                    {
                        try
                        {
                            Console.Clear();

                            Console.WriteLine("Задание 6: Вывод на экран трех вещественных числа (до 2-х знаков после запятой)\n");

                            Console.Write("Введите a: ");
                            float a = float.Parse(Console.ReadLine());

                            Console.Write("Введите b: ");
                            float b = float.Parse(Console.ReadLine());

                            Console.Write("Введите c: ");
                            float c = float.Parse(Console.ReadLine());

                            Console.WriteLine("Ответ: ({0} + {1}) + {2} = {0} + ({1} + {2})\n\nНазад: B\nВыход: X\n", (float)Math.Round(a, 2), (float)Math.Round(b, 2), (float)Math.Round(c, 2));
                        }

                        catch (FormatException)
                        {
                            WriteError.Format();
                            goto m1;
                        }
                        catch (OverflowException)
                        {
                            WriteError.OverFlow();
                            goto m1;
                        }
                        catch (ArithmeticException)
                        {
                            WriteError.Arithmetic();
                            goto m1;
                        }

                        ConsoleKeyInfo keyback = Console.ReadKey(true);

                        if (keyback.Key == ConsoleKey.B)
                        {
                            Console.Clear();
                            goto m1;
                        }
                        if (keyback.Key == ConsoleKey.X)
                        {
                            Environment.Exit(0);
                        }
                    }

                    if (key.Key == ConsoleKey.X)
                    {
                        Environment.Exit(0);
                    }
                }
         }
    }
}