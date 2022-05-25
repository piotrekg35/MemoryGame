using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad1
{
    public class ScoreCounter
    {
        public static void countScore(Form4 okno)
        {
            if (okno.poziom == "Łatwy") okno.wynik = 2000;
            else if (okno.poziom == "Średni") okno.wynik = 4000;
            else okno.wynik = 8000;
            okno.wynik = okno.wynik - okno.czas - okno.liczba_pomyłek * 100;
            if (okno.wynik < 0) okno.wynik = 0;
        }
    }
}
