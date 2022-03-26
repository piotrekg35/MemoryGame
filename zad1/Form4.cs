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
    public partial class Form4 : Form

    {
        int czas = 0;
        int t1;
        int t2 ;
        string poziom;
        int liczba_kart;
        List<PictureBox> list;
        List<Image> obrazki;
        bool odkryte = true;
        public Form4(int time1,int time2,string str)
        {
            InitializeComponent();
            t1 = time1;
            t2 = time2;
            poziom = str;
            numericUpDown1.Value = t2;
            label1.Text = "00:00";
            if (poziom == "Łatwy") liczba_kart = 12;
            else if (poziom == "Średni") liczba_kart = 24;
            else liczba_kart = 48;
            list = new List<PictureBox>();
            for (int i = 0; i < liczba_kart; i++)
            {
                list.Add(new PictureBox());
                list[i].Image = pictureBox1.Image;
                list[i].Size = new Size(90,90);
                list[i].Visible = true;
                this.Controls.Add(list[i]);
            }
            int x=0, y=0, x0=0, y0=0, p = 0;
            if (poziom == "Łatwy") { x = 3; y = 4; x0 = 126; y0 = 262; }
            else if(poziom =="Średni") { x = 4; y = 6; x0 = 126; y0 = 126; }
            else { x = 6; y = 8; x0 = 30; y0 = 30; }
            for (int i = 0; i < x; i++)
                for(int j = 0; j < y; j++)
                    list[p++].Location = new Point(y0+j*96, x0 + i * 96);

            string directory = @"C:\Users\piotr\OneDrive\Pulpit\cs\lab3\zad1\zad1\obrazki";
            obrazki = new List<Image>();
            foreach (string myFile in Directory.GetFiles(directory, "*.png", SearchOption.AllDirectories))
            {
                obrazki.Add(Image.FromFile(myFile));
            }
            List<Image> obrazki_do_oddania = new List<Image>();
            for (int i = 0; i < liczba_kart / 2; i++) { obrazki_do_oddania.Add(obrazki[i+1]); obrazki_do_oddania.Add(obrazki[i+1]); }
            var random = new Random();
            int ran_num = random.Next();
            foreach (PictureBox pb in list)
            {
                pb.Image = obrazki_do_oddania[(ran_num % obrazki_do_oddania.Count)];
                pb.BackgroundImage = obrazki_do_oddania[(ran_num % obrazki_do_oddania.Count)];
                obrazki_do_oddania.RemoveAt(ran_num % obrazki_do_oddania.Count);
                ran_num = random.Next();

            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            t2 = Convert.ToInt32(numericUpDown1.Value);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            czas++;
            if (czas == t1) { foreach (PictureBox pb in list) pb.Image = obrazki[0]; odkryte = false; }
            double m = czas / 60;
            int min = Convert.ToInt32(Math.Floor(m));
            if (min < 10 && (czas - min * 60)<10) label1.Text = "0" + min + ":0" + (czas - min * 60);
            else if (min < 10 && (czas - min * 60) >= 10) label1.Text = "0" + min + ":" + (czas - min * 60);
            else if (min >= 10 && (czas - min * 60) < 10) label1.Text = min + ":0" + (czas - min * 60);
            else label1.Text =  min + ":" + (czas - min * 60);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(button1.Text=="Stop")
            {
                timer1.Stop();
                button1.Text = "Start";
            }
            else
            {
                timer1.Start();
                button1.Text = "Stop";
            }
            
        }
    }
}
