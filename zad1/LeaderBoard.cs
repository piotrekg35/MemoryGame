using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad1
{
    public class LeaderBoard
    {
        public static List<string> getTopFromFile(string path)
        {
            string text = System.IO.File.ReadAllText(path);
            string[] lines = text.Split('\n');
            List<string> top5 = new List<string>();
            foreach (string line in lines) top5.Add(line);
            top5.Sort();
            top5.Reverse();
            return top5.GetRange(0, 5);
        }
    }
}
