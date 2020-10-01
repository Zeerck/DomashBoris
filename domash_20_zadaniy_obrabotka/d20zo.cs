using System;

namespace domash_20_zadaniy_obrabotka
{
    class d20zo
    {
        static void Main()
        {

        m1: Console.Clear();

            Console.WriteLine("Выберите опцию (Используйте цифры и буквы на клавиатуре):\n\n" +
               "1. Задание 1. Периметр квадрата\n" +
               "2. Задание 2. Площадь равностороннего треугольника\n" +
               "3. Задание 3. Расстояние между точками с координатами a, b и c, d\n" +
               "4. Задание 4. Cреднее арифметическое кубов двух данных чисел\n" +
               "5. Задание 5. Cреднее геометрическое модулей двух данных чисел\n" +
               "6. Задание 6. Гипотенузу прямоугольного треугольника по двум данным катетам a, b\n" +
               "7. Задание 7. Площадь прямоугольного треугольника по двум его катетам\n" +
               "8. Задание 8. Периметр прямоугольного треугольника по двум его катетам\n" +
               "\n9. Следующая страница\n" +
               "\nВыход: X\n");

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.D1)
                {
                    try
                    {
                        Console.Clear();

                        Console.WriteLine("Задание 1: Вычесление периметра квадрата по стороне\n");

                        Console.Write("Введите сторону квадрата a = ");
                        float a = float.Parse(Console.ReadLine());
                        double p = 4 * a;
                        Console.WriteLine("\nПериметр квадрата p = {0}\n\nНазад: B\nВыход: X\n", (double)Math.Round(p, 2));
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

                        Console.WriteLine("Задание 2: Площадь равностороннего треугольника\n");

                        Console.Write("Введите основание a = ");
                        double a = double.Parse(Console.ReadLine());
                        double s = (Math.Sqrt(3) / 4) * Math.Pow(a, 2);

                        Console.WriteLine("Площадь ранвостороннего треугольника s = {0}\n\nНазад: B\nВыход: X\n", (double)Math.Round(s, 2));
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
                    catch (DivideByZeroException)
                    {
                        WriteError.Zero();
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

                        Console.WriteLine("Задание 3: Расстояние между точками с координатами a, b и c, d\n");

                        Console.Write("Введите координаты точки a = ");
                        double a = double.Parse(Console.ReadLine());
                        Console.Write("Введите координаты точки b = ");
                        double b = double.Parse(Console.ReadLine());
                        Console.Write("Введите координаты точки c = ");
                        double c = double.Parse(Console.ReadLine());
                        Console.Write("Введите координаты точки d = ");
                        double d = double.Parse(Console.ReadLine());

                        double dot1 = b - a;
                        double dot2 = d - c;

                        Console.WriteLine("\nРасстояние между a: {0} и b: {1} = {4}\nРасстояние между c: {2} или d: {3} = {5}\n\nНазад: B\nВыход: X\n", a, b, c, d, (double)Math.Round(dot1, 1), (double)Math.Round(dot2, 1));
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

                        Console.WriteLine("Задание 4: Cреднее арифметическое кубов двух данных чисел\n");

                        Console.Write("Введите a = ");
                        decimal a = decimal.Parse(Console.ReadLine());
                        Console.Write("Введите b = ");
                        decimal b = decimal.Parse(Console.ReadLine());

                        decimal p = (a + b) / 2;

                        Console.WriteLine("Cреднее арифметическое кубов двух данных чисел p = {0}\n\nНазад: B\nВыход: X\n", (decimal)Math.Round(p, 2));
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
                    catch (DivideByZeroException)
                    {
                        WriteError.Zero();
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

                        Console.WriteLine("Задание 5: Cреднее геометрическое модулей двух данных чисел\n");

                        Console.Write("Введите a = ");
                        Int32 a = Int32.Parse(Console.ReadLine());
                        Console.Write("Введите b = ");
                        Int32 b = Int32.Parse(Console.ReadLine());

                        if (a < 0)
                        {
                            a = -a;
                        }
                        if (b < 0)
                        {
                            b = -b;
                        }

                        double c = Math.Sqrt(a * b);

                        Console.WriteLine("Cреднее геометрическое модулей двух данных чисел c = {0}\n\nНазад: B\nВыход: X\n", (double)Math.Round(c, 2));
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

                        Console.WriteLine("Задание 6: Гипотенузу прямоугольного треугольника по двум данным катетам a, b\n");

                        Console.Write("Введите катет a = ");
                        Int32 a = Int32.Parse(Console.ReadLine());
                        Console.Write("Введите катет b = ");
                        Int32 b = Int32.Parse(Console.ReadLine());

                        double c = Math.Sqrt((a * a) + (b * b));

                        Console.WriteLine("Гипотенуза прямоугольного треугольника по двум катетам c = {0}\n\nНазад: B\nВыход: X\n", (double)Math.Round(c, 2));
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

                if (key.Key == ConsoleKey.D7)
                {
                    try
                    {
                        Console.Clear();

                        Console.WriteLine("Задание 7: Площадь прямоугольного треугольника по двум его катетам\n");

                        Console.Write("Введите катет a = ");
                        Int32 a = Int32.Parse(Console.ReadLine());
                        Console.Write("Введите катет b = ");
                        Int32 b = Int32.Parse(Console.ReadLine());

                        double c = 0.5 * a * b;

                        Console.WriteLine("Площадь прямоугольного треугольника по двум его катетам c = {0}\n\nНазад: B\nВыход: X\n", (double)Math.Round(c, 2));
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

                if (key.Key == ConsoleKey.D8)
                {
                    try
                    {
                        Console.Clear();

                        Console.WriteLine("Задание 8: Периметр прямоугольного треугольника по двум его катетам\n");

                        Console.Write("Введите катет a = ");
                        Int32 a = Int32.Parse(Console.ReadLine());
                        Console.Write("Введите катет b = ");
                        Int32 b = Int32.Parse(Console.ReadLine());

                        double c = (double)Math.Round(Math.Sqrt(Math.Sqrt(a) + Math.Sqrt(b)));
                        double d = a + b + c;

                        Console.WriteLine("Периметр прямоугольного треугольника по двум его катетам c = {0}\n\nНазад: B\nВыход: X\n", (double)Math.Round(d, 2));
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

                if (key.Key == ConsoleKey.D9)
                {
                    Console.Clear();
                    goto m2;
                }

                if (key.Key == ConsoleKey.X)
                {
                    Environment.Exit(0);
                }

                if (key.Key == ConsoleKey.D0)
                {
                    Console.Clear();
                    goto m1;
                }
            }

        m2: Console.Clear();

            Console.WriteLine("Выберите опцию:\n\n" +
               "1. Задание 9: Найти ребро куба по его площади\n" +
               "2. Задание 10: Найти ребро куба по его объёму\n" +
               "3. Задание 11. Найти периметр треугольника заданного координатами вершин\n" +
               "4. Задание 12: Найти площадь треугольника заданного координатами вершин\n" +
               "5. Задание 13. Найти радиус окружности по длине\n" +
               "6. Задание 14. Найти радиус окружности по площади\n" +
               "\n9. Предыдущая страница\n" +
               "\nВыход: X\n");

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.D1)
                {
                    try
                    {
                        Console.Clear();

                        Console.WriteLine("Задание 9: Найти ребро куба по его площади\n");

                        Console.Write("Введите площадь куба c = ");
                        double sCube = double.Parse(Console.ReadLine());

                        double Edge = Math.Sqrt(sCube / 6);

                        Console.WriteLine("Ребро куба e = {0}\n\nНазад: B\nВыход: X\n", (double)Math.Round(Edge, 2));
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
                        goto m2;
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

                        Console.WriteLine("Задание 10: Найти ребро куба по его объёму\n");

                        Console.Write("Введите объём куба v = ");
                        double vCube = double.Parse(Console.ReadLine());

                        double Edge = Math.Pow(vCube, 1.0 / 3.0);

                        Console.WriteLine("Ребро куба e = {0}\n\nНазад: B\nВыход: X\n", (double)Math.Round(Edge, 2));
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
                        goto m2;
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

                        Console.WriteLine("Задание 11: Найти периметр треугольника заданного координатами вершин\n");

                        Console.Write("Введите первые координаты x1 и y1\nx1: ");
                        int x1 = int.Parse(Console.ReadLine());
                        Console.Write("y1: ");
                        int y1 = int.Parse(Console.ReadLine());

                        Console.Write("Введите вторые координаты x2 и y2\nx2: ");
                        int x2 = int.Parse(Console.ReadLine());
                        Console.Write("y2: ");
                        int y2 = int.Parse(Console.ReadLine());

                        Console.Write("Введите третьи координаты x3 и y3\nx3: ");
                        int x3 = int.Parse(Console.ReadLine());
                        Console.Write("y3: ");
                        int y3 = int.Parse(Console.ReadLine());

                        double Side1, Side2, Side3;

                        Side1 = Math.Pow(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2), 0.5);
                        Side2 = Math.Pow(Math.Pow(x2 - x3, 2) + Math.Pow(y2 - y3, 2), 0.5);
                        Side3 = Math.Pow(Math.Pow(x3 - x1, 2) + Math.Pow(y3 - y1, 2), 0.5);

                        double Res = (Side1 + Side2 + Side3) / 2;

                        Console.WriteLine("Периметр треугольника = {0}\n\nНазад: B\nВыход: X\n", (double)Math.Round(Res, 2));
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
                        goto m2;
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

                        Console.WriteLine("Задание 12: Найти площадь треугольника заданного координатами вершин\n");

                        Console.Write("Введите первые координаты x1 и y1\nx1: ");
                        double x1 = double.Parse(Console.ReadLine());
                        Console.Write("y1: ");
                        double y1 = double.Parse(Console.ReadLine());

                        Console.Write("Введите вторые координаты x2 и y2\nx2: ");
                        double x2 = double.Parse(Console.ReadLine());
                        Console.Write("y2: ");
                        double y2 = double.Parse(Console.ReadLine());

                        Console.Write("Введите третьи координаты x3 и y3\nx3: ");
                        double x3 = double.Parse(Console.ReadLine());
                        Console.Write("y3: ");
                        double y3 = double.Parse(Console.ReadLine());

                        double a = Math.Pow(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2), 0.5);
                        double b = Math.Pow(Math.Pow(x2 - x3, 2) + Math.Pow(y2 - y3, 2), 0.5);
                        double c = Math.Pow(Math.Pow(x3 - x1, 2) + Math.Pow(y3 - y1, 2), 0.5);

                        double p = (a + b + c) / 2;

                        double preS = p * (p - a) * (p - b) * (p - c);

                        double s = Math.Sqrt(preS);

                        Console.WriteLine("Площадь треугольника = {0}\n\nНазад: B\nВыход: X\n", (double)Math.Round(s, 2));
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
                        goto m2;
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

                        Console.WriteLine("Задание 13. Найти радиус окружности по длине\n");

                        Console.Write("Введите длину окружности l = ");
                        double l = double.Parse(Console.ReadLine());

                        double r = l / (2 * Math.PI);

                        Console.WriteLine("Радиус окружности = {0}\n\nНазад: B\nВыход: X\n", (double)Math.Round(r, 2));
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
                        goto m2;
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

                        Console.WriteLine("Задание 14. Найти радиус окружности по площади\n");

                        Console.Write("Введите площадь окружности s = ");
                        double s = double.Parse(Console.ReadLine());

                        double preR = s / Math.PI;

                        double r = Math.Sqrt(preR);

                        Console.WriteLine("Радиус окружности = {0}\n\nНазад: B\nВыход: X\n", (double)Math.Round(r, 2));
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
                        goto m2;
                    }
                    if (keyback.Key == ConsoleKey.X)
                    {
                        Environment.Exit(0);
                    }
                }

                if (key.Key == ConsoleKey.D9)
                {
                    Console.Clear();
                    goto m1;
                }
            }
        }
    }
}