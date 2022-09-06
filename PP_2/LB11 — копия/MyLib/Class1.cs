using System;

//using System.Windows.Forms;

namespace WinFormsApp1
{

    public class Arr
    {
        public int[] x;
        public int size;
        private Random rnd = new Random();

        /// <summary>
        /// Конструктор
        /// </summary>

        public Arr()
        {
            size = 0;
            x = null;
        }

        /// <summary>
        /// Конструктор класса с одним параметром размера массива
        /// </summary>
        /// <param name="n"> Размер массива </param>

        public Arr(int n)
        {
            x = new int[n];
            size = n;
        }

        /// <summary>
        /// Конструктор с массивом
        /// </summary>
        /// <param name="a">Выступает в качестве массива</param>

        public Arr(int[] a)
        {
            if (a == null) throw new Exception("\nРазмер массива равен 0\n");
            else
            {
                size = a.Length;
                x = new int[size];
                for (int i = 0; i < size; i++)
                {
                    x[i] = a[i];
                }
            }
        }

        /// <summary>
        /// Конструктор с объектом
        /// </summary>
        /// <param name="A">Объект</param>

        public Arr(Arr A)
        {
            if (A.x == null)
            {
                throw new Exception("\n0\n");
            }
            else
            {
                size = A.size;
                x = new int[size];
                for (int i = 0; i < size; i++)
                {
                    this.x[i] = A.x[i];
                }
            }
        }

        /// <summary>
        /// Узнать размер массива
        /// </summary>

        public int Size
        {
            get
            {
                return size;
            }
        }

        /// <summary>
        /// Метод заполнения массива случайными числами
        /// </summary>

        public void RndInput()
        {
            for (int i = 0; i < size; i++)
            {
                x[i] = rnd.Next(-100, 101);
            }
        }

        /// <summary>
        /// Перегрузка рандомайзера
        /// </summary>
        /// <param name="n1">Предел</param>

        public void RndInput(int n1)
        {
            for (int i = 0; i < size; i++)
            {
                x[i] = rnd.Next(n1 + 1);
            }
        }

        /// <summary>
        /// Перегруза рандомайзера от n1
        /// </summary>
        /// <param name="n1">Нижний предел</param>
        /// <param name="n2">Верхний предел</param>

        public void RndInput(int n1, int n2)
        {
            for (int i = 0; i < size; i++)
            {
                x[i] = rnd.Next(n1, n2 + 1);
            }
        }

