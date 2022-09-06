using System;
using LB11;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LB11
{
    class Program
    {
        static void Main(string[] args)
        {
            Arr M1 = new Arr(5);
            Arr M2 = new Arr(10);

            M1.Print();
            M2.Print();

            // Заполнение массива случайными зачениями
            Console.WriteLine("Массивы заполняются случайными числами");
            M1.RndInput();
            M2.RndInput();

            M1.Print();
            M2.Print();

            M1.RndInput(100);
            M2.RndInput(20);

            M1.Print();
            M2.Print();

            M1.RndInput(0, 100);
            M2.RndInput(-50, 50);

            M1.Print();
            M2.Print();

            // Сумма элементов массмва
            Console.WriteLine("Сумма элементов массива");
            M1.Summ();
            M2.Summ();
            Console.WriteLine();

            // Операция ++
            Console.WriteLine("Операция ++");
            M1++;
            M2++;

            M1.Print();
            M2.Print();

            // Операция --
            Console.WriteLine("Операция --");
            M1--;
            M2--;

            M1.Print();
            M2.Print();

            // Операция сложения двух массивов
            Console.WriteLine("Операция сложения двух массивов");
            M2 = M1 + M2;
            M2.Print();

            // Операция разности двух массивов
            Console.WriteLine("Операция разности двух массивов");
            M2 = M1 - M2;
            M2.Print();

            // Операция прибавления элементам массива числа
            Console.WriteLine("Операция прибавления элементам массива числа");
            M1 = M1 + 5;
            M2 = M2 + 10;

            M1.Print();
            M2.Print();

            // Операция вычитания из элементов массива числа
            Console.WriteLine("Операция вычитания из элементов массива числа");
            M1 = M1 - 5;
            M2 = M2 - 10;

            M1.Print();
            M2.Print();

            Console.WriteLine("Задание по варианту");

            M1.variant_Print();
            M2.variant_Print();
        }
    }
}

