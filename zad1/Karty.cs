using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace zad1
{
    public class Karty
    {
        string poziom;
        int liczba_kart;
        List<PictureBox> list;
        List<Image> obrazki;
        public Karty(Form4 okno)
        {
            poziom = okno.poziom;
            if (poziom == "Łatwy") liczba_kart = 12;
            else if (poziom == "Średni") liczba_kart = 24;
            else liczba_kart = 48;
            list = new List<PictureBox>();
            obrazki = new List<Image>();
            for (int i = 0; i < liczba_kart; i++)
            {
                list.Add(new PictureBox());
                if (poziom == "Łatwy") list[i].Size = new Size(180, 180);
                else if (poziom == "Średni") list[i].Size = new Size(110, 110);
                else list[i].Size = new Size(90, 90);
                list[i].Visible = true;
                list[i].SizeMode = PictureBoxSizeMode.StretchImage;
            }

            int x = 0, y = 0, x0 = 30, y0 = 30, p = 0, m = 0;
            if (poziom == "Łatwy") { x = 3; y = 4; m = 192; }
            else if (poziom == "Średni") { x = 4; y = 6; m = 130; }
            else { x = 6; y = 8; m = 96; }
            for (int i = 0; i < x; i++)
                for (int j = 0; j < y; j++)
                    list[p++].Location = new Point(y0 + j * m, x0 + i * m);

            getCardsImagesFromResources();


            List<Image> obrazki_do_oddania = new List<Image>();
            for (int i = 0; i < liczba_kart / 2; i++) { obrazki_do_oddania.Add(obrazki[i + 1]); obrazki_do_oddania.Add(obrazki[i + 1]); }
            var random = new Random();
            int ran_num = random.Next();
            foreach (PictureBox pb in list)
            {
                pb.Image = obrazki_do_oddania[(ran_num % obrazki_do_oddania.Count)];
                pb.BackgroundImage = obrazki_do_oddania[(ran_num % obrazki_do_oddania.Count)];
                obrazki_do_oddania.RemoveAt(ran_num % obrazki_do_oddania.Count);
                ran_num = random.Next();

            }
            foreach (var pb in list)
            {
                pb.Click += (sender, e) => {
                    if (okno.czas >= okno.t1 && okno.karty_odkryte == 0 && pb.Image == obrazki[0] && !okno.czas_zastopowany)
                    {
                        pb.Image = pb.BackgroundImage;
                        okno.karta1 = pb;
                        okno.karty_odkryte++;
                    }
                    else if (okno.czas >= okno.t1 && okno.karty_odkryte == 1 && pb.Image == obrazki[0] && !okno.czas_zastopowany)
                    {
                        pb.Image = pb.BackgroundImage;
                        okno.karta2 = pb;
                        okno.karty_odkryte++;
                        if (okno.karta1.BackgroundImage == okno.karta2.BackgroundImage)
                        {
                            okno.timer4.Enabled = true;
                            okno.timer4.Start();
                        }
                        else
                        {
                            okno.timer2.Enabled = true;
                            okno.timer2.Start();
                        }

                    }
                };
            }

        }
        public int getLiczbaKart() { return liczba_kart; }
        public List<PictureBox> getKarty() { return list; }
        public List<Image> getObrazki() { return obrazki; }
        private void getCardsImagesFromResources()
        {
            obrazki.Add(Properties.Resources._00);
            obrazki.Add(Properties.Resources._01);
            obrazki.Add(Properties.Resources._02);
            obrazki.Add(Properties.Resources._03);
            obrazki.Add(Properties.Resources._04);
            obrazki.Add(Properties.Resources._05);
            obrazki.Add(Properties.Resources._06);
            obrazki.Add(Properties.Resources._07);
            obrazki.Add(Properties.Resources._08);
            obrazki.Add(Properties.Resources._09);
            obrazki.Add(Properties.Resources._10);
            obrazki.Add(Properties.Resources._11);
            obrazki.Add(Properties.Resources._12);
            obrazki.Add(Properties.Resources._13);
            obrazki.Add(Properties.Resources._14);
            obrazki.Add(Properties.Resources._15);
            obrazki.Add(Properties.Resources._16);
            obrazki.Add(Properties.Resources._17);
            obrazki.Add(Properties.Resources._18);
            obrazki.Add(Properties.Resources._19);
            obrazki.Add(Properties.Resources._20);
            obrazki.Add(Properties.Resources._21);
            obrazki.Add(Properties.Resources._22);
            obrazki.Add(Properties.Resources._23);
            obrazki.Add(Properties.Resources._24);
        }

    }
}
