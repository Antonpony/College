using System;

namespace ClassLibrary12
{
    public class Arr
    {
        private int[] a;
        private int size;
        private Random rnd = new Random();
        /// <summary>
        /// Конструктор класса по умолчанию
        /// </summary>
        public Arr()
        {
            size = 0;
            a = null;
        }
        /// <summary>
        /// Конструктор класса с одним параметром, размер массива
        /// </summary>
        /// <param name="n">Размер массива</param>
        public Arr(int n)
        {
            a = new int[n];
            size = n;
        }

        /// <summary>
        /// Еще один конструктор с инициализацией обычным массивом
        /// </summary>
        /// <param name="x">Массив целого типа</param>
        public Arr(int[] x)
        {
            if (x == null) throw new Exception("Ошибка");
            else
            {
                size = x.Length;
                a = new int[size];
                for (int i = 0; i < size; i++)
                {
                    a[i] = x[i];
                }
            }
        }

        /// <summary>
        /// Еще один конструктор с инициализацией объектом класса Arr
        /// </summary>
        /// <param name="A"></param>
        public Arr(Arr A)
        {
            if (A.a == null)
            {
                throw new Exception("Ошибка");
            }
            else
            {
                size = A.size;
                a = new int[size];
                for (int i = 0; i < size; i++)
                {
                    this.a[i] = A.a[i];
                }
            }
        }

        public int Size // Свойство возращает значение поля size (размер массива)
        {
            get
            {
                return size;
            }
        }

        /// <summary>
        /// Метод заполнения массива случайными числами в интервале -100 до 100
        /// </summary>
        public void RndInput()
        {
            for (int i = 0; i < size; i++)
            {
                a[i] = rnd.Next(-100, 101);
            }
        }

        /// <summary>
        /// Метод заполнения массива случайными числами в интервале от 0 до n1
        /// </summary>
        public void RndInput(int n1)
        {
            for (int i = 0; i < size; i++)
            {
                a[i] = rnd.Next(n1 + 1);
            }
        }

        /// <summary>
        /// Метод заполнения массива случайными числами в интервале от n1 до n2
        /// </summary>
        public void RndInput(int n1, int n2)
        {
            for (int i = 0; i < size; i++)
            {
                a[i] = rnd.Next(n1, n2 + 1);
            }
        }

        /// <summary>
        /// Перегрузка метода преобразования объекта Arr в строку
        /// </summary>
        /// <returns>Элементы массива через пробел в одну строку</returns>
        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < size; i++)
            {
                s += a[i] + " ";
            }

            return s;
        }

        /// <summary>
        /// Метод вывода массива класса Arr на консоль
        /// </summary>
        public void Print()
        {
            Console.WriteLine(this.ToString());
            Console.WriteLine();
        }

        /// <summary>
        /// Метод распечатки массива в поле надписи
        /// </summary>
        /// <param name="handel">handle - строка загаловка</param>
        /// <param name="lbl">lbl - поле надписи, куда печатать</param>
        public void Print(string handel, Label lbl)
        {
            lbl.Text = handel + " ";
            lbl.Text += this.ToString();
        }

        public void Print(DataGridView dgv)
        {

            dgv.RowCount = 1;
            dgv.ColumnCount = size;


            for (int i = 0; i < size; i++)
            {
                dgv.Rows[0].Cells[i].Value = a[i].ToString();
            }

        }

        /// <summary>
        /// Индексатор для доступа к элементу массива по его номеру
        /// </summary>
        /// <param name="i">Номер элемента</param>
        /// <returns></returns>
        public int this[int i]
        {
            get
            {
                if (i >= 0 && i < size)
                {
                    return a[i];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                if (i >= 0 && i < size)
                {
                    a[i] = value;
                }
                else throw new Exception("Ошибка размера");
            }
        }

        /// <summary>
        /// Метод вычисления суммы всех элементов
        /// </summary>
        /// <returns>Возвращает сумму элементов массива</returns>
        public int Summ()
        {
            int s = 0;

            for (int i = 0; i < size; i++)
            {
                s += this.a[i];
            }

            Console.WriteLine(s);

            return s;
        }

        /// <summary>
        /// Метод вычисления суммы элементов, кратных заданному числу
        /// </summary>
        /// <param name="number"></param>
        /// <returns>Возвращает сумму элементов, кратных указанному числу</returns>
        public int Summ(int number)
        {
            int s = 0;

            for (int i = 0; i < size; i++)
            {
                if (a[i] % number == 0) s += this.a[i];
            }

            return s;
        }

        public static Arr operator ++(Arr A) // Перегрузка операции ++
        {
            Arr temp = new Arr(A.size);
            for (int i = 0; i < temp.size; i++)
            {
                temp[i] = ++A[i];
            }
            return temp;
        }

        public static Arr operator --(Arr A) // Перегрузка операции --
        {
            Arr temp = new Arr(A.size);
            for (int i = 0; i < temp.size; i++)
            {
                temp[i] = --A[i];
            }
            return temp;
        }

        /// <summary>
        /// Перегрузка операции сложения двух объектов
        /// </summary>
        /// <param name="X">Первый массив</param>
        /// <param name="Y">Второй массив</param>
        /// <returns></returns>
        public static Arr operator +(Arr X, Arr Y)
        {
            Arr temp;
            if (X.size > Y.size)
            {
                temp = new Arr(X.Size);
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

        public static Arr operator -(Arr X, Arr Y)
        {
            Arr temp;
            if (X.size > Y.size)
            {
                temp = new Arr(X.Size);
            }
            else
            {
                temp = new Arr(Y.size);
            }

            for (int i = 0; i < temp.size; i++)
            {
                temp[i] = X[i] - Y[i];
            }

            return temp;
        }

        public static Arr operator +(Arr X, int y)
        {
            Arr temp = new Arr(X.size);
            for (int i = 0; i < temp.size; i++)
            {
                temp[i] = X[i] + y;
            }
            return temp;
        }

        public static Arr operator -(Arr X, int y)
        {
            Arr temp = new Arr(X.size);
            for (int i = 0; i < temp.size; i++)
            {
                temp[i] = X[i] - y;
            }
            return temp;
        }

        /// <summary>
        /// Задание по варианту 3
        /// </summary>
        /// <param name="a">Передаем массив в функцию</param>
        /// <returns>Возвращаем массив, к которому были применены изменения</returns>
        public bool variant(Arr a)
        {
            int arraySize = 0;
            int idFirstEl = 0;
            int firstEl = a[0];
            int[] arrayNullEl = new int[arraySize];
            int[] temp = new int[size];
            bool firstElBool = false;

            for (int i = 0; i < size; i++)
            {
                if (a[i] == 0)
                {
                    Array.Resize(ref arrayNullEl, arrayNullEl.Length + 1);
                    arrayNullEl[arraySize] = i;
                    arraySize++;
                }
                else if (a[i] != 0 && !firstElBool)
                {
                    firstElBool = true;
                    idFirstEl = i;
                }
            }


            if (arrayNullEl.Length > 2)
            {
                a[idFirstEl] = 0;

                for (int i = 0; i < arrayNullEl.Length; i++)
                {
                    a[arrayNullEl[i]] = firstEl;
                }

                return true;
            }
            else return false;
        }

        // Перегрузка для теста
        public override bool Equals(object obj)
        {
            if (obj == null || obj as Arr == null)
                return false;
            for (int i = 0; i < size; i++)
                if (this[i] != ((Arr)obj)[i])
                    return false;

            return true;
        }
    }
}
