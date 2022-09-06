using System;
using System.Windows.Forms;
using DinamicalLibrary12;

namespace LR12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Создание метода класса
        Class1 file = new Class1();

        // Объявление переменной, хранящая путь к файлн
        string path = "";

        // Объявление переменной, необходимой для чередования дейсвия (вкл/выкл панели инструментов)
        int a = -1;

        // Создать новый файл
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = "Последнее действие: Создать новый файл";

            if (richTextBox1.Text != "")
            {
                saveFileDialog1.ShowDialog();
                path = saveFileDialog1.FileName;

                file.SaveFile(path + ".txt", richTextBox1.Text);

                richTextBox1.Text = "";

                this.Text = "New file create";
            }
        }

        // Метод открытия файла
        private void toolStripButton6_Click(object sender, System.EventArgs e)
        {
            toolStripStatusLabel3.Text = "Последнее действие: Открытие файла";

            openFileDialog1.FileName = String.Empty;

            try
            {
                openFileDialog1.ShowDialog();

                file.OpenFile(openFileDialog1.FileName);
                richTextBox1.Text = file.Text;
                file = new Class1(richTextBox1.Text, openFileDialog1.FileName);
                path = file.Path;
                this.Text = path;
            }
            catch
            {
                MessageBox.Show("Ошибка доступа к файлу!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        // Отчистка файла
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = "Последнее действие: Отчистка файла";

            if (richTextBox1.Text != "") { richTextBox1.Text = ""; }
        }

        // Печать
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = "Последнее действие: Печать файла";

            bool chekedPrinter = file.PrintFile(richTextBox1.Font, path);

            if (!chekedPrinter) { DialogResult d = MessageBox.Show("Принтер не подключен!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        // Сохранить
        private void toolStripButton3_Click(object sender, System.EventArgs e)
        {
            toolStripStatusLabel3.Text = "Последнее действие: Сохранить";

            file.SaveFile(path, richTextBox1.Text);
        }

        // Сохранить как
        private void toolStripButton2_Click(object sender, System.EventArgs e)
        {
            toolStripStatusLabel3.Text = "Последнее действие: Сохранить как";
            
            saveFileDialog1.ShowDialog();
            path = saveFileDialog1.FileName;

            file.SaveFile(path + ".txt", richTextBox1.Text);

            this.Text = path;
        }

        // Метод закрытия формы
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Закрытие формы
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (richTextBox1.Text != "")
            {
                if (path == "")
                {
                    DialogResult d = MessageBox.Show("Сохранить ли список?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (d == DialogResult.Yes)
                    {
                        saveFileDialog1.ShowDialog();
                        path = saveFileDialog1.FileName;

                        file.SaveFile(path + ".txt", richTextBox1.Text);

                        this.Text = path;
                    }
                }
            }
        }        

        // Кол-во знаков, строк
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Число знаков: " + richTextBox1.TextLength.ToString();
            toolStripStatusLabel2.Text = "Число строк: " + richTextBox1.Lines.Length.ToString();
        }

        // Открыть (меню)
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.toolStripButton6_Click(sender, e);
        }

        // Сохранить (меню)
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.toolStripButton3_Click(sender, e);
        }

        // Сохранить как (меню)
        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.toolStripButton2_Click(sender, e);
        }

        // Скрыть / показать панель инсрументов
        private void панельИнструментовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            a *= -1;
            if (a * -1 == -1) toolStrip1.Visible = false;
            else toolStrip1.Visible = true;
        }

        // Вызов окна настройки шрифта
        private void параметрыШрифтаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // установка шрифта
            richTextBox1.Font = fontDialog1.Font;
            // установка цвета шрифта
            richTextBox1.ForeColor = fontDialog1.Color;
        }

        // О программе
        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 form2 = new AboutBox1();
            form2.ShowDialog();
        }

        // Поиск файла в каталоге
        private void поискToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(file);
            form3.ShowDialog();
            richTextBox1.Text = form3.GetText;
        }

        // Метод по варианту
        private void button1_Click(object sender, EventArgs e)
        {
            bool sort;
            if (radioButton1.Checked) sort = true;
            else sort = false;
            richTextBox1.Text = file.Variant((textBox1.Text).ToString(), sort);
        }
    }
}