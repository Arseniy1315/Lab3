using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace laba8
{
    public partial class Form1 : Form
    {





        public Form1()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, EventArgs e) // Задание №2
        {
            RandomMatrix(); // Метод заполнения матриц
        }

        public void RandomMatrix()
        {
            int n = Convert.ToInt32(textBox1.Text);
            int m = Convert.ToInt32(textBox2.Text);

            int n1 = Convert.ToInt32(textBox3.Text);
            int m1 = Convert.ToInt32(textBox4.Text);



            Random nums = new Random();
            // Матрица A
            if (n > 0 && n < 15 && m > 0 && m < 15)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        dataGridView1.RowCount = n;
                        dataGridView1.ColumnCount = m;
                        dataGridView1.Rows[i].Cells[j].Value = nums.Next(0, 50);

                    }
                }
            }
            else
            {
                MessageBox.Show("Значения не попадают в диапозон больше 0 и меньше 15");
            }
            //Матрица B
            if (n1 > 0 && n1 < 15 && m1 > 0 && m1 < 15)
            {
                for (int i = 0; i < n1; i++)
                {
                    for (int j = 0; j < m1; j++)
                    {
                        dataGridView2.RowCount = n1;
                        dataGridView2.ColumnCount = m1;
                        dataGridView2.Rows[i].Cells[j].Value = nums.Next(0, 50);

                    }
                }
            }
            else
            {
                MessageBox.Show("Значения не попадают в диапозон больше 0 и меньше 15");
            }

            // Пустая матрица дял перемножения

            for (int i = 0; i < n; i++)
            { 
                for (int j = 0; j < m; j++)
                {
                    dataGridView3.RowCount = dataGridView1.RowCount;
                    dataGridView3.ColumnCount = dataGridView2.ColumnCount;

                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MatrixMultiplication();
        }

        public void MatrixMultiplication() // Метод перемножения матриц
        {


            if (dataGridView1.ColumnCount != dataGridView2.RowCount)
            {
                throw new Exception("Умножение не возможно! Количество столбцов первой матрицы не равно количеству строк второй матрицы.");
            }
            else
            {
                
                
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView2.ColumnCount; j++)
                    {
                        double summa = 0;
                        for (int k = 0; k < dataGridView1.ColumnCount; k++)
                        {
                            summa += Convert.ToInt32(dataGridView1.Rows[i].Cells[k].Value) * Convert.ToInt32(dataGridView2.Rows[k].Cells[j].Value);

                        }
                        dataGridView3.Rows[i].Cells[j].Value = summa;
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)// Задание №1
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            string Text = openFileDialog1.FileName;
            textBox7.Text = Text;

            Main(Text);
        }

        public void Main(string Text)
        {
            char[] vowel_letters = "АЕЁИОУЫЭЮЯAEIOUY".ToLower().ToCharArray();
            char[] consonants_letters = "БВГДЖЗЙКЛМНПРСТФХЦЧШЩЬЪBCDFGHJKLMNPQRSTVWXYZ".ToLower().ToCharArray();

            StreamReader file = new StreamReader(Text);

            char[] sw = file.ReadToEnd().ToCharArray();

            int vowel_count = GetCount(sw, vowel_letters);
            int consonants_count = GetCount(sw, consonants_letters);

            textBox5.Text = vowel_count.ToString();
            textBox6.Text = consonants_count.ToString();
        }
        static int GetCount(char[] sw, char[] arg)
        {
            int Count = 0;
            foreach (char ch in sw)
            {
                foreach (char cha in arg)
                {
                    if (ch == cha)
                    {
                        Count++;
                    }
                }

            }
            return Count;



        }

        private void button4_Click(object sender, EventArgs e)//Задание №3
        {
            Random temp = new Random();

            int[,] temperature = new int[12, 30];

            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    temperature[i, j] = temp.Next(-35, 35);
                    richTextBox1.Text += $"Месяц: {i+1}, день {j+1}, температура {temperature[i,j]}"  + "\n";
                }
            }
            TempMounth(temperature);
            
        }
        public  void TempMounth(int[,] temperature)// Вычисление среднего значения температуры за месяц
        {
            double [] middletemp = new double [12];

            
            for (int mounth = 0; mounth < 12; mounth++)
            {
                int days = 0;
                for (int day = 0; day < 30; day++)
                {
                    days += temperature[mounth, day];
                    
                }
                middletemp[mounth] = Math.Round((double)days/30, 1) ;
                richTextBox2.Text += $"Месяц: {mounth+1}, температура {middletemp[mounth]}\n";
            }
        }

        private void button5_Click(object sender, EventArgs e)// Задание №4
        {
            OpenFileDialog openfile4 = new OpenFileDialog();
            if (openfile4.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            string open_file = openfile4.FileName;

            textBox8.Text = open_file;

        }
        public void Main2(string open_file)
        {
            StreamReader file1 = new StreamReader(open_file);

            List<string> list = new List<string>();

            list.Add(open_file);

            List<string> vowels = new List<string>() { "АЕЁИОУЫЭЮЯ" };
            List<string> consonans = new List<string>() { "БВГДЖЗЙКЛМНПРСТФХЦЧШЩЬЪ" };
        }
    }
}
