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
        public int czas = 0;
        public int czas_odkrycia_niepoprawnych = 0;
        public int czas_odkrycia_poprawnych = 0;
        public int t1;
        public int t2 ;
        public string poziom;
        public string imie;
        public int liczba_kart;
        public List<PictureBox> list;
        public List<Image> obrazki;
        public int karty_odkryte;
        public PictureBox karta1 =new PictureBox();
        public PictureBox karta2 = new PictureBox();
        public int liczba_pomyłek = 0;
        public int wynik;
        public bool czas_zastopowany = false;
        public Form4(int time1,int time2,string str,string im)
        {
            InitializeComponent();
            t1 = time1;
            t2 = time2;
            poziom = str;
            imie= im;
            numericUpDown1.Value = t2;
            label1.Text = "00:00";
            Karty k = new Karty(this);
            liczba_kart=k.getLiczbaKart();
            list = new List<PictureBox>();
            list = k.getKarty();
            foreach(var pb in list)
                this.Controls.Add(pb);
            obrazki = k.getObrazki();
            karty_odkryte = liczba_kart;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            t2 = Convert.ToInt32(numericUpDown1.Value);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            czas++;
            if (czas == t1) 
            {
                foreach (PictureBox pb in list) pb.Image = obrazki[0];
                karty_odkryte = 0; 
            }

            TimeHandler.updateTimer(this);
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
                ScoreCounter.countScore(this);
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
