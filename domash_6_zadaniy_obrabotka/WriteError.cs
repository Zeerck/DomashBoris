using System;

namespace domash_6_zadaniy_obrabotka
{
    class WriteError
    {
        public static void Format()
        {
            Console.WriteLine("\nОшибка, неверный формат ввода. Могут использоваться только цифры от 0 до 9.\n\nНажмите любую клавишу чтобы вернуться в меню");

            Console.ReadKey();
        }

        public static void Arithmetic()
        {
            Console.WriteLine("\nОшибка при расчёте.\n\nНажмите любую клавишу чтобы вернуться в меню");

            Console.ReadKey();
        }

        public static void Zero()
        {
            Console.WriteLine("\nОшибка, делить на 0 нельзя.\n\nНажмите любую клавишу чтобы вернуться в меню");

            Console.ReadKey();
        }

        public static void OverFlow()
        {
            Console.WriteLine("\nОшибка, результат или вводимые данные находятся за пределами диапазона типа данных.\n\nНажмите любую клавишу чтобы вернуться в меню", Int32.MaxValue);

            Console.ReadKey();
        }
    }
}
