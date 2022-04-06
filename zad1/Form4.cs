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
        int czas_odkrycia_niepoprawnych = 0;
        int czas_odkrycia_poprawnych = 0;
        int t1;
        int t2 ;
        string poziom;
        string imie;
        int liczba_kart;
        List<PictureBox> list;
        List<Image> obrazki;
        int karty_odkryte;
        PictureBox karta1=new PictureBox();
        PictureBox karta2 = new PictureBox();
        int liczba_pomyłek = 0;
        int wynik;
        bool czas_zastopowany = false;
        public Form4(int time1,int time2,string str,string im)
        {
            InitializeComponent();
            t1 = time1;
            t2 = time2;
            poziom = str;
            imie= im;
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
                if (poziom == "Łatwy") list[i].Size = new Size(180, 180);
                else if (poziom == "Średni") list[i].Size = new Size(110, 110);
                else list[i].Size = new Size(90, 90);
                list[i].Visible = true;
                list[i].SizeMode = PictureBoxSizeMode.StretchImage;

                this.Controls.Add(list[i]);
            }
            int x=0, y=0, x0=30, y0=30, p = 0,m=0;
            if (poziom == "Łatwy") { x = 3; y = 4; m = 192; }
            else if(poziom =="Średni") { x = 4; y = 6; m = 130; }
            else { x = 6; y = 8; m = 96; }
            for (int i = 0; i < x; i++)
                for(int j = 0; j < y; j++)
                    list[p++].Location = new Point(y0+j*m, x0 + i * m);

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
            karty_odkryte = liczba_kart;
            foreach (var pb in list)
            {
                pb.Click += (sender, e) => {
                    if (czas >= t1 && karty_odkryte == 0 && pb.Image == obrazki[0] && !czas_zastopowany)
                    {
                        pb.Image = pb.BackgroundImage;
                        karta1 = pb;
                        karty_odkryte++;
                    }
                    else if (czas >= t1 && karty_odkryte == 1 && pb.Image == obrazki[0] && !czas_zastopowany)
                    {
                        pb.Image = pb.BackgroundImage;
                        karta2 = pb;
                        karty_odkryte++;
                        if(karta1.BackgroundImage == karta2.BackgroundImage)
                        {
                            timer4.Enabled = true;
                            timer4.Start();
                        }
                        else
                        {
                            timer2.Enabled = true;
                            timer2.Start();
                        }

                    }
                };
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            t2 = Convert.ToInt32(numericUpDown1.Value);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            czas++;
            if (czas == t1) { foreach (PictureBox pb in list) pb.Image = obrazki[0]; karty_odkryte =0; }
            double m = czas / 60;
            int min = Convert.ToInt32(Math.Floor(m));
            if (min < 10 && (czas - min * 60)<10) label1.Text = "0" + min + ":0" + (czas - min * 60);
            else if (min < 10 && (czas - min * 60) >= 10) label1.Text = "0" + min + ":" + (czas - min * 60);
            else if (min >= 10 && (czas - min * 60) < 10) label1.Text = min + ":0" + (czas - min * 60);
            else label1.Text =  min + ":" + (czas - min * 60);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(czas_zastopowany == false && karty_odkryte==0)
            {
                timer1.Stop();
                button1.Text = "Start";
                czas_zastopowany = true;
            }
            else if (czas_zastopowany == true && karty_odkryte == 0)
            {
                timer1.Start();
                button1.Text = "Stop";
                czas_zastopowany=false;
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            czas_odkrycia_niepoprawnych++;
            if(czas_odkrycia_niepoprawnych == t2)
            {
                czas_odkrycia_niepoprawnych = 0;
                timer2.Enabled = false;
                karty_odkryte = 0;
                karta1.Image = obrazki[0];
                karta2.Image = obrazki[0];
                liczba_pomyłek++;
               
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if(liczba_kart == 0)
            {
                timer1.Stop();
                liczba_kart = -1;
                wynik = 2000 - czas - liczba_pomyłek * 100;
                if (wynik < 0) wynik = 0;
                Form5 okno5 = new Form5(imie, wynik);
                okno5.ShowDialog();
                this.Close();
               
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            czas_odkrycia_poprawnych++;
            if(czas_odkrycia_poprawnych==2)
            {
                czas_odkrycia_poprawnych=0;
                timer4.Enabled = false;
                karty_odkryte = 0;
                liczba_kart -= 2;
                karta1.Visible = false;
                karta2.Visible = false;
                list.Remove(karta1);
                list.Remove(karta2);
                this.Refresh();
            }
        }
    }
}
