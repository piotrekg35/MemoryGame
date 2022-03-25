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
    public partial class Form4 : Form

    {
        int czas = 0;
        int t1;
        int t2 ;
        string poziom;
        public Form4(int time1,int time2,string str)
        {
            InitializeComponent();
            t1 = time1;
            t2 = time2;
            poziom = str;
            numericUpDown1.Value = t2;
            label1.Text = "00:00";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            t2 = Convert.ToInt32(numericUpDown1.Value);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            czas++;
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
