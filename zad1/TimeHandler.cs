using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zad1
{
    public class TimeHandler
    {
        public static void updateTimer(Form4 okno)
        {
            double m = okno.czas / 60;
            int min = Convert.ToInt32(Math.Floor(m));
            if (min < 10 && (okno.czas - min * 60) < 10) okno.label1.Text = "0" + min + ":0" + (okno.czas - min * 60);
            else if (min < 10 && (okno.czas - min * 60) >= 10) okno.label1.Text = "0" + min + ":" + (okno.czas - min * 60);
            else if (min >= 10 && (okno.czas - min * 60) < 10) okno.label1.Text = min + ":0" + (okno.czas - min * 60);
            else okno.label1.Text = min + ":" + (okno.czas - min * 60);
        }
    }
}
