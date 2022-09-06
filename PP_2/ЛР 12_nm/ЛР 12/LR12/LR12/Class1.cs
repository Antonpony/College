using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Drawing.Printing;

namespace DinamicalLibrary12
{
    // поиска файлов в указанном каталоге; ???

    // сортировку списка найденных файлов разными способами: по количеству символов в файле, по количеству слов в файле; +

    interface IComparable
    {
        int CompareTo(object obj);
    }

    public class Class1 /*: IComparable*/
    {
        private string text; // Текст 
        public string path; // Путь 
        char[] charSeparators = new char[] { ' ' };
        StreamReader streamToPrint; // Поток для принтера
        Font printFont; // Параметры шрифта для печати файла

        public Class1()
        {
            text = "";
            path = "";
        }

        public Class1(string _path)
        {
            text = "";
            path = _path;
        }

        public Class1(string _text, string _path)
        {
            text = _text;
            path = _path;
        }

        // Доступ к тексту
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
            }
        }

        // Доступ к пути
        public string Path
        {
            get
            {
                return path;
            }
            set
            {
                path = value;
            }
        }
        
        /// <summary>
        /// Метод открытия файла
        /// </summary>
        /// <param name="filename">Имя файла</param>
        /// <returns> Возврачает текст файла</returns>
        public string OpenFile(string filename)
        {
            StreamReader sr = new StreamReader(filename/*, System.Text.Encoding.GetEncoding(1251)*/);
            // создание нового входного потока, установка кодировки
            this.text = sr.ReadToEnd();
            // закрытие входного потока
            sr.Close();
            return text;
        }

        /// <summary>
        /// Метод сохранения файла
        /// </summary>
        /// <param name="fileName">Имя файла</param>
        /// <param name="text">Текст файла</param>
        public void SaveFile(string fileName, string text)
        {
            StreamWriter sw = new StreamWriter(fileName, false, System.Text.Encoding.GetEncoding(1251));
            sw.Write(text);
            sw.Close();
        }

        /// <summary>
        /// Метод печати одной страницы
        /// </summary>
        /// <param name="pF">Стиль шрифта</param>
        /// <param name="fileName">Имя файла</param>
        /// <returns>Возвращает true или false</returns>
        public bool PrintFile(Font pF, string fileName)
        {
            try
            {
                streamToPrint = new System.IO.StreamReader(fileName, System.Text.Encoding.GetEncoding(1251));
                try
                {
                    printFont = pF;
                    PrintDocument pd = new PrintDocument();
                    pd.PrintPage += new PrintPageEventHandler
                       (this.pd_PrintPage);
                    pd.Print();
                    return true;
                }
                finally
                {
                    streamToPrint.Close();
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Метод нескольких страниц
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ev"></param>
        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            float linesPerPage = 0;
            float yPos = 0;
            int count = 0;
            float leftMargin = ev.MarginBounds.Left;
            float topMargin = ev.MarginBounds.Top;
            string line = null;

            // Чтобы вычислить количество строк на странице
            linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics);

            // Печатаем каждую строку файла
            while (count < linesPerPage && ((line = streamToPrint.ReadLine()) != null))
            {
                yPos = topMargin + (count * printFont.GetHeight(ev.Graphics));
                ev.Graphics.DrawString(line, printFont, Brushes.Black,
                leftMargin, yPos, new StringFormat());
                count++;
            }

            // если строки не закончились, распечатаем еще одну страницу
            if (line != null)
                ev.HasMorePages = true;
            else
                ev.HasMorePages = false;
        }

        /// <summary>
        /// Метод подсчета количества слов 
        /// </summary>
        /// <param name="text">Текст файла</param>
        /// <returns>Количество слов в файле</returns>
        public int CountWrods()
        {
            int count;

            string[] textMass;

            textMass = text.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);

            count = textMass.Length;

            return count;
        }

        public override int GetHashCode()
        {
            return text.GetHashCode();
        }

        /// <summary>
        /// Метод сравнения двух файлов на равность
        /// </summary>
        /// <param name="obj">Второй объект для сравнения</param>
        /// <returns>Возвращает true или false</returns>
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Class1))
                return false;
            if (this.text.Length == ((Class1)obj).text.Length)
                return true;
            else return false;
        }

        /// <summary>
        /// Метод перегрузки операций
        /// </summary>
        /// <param name="obj">Второй объект</param>
        /// <returns>Возвращает -1 / 0 / 1</returns>
        public int CompareTo(object obj)
        {
            if (obj == null || !(obj is Class1))
                throw new ArgumentException("Это не объект класса Class1");
            if (this.Text.Length > ((Class1)obj).Text.Length) return 1;
            if (this.Text.Length < ((Class1)obj).Text.Length) return -1;
            return 0;
        }

        public static bool operator ==(Class1 obj1, Class1 obj2)
        {
            return obj1.Equals(obj2);
        }
        public static bool operator !=(Class1 obj1, Class1 obj2)
        {
            return !obj1.Equals(obj2);
        }

        public static bool operator >(Class1 obj1, Class1 obj2)
        {
            return obj1.CompareTo(obj2) > 0;
        }

        public static bool operator <(Class1 obj1, Class1 obj2)
        {
            return obj1.CompareTo(obj2) < 0;
        }

        public static bool operator >=(Class1 obj1, Class1 obj2)
        {
            return obj1.CompareTo(obj2) >= 0;
        }

        public static bool operator <=(Class1 obj1, Class1 obj2)
        {
            return obj1.CompareTo(obj2) <= 0;
        }        

        /// <summary>
        /// Метод по варианту 3
        /// </summary>
        public string Variant(string lette, bool sort)
        {
            string words = "";
            string[] textMass;
            textMass = text.Split(' ');

            string[] textMassFilter = new string[0];

            for (int i = 0; i < textMass.Length; i++)
            {
                if (textMass[i].ToUpper().StartsWith(lette) || textMass[i].ToLower().StartsWith(lette))
                {
                    Array.Resize(ref textMassFilter, textMassFilter.Length + 1);

                    textMassFilter[textMassFilter.Length - 1] = textMass[i];
                }
            }

            if (sort == true) { Array.Sort(textMassFilter); }

            for (int i = 0; i < textMassFilter.Length; i++)
            {
                words += textMassFilter[i] + " ";
            }
            return words;
        }

        public static void CheckPairs(string str, char ch1, char ch2)
        {
            Stack<char> st = new Stack<char>();
            string clear = "";
            foreach (char i in str)
            {

                if (i == ch1 || i == ch2)
                    clear += i;
            }
            if (clear.StartsWith(Convert.ToString(ch2)) || clear.EndsWith(Convert.ToString(ch1)))
            {
                Console.WriteLine("Найдены ошибки");
                return;
            }
            if (clear.Length % 2 != 0)
            {
                Console.WriteLine("Найдены ошибки");
                return;
            }
            if (clear.Length == 0)
            {
                Console.WriteLine("Все в порядке");
                return;
            }
            foreach (char i in clear)
            {
                if (i == ch1)
                {
                    st.Push(i);
                }
                else
                {
                    char top = st.Pop();
                    if (top == ch1 && i != ch2)
                    {
                        Console.WriteLine("Найдены ошибки");
                        return;
                    }
                }
            }
            if (st.Count == 0)
                Console.WriteLine("Все в порядке");
            else
                Console.WriteLine("Найдены ошибки");
        }
    


    /// <summary>
    /// Сортируем указанный список по их именам
    /// </summary>
    /// <param name="files">Список файлов</param>
    public static void SortByNames(ref List<Class1> files)
        {
            files.Sort(new MyFileNameComparer());
        }

        /// <summary>
        /// Сортируем указанный список по количеству слов
        /// </summary>
        /// <param name="files">Список файлов</param>
        public static void SortBySymbols(ref List<Class1> files)
        {
            for (int i = 0; i < files.Count; i++)
            {
                files[i].OpenFile(files[i].Path);
            }

            files.Sort(new MyFileSymbolsComparer());
        }

        /// <summary>
        /// Сортируем указанный список по количеству слов
        /// </summary>
        /// <param name="files">Список файлов</param>
        public static void SortByWords(ref List<Class1> files)
        {
            for (int i = 0; i < files.Count; i++)
            {
                files[i].OpenFile(files[i].Path);
            }

            files.Sort(new MyFileWordsCompare());
        }        
    }

    class MyFileNameComparer : IComparer<Class1>
    {
        public int Compare(Class1 obj1, Class1 obj2)
        {
            return (obj1.path).CompareTo(obj2.path);
        }
    }


    class MyFileSymbolsComparer : IComparer<Class1>
    {
        public int Compare(Class1 obj1, Class1 obj2)
        {
            if (obj1.Text.Length > obj2.Text.Length) return 1;
            if (obj1.Text.Length < obj2.Text.Length) return -1;
            return 0;
        }
    }

    class MyFileWordsCompare : IComparer<Class1>
    {
        public int Compare(Class1 obj1, Class1 obj2)
        {
            if (obj1.CountWrods() > obj2.CountWrods()) return 1;
            if (obj1.CountWrods() < obj2.CountWrods()) return -1;
            return 0;
        }
    }
}