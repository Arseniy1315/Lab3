using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                textBox1.ReadOnly = false;
            else
                textBox1.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DvuVector vec1 = new DvuVector();
                DvuVector vec2 = new DvuVector();
                vec1.x = (double)numericUpDown1.Value;
                vec1.y = (double)numericUpDown2.Value;
                vec2.x = (double)numericUpDown3.Value;
                vec2.y = (double)numericUpDown4.Value;

                if (radioButton1.Checked)
                {
                    vec1 = vec1 + vec2;
                    label12.Text = $"( {vec1.x} ; {vec1.y} )";
                }
                else if (radioButton2.Checked)
                {
                    vec1 = vec1 - vec2;
                    label12.Text = $"( {vec1.x} ; {vec1.y} )";
                }
                if (radioButton3.Checked)
                {
                    if (vec1 == vec2)
                        label15.Text = "Равны";
                    else
                        label15.Text = "Не равны";
                }
                else if (radioButton4.Checked)
                {
                    if (vec1 != vec2)
                        label15.Text = "Не равны";
                    else
                        label15.Text = "Равны";
                }
                if (checkBox1.Checked)
                {
                    vec1 = vec1 * double.Parse(textBox1.Text);
                    vec2 = vec2 * double.Parse(textBox1.Text);
                    label13.Text = $"( {vec1.x} ; {vec1.y} ) , ( {vec2.x} ; {vec2.y} )";

                }
                else
                    label13.Text = "";

            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
            
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label12.Text = "";
            label13.Text = "";
            label15.Text = "";
        }
    }

    public class DvuVector
    {
        public double x;
        public double y;

        public static DvuVector operator +(DvuVector vec1, DvuVector vec2)
        {
            vec1.x = vec1.x + vec2.x;
            vec1.y = vec1.y + vec2.y;
            return vec1;
        }
        public static DvuVector operator -(DvuVector vec1, DvuVector vec2)
        {
            vec1.x = vec1.x - vec2.x;
            vec1.y = vec1.y - vec2.y;
            return vec1;
        }
        public static DvuVector operator *(DvuVector vec1, double scaliar)
        {
            vec1.x = Math.Round(vec1.x * scaliar, 2);
            vec1.y = Math.Round(vec1.y * scaliar, 2);
            return vec1;
        }
        public static bool operator ==(DvuVector vec1, DvuVector vec2)
        {
            if (vec1.x == vec2.x & vec2.y == vec1.y)
                return true;
            else
                return false;
        }
        public static bool operator !=(DvuVector vec1, DvuVector vec2)
        {
            if(vec1.x != vec2.x | vec2.y != vec1.y)
                return true;
            else
                return false;
        }
    }
}
