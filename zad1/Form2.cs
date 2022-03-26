using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zad1
{
    public partial class Form2 : Form
    {
        Form1 okno1;
        Form3 okno3;
        Form4 okno4;
        int t1=10;
        int t2=2;
        string poziom="Łatwy";
        string imie;
        public Form2(Form1 f1)
        {
            InitializeComponent();
            okno1 = f1;
            imie = f1.textBox1.Text;
            label1.Text = "Witaj " + imie;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            okno4 = new Form4(t1,t2,poziom, imie);
            okno4.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            okno3 = new Form3();
            okno3.ShowDialog();
            t1 = Int32.Parse(okno3.numericUpDown1.Value.ToString());
            t2 = Int32.Parse(okno3.numericUpDown2.Value.ToString());
            poziom = okno3.comboBox1.Text;
        }
    }
}
