using System;
using ClassLibrary11;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProgram
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

            // Проверка задания по варианту
            M2[0] = 4;
            M2[1] = 0;
            M2[2] = 5;
            M2[3] = 0;
            M2[4] = 45;
            M2[5] = 987;
            M2[6] = 0;
            M2[7] = 45;
            M2[8] = 77;
            M2[9] = 0;

            Console.WriteLine("Исходный массив");
            M2.Print();
            //M2.variant(M2);
            Console.WriteLine("Измененный массив");
            M2.Print();
        }
    }
}

