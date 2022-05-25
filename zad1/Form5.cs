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
            List<string> top = new List<string>();
            top = LeaderBoard.getTopFromFile(@"C:\Users\piotr\OneDrive\Pulpit\cs\lab3\zad1\zad1\ranking.txt");
            foreach(var p in top) listView1.Items.Add(p);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
