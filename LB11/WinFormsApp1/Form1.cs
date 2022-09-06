using System;
using LB11;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;



namespace WinFormsApp1
{


    public partial class Form1 : Form
    {
        int n_row_1 = 2, n_row_2 = 2;
        Arr M1;
        Arr M2;


        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.RowCount = 1;
            dataGridView1.ColumnCount = n_row_1 = Convert.ToInt32(numericUpDown1.Value);

            dataGridView2.RowCount = 1;
            dataGridView2.ColumnCount = n_row_2 = Convert.ToInt32(numericUpDown2.Value);

            dataGridView3.RowCount = 1;
            dataGridView3.ColumnCount = 0;

            for (int i = 0; i < n_row_1; i++)
            {
                dataGridView1.Rows[0].Cells[i].Value = 0;
            }

            for (int i = 0; i < n_row_2; i++)
            {
                dataGridView2.Rows[0].Cells[i].Value = 0;
            }
            M1 = new Arr(n_row_1);
            M2 = new Arr(n_row_2);
        }

        public Form1()
        {
            InitializeComponent();
            EventArgs e = null;
            dataGridView1.ColumnCount = n_row_1;

            dataGridView2.ColumnCount = n_row_2;
            Form1_Load(n_row_2, e);
        }

        private void numericUpDown2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            M1 = new Arr(Convert.ToInt32(numericUpDown1.Value));
            n_row_1 = dataGridView1.ColumnCount = Convert.ToInt32(numericUpDown1.Value);
            M1.Print(dataGridView1);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            M2 = new Arr(Convert.ToInt32(numericUpDown2.Value));
            n_row_2 = dataGridView2.ColumnCount = Convert.ToInt32(numericUpDown2.Value);
            M2.Print(dataGridView2);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9')) return;
            if (e.KeyChar == '-' && ((TextBox)sender).Text.Length == 0)
            {
                if (((TextBox)sender).Text.IndexOf('-') != -1)
                {
                    e.Handled = true;
                }
                return;
            }
            if (e.KeyChar == (char)Keys.Back) return;
            e.Handled = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
            }
            if (radioButton2.Checked)
            {
                textBox1.Enabled = true;
                textBox2.Enabled = false;
            }
            if (radioButton3.Checked)
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
            }
            if (radioButton4.Checked)
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
            }
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton8.Checked)
            {
                textBox3.Enabled = false;
                textBox4.Enabled = false;
            }
            if (radioButton7.Checked)
            {
                textBox3.Enabled = true;
                textBox4.Enabled = false;
            }
            if (radioButton6.Checked)
            {
                textBox3.Enabled = true;
                textBox4.Enabled = true;
            }
            if (radioButton5.Checked)
            {
                textBox3.Enabled = false;
                textBox4.Enabled = false;
            }

        }

        private void dataGridView1_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            if (dataGridView1.ColumnCount > 10)
            {
                dataGridView1.Height = 40;
            }
            if (dataGridView1.ColumnCount <= 10)
            {
                dataGridView1.Height = 20;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                M1.RndInput();
                M1.Print(dataGridView1);
            }
            if (radioButton2.Checked)
            {
                M1.RndInput(0, int.Parse(textBox1.Text));
                M1.Print(dataGridView1);
            }
            if (radioButton3.Checked)
            {
                M1.RndInput(int.Parse(textBox1.Text), int.Parse(textBox2.Text));
                M1.Print(dataGridView1);
            }
            if (radioButton4.Checked)
            {
                DialogResult d = MessageBox.Show("Загрузить файл?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (d == DialogResult.Yes)
                {
                    openFileDialog1.ShowDialog();
                    StreamReader sr = new StreamReader(openFileDialog1.FileName, Encoding.GetEncoding(1251));
                    string s = "";
                    string[] textMass;
                    s = sr.ReadLine();

                    textMass = s.Split(' ');

                    n_row_1 = textMass.Length;

                    dataGridView1.ColumnCount = n_row_1;

                    M1 = new Arr(n_row_1);

                    for (int i = 0; i < n_row_1; i++)
                    {
                        M1[i] = int.Parse(textMass[i]);
                        dataGridView1.Rows[0].Cells[i].Value = textMass[i];

                    }

                    sr.Close();
                }
            }

            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;

            textBox5.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton8.Checked)
            {
                M2.RndInput();
                M2.Print(dataGridView2);
            }
            else if (radioButton7.Checked)
            {
                M2.RndInput(int.Parse(textBox4.Text));
                M2.Print(dataGridView2);
            }
            else if (radioButton6.Checked)
            {
                M2.RndInput(int.Parse(textBox4.Text), int.Parse(textBox3.Text));
                M2.Print(dataGridView2);
            }
            else
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    StreamReader sr = new StreamReader(openFileDialog1.FileName, Encoding.GetEncoding(1251));

                    string s = "";
                    string[] textMass;

                    s = sr.ReadLine();
                    textMass = s.Split(' ');
                    n_row_2 = textMass.Length;

                    dataGridView2.ColumnCount = n_row_2;

                    M2 = new Arr(n_row_2);

                    for (int i = 0; i < n_row_2; i++)
                    {
                        dataGridView2.Rows[0].Cells[i].Value = textMass[i];
                        M2[i] = int.Parse(textMass[i]);
                    }

                    sr.Close();
                }
            }

            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;

            textBox6.Enabled = true;
        }

        // Сумма массивов
        private void button11_Click(object sender, EventArgs e)
        {
            Arr M3 = M2 + M1;
            M3.Print(dataGridView3);
            label7.Text = "Сумма двух массивов";

        }

        // Разность массивов
        private void button12_Click(object sender, EventArgs e)
        {
            Arr M3 = M2 - M1;
            M3.Print(dataGridView3);
            label7.Text = "Разность двух массивов";

        }

        // Увеличить все элементы массива 1 на единицу
        private void button3_Click(object sender, EventArgs e)
        {
            M1++;
            M1.Print(dataGridView1);
        }

        // Уменьшенить все элементы массива 1 на единицу
        private void button4_Click(object sender, EventArgs e)
        {
            M1--;
            M1.Print(dataGridView1);
        }

        // Прибаить ко всем элементам массива 1 число Y
        private void button5_Click(object sender, EventArgs e)
        {
            M1 += int.Parse(textBox5.Text);
            M1.Print(dataGridView1);
        }

        // Вычесть из всех элементов массива 1 число Y
        private void button6_Click(object sender, EventArgs e)
        {
            M1 -= int.Parse(textBox5.Text);
            M1.Print(dataGridView1);
        }

        // Увеличить все элементы массива 2 на единицу
        private void button7_Click(object sender, EventArgs e)
        {
            M2++;
            M2.Print(dataGridView2);
        }

        // Уменьшенить все элементы массива 2 на единицу
        private void button8_Click(object sender, EventArgs e)
        {
            M2--;
            M2.Print(dataGridView2);
        }

        // Прибаить ко всем элементам массива 2 число Y
        private void button9_Click(object sender, EventArgs e)
        {
            M2 += int.Parse(textBox6.Text);
            M2.Print(dataGridView2);
        }

        // Вычесть из всех элементов массива 2 число Y
        private void button10_Click(object sender, EventArgs e)
        {
            M2 -= int.Parse(textBox6.Text);
            M2.Print(dataGridView2);
        }
        private void button13_Click(object sender, EventArgs e)
        {

            label7.Text = "Ответ Y = " + M1.variant_Print_to_DataGrid();
            label8.Text = "Ответ Y = " + M2.variant_Print_to_DataGrid();

        }
    }

}
