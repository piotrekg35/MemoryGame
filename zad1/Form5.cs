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

namespace zad1
{
    public partial class Form5 : Form
    {
        string imie;
        int wynik;
        public Form5(string i,int w)
        {
            InitializeComponent();
            imie = i;
            wynik = w;
            label1.Text = "Twój wynik to: " + wynik;
            label2.Text = "Ranikng:";
            StreamWriter file = new StreamWriter(@"C:\Users\piotr\OneDrive\Pulpit\cs\lab3\zad1\zad1\ranking.txt", append: true);
            file.WriteLine(w+","+i);
            file.Close();
            string text = System.IO.File.ReadAllText(@"C:\Users\piotr\OneDrive\Pulpit\cs\lab3\zad1\zad1\ranking.txt");
            string[] lines = text.Split('\n');
            List<string> lines2 = new List<string>();
            foreach(string line in lines)lines2.Add(line);
            lines2.Sort();
            lines2.Reverse();
            int j = 0;
            while(j<lines2.Count && j<5) listView1.Items.Add(lines2[j++]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
