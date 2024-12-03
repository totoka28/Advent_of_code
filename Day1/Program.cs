using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] temp = File.ReadAllLines("adat.txt");
            List<int> bal = new List<int>();
            List<int> jobb = new List<int>();
            int sum = 0;
            foreach (var item in temp)
            {
                bal.Add(Convert.ToInt32(item.Split()[0]));
                jobb.Add(Convert.ToInt32(item.Split()[1]));
            }
            bal.Sort();
            jobb.Sort();
            for (int i = 0; i < bal.Count; i++)
            {
                sum = sum + Math.Abs(bal[i] - jobb[i]);
            }
            Console.WriteLine(sum);

            //b feladatt
            int osszeg = 0;
            foreach (var item in bal)
            {
                int db = 0;
                foreach (var alma in jobb)
                {
                    if (item == alma)
                    {
                        db = db + 1;
                    }
                }
                osszeg = osszeg + item * db;
            }
            Console.WriteLine(osszeg);
            Console.Read();
        }
    }
}
