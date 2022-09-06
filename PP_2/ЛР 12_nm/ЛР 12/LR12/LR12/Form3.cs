using System;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using DinamicalLibrary12;


namespace LR12
{
    public partial class Form3 : Form
    {
        public Form3(Class1 file)
        {
            InitializeComponent();
        }

        // Объявление переменной хранящей путь к файлу
        string path;
        // Объявление переменной хранящей текст из файла
        string text = "";
     
        // Создание объекта класса
        Class1 file = new Class1();

        // Метод возврата текста
        public string GetText
        {
            get
            {
                return text;
            }
        }

        // Метод выбора каталога
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            folderBrowserDialog1.ShowDialog();

            path = folderBrowserDialog1.SelectedPath;

            writing();            
        }
        
        private void writing()
        {
            listBox1.Items.Clear();

            int k = 0;

            string[] allfiles = Directory.GetFiles(path, "*" + textBox1.Text);

            List<Class1> myFiles = new List<Class1>();

            for (int i = 0; i < allfiles.Length; i++)
            {
                myFiles.Add(new Class1(allfiles[i]));
            }

            if (comboBox1.Text == "По имени файла")
            {
                Class1.SortByNames(ref myFiles);
            }
            else if (comboBox1.Text == "По количеству символов в файле")
            {
                Class1.SortBySymbols(ref myFiles);
            }
            else
            {
                Class1.SortByWords(ref myFiles);
            }

            for (int i = 0; i < myFiles.Count; i++)
            {
                listBox1.Items.Insert(k, myFiles[i].Path);
                k++;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            writing();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string name = listBox1.SelectedItem.ToString();
            file.OpenFile(name);
            text = file.Text;
            this.Close();
        }
    }
}