        /// <summary>
        /// Преобразование массива в строку
        /// </summary>
        /// <returns>Вывод строки</returns>

        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < size; i++)
            {
                s += x[i] + " ";
            }
            return s;
        }

        /// <summary>
        /// Вывод в консоль
        /// </summary>

        public void Print()
        {
            Console.WriteLine(this.ToString());
            Console.WriteLine();
        }

        /// <summary>
        /// Гетеры и Сетеры массива X
        /// </summary>
        /// <param name="i">Индекс массива</param>
        /// <returns></returns>

        public int this[int i]
        {
            get
            {
                if (i >= 0 && i < size)
                {
                    return x[i];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                if (i >= 0 && i < size)
                    x[i] = value;
                else
                    new Exception("\nНе задано значение\n");
            }
        }

        /// <summary>
        /// Сумма
        /// </summary>
        /// <returns></returns>

        public int Summ()
        {
            int s = 0;
            for (int i = 0; i < size; i++)
            {
                s += this.x[i];
            }
            return 0;
        }

        /// <summary>
        /// Перегрузка операции массива
        /// </summary>
        /// <param name="A">Массив</param>
        /// <returns></returns>

        public static Arr operator ++(Arr A)
        {
            Arr temp = new Arr(A.size);
            for (int i = 0; i < temp.size; i++)
            {
                temp[i] = ++A[i];
            }
            return temp;
        }

        /// <summary>
        /// Перегрузка операции массива
        /// </summary>
        /// <param name="A">Массив</param>
        /// <returns></returns>

        public static Arr operator --(Arr A)
        {
            Arr temp = new Arr(A.size);
            for (int i = 0; i < temp.size; i++)
            {
                temp[i] = --A[i];
            }
            return temp;
        }

        /// <summary>
        /// Сложение массива
        /// </summary>
        /// <param name="X">1 массив</param>
        /// <param name="Y">2 массив</param>
        /// <returns>Сумма массивов</returns>

        public static Arr operator +(Arr X, Arr Y)
        {
            Arr temp;
            if (X.size > Y.size)
            {
                temp = new Arr(X.size);
            }
            else
            {
                temp = new Arr(Y.size);
            }
            for (int i = 0; i < temp.size; i++)
            {
                temp[i] = X[i] + Y[i];
            }
            return temp;
        }
        /// <summary>
        /// Разность массивов
        /// </summary>
        /// <param name="X">1 массив</param>
        /// <param name="Y">2 массив</param>
        /// <returns>Результат</returns>
        public static Arr operator -(Arr X, Arr Y)
        {
            Arr temp;
            if (X.size > Y.size)
            {
                temp = new Arr(X.size);
            }
            else
            {
                temp = new Arr(Y.size);
            }
            for (int i = 0; i < temp.size; i++)
            {
                temp[i] = X[i] + Y[i];
            }
            return temp;
        }
        /// <summary>
        /// Сложение каждого элемента с числом
        /// </summary>
        /// <param name="X">Массив</param>
        /// <param name="Y">Число</param>
        /// <returns>Результат суммы</returns>
        public static Arr operator +(Arr X, int Y)
        {
            Arr temp = new Arr(X.size);
            for (int i = 0; i < temp.size; i++)
            {
                temp[i] = X[i] + Y;
            }
            return temp;
        }
        /// <summary>
        /// Сложение числа с каждым элементом массива
        /// </summary>
        /// <param name="Y">Число</param>
        /// <param name="X">Массив</param>
        /// <returns>Результат сложения</returns>
        public static Arr operator +(int Y, Arr X)
        {
            Arr temp = new Arr(X.size);
            for (int i = 0; i < temp.size; i++)
            {
                temp[i] = Y + X[i];
            }
            return temp;
        }
        /// <summary>
        /// Вычитание каждого элемента массива числом
        /// </summary>
        /// <param name="X">Массив</param>
        /// <param name="Y">Число</param>
        /// <returns>Результат вычитания</returns>
        public static Arr operator -(Arr X, int Y)
        {
            Arr temp = new Arr(X.size);
            for (int i = 0; i < temp.size; i++)
            {
                temp[i] = X[i] - Y;
            }
            return temp;
        }
        /// <summary>
        /// Вычитание числа с каждым элементом массива
        /// </summary>
        /// <param name="Y">Число</param>
        /// <param name="X">Массив</param>
        /// <returns>Результат вычитания</returns>
        public static Arr operator -(int Y, Arr X)
        {
            Arr temp = new Arr(X.size);
            for (int i = 0; i < temp.size; i++)
            {
                temp[i] = Y - X[i];
            }
            return temp;
        }
        public void variant_Print()
        {
            int ans = this.x[0];
            int operation = 1;
            for (int i = 1; i < this.size; i++)
            {
                if (operation == 1)
                    ans += this.x[i];
                if (operation == -1)
                    ans -= this.x[i];
                operation *= -1;
            }
            Console.WriteLine(ans);
        }
        public string variant_Print_to_String()
        {
            int ans = this.x[0];
            int operation = 1;
            for (int i = 1; i < this.size; i++)
            {
                if (operation == 1)
                    ans += this.x[i];
                if (operation == -1)
                    ans -= this.x[i];
                operation *= -1;
            }
            return ans.ToString();
        }

        // Перегрузка для теста
        //public override bool Equals(object obj)
        //{
        //    if (obj == null || obj as Arr == null)
        //        return false;
        //    for (int i = 0; i < size; i++)
        //        if (this[i] != ((Arr)obj)[i])
        //            return false;

        //    return true;
        //}

    }
}


