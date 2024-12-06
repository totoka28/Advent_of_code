using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    internal class Program
    {

        public static bool ellenorzes(List<int> szamocska, List<string> rules)
        {
            for (int i = 0; i < szamocska.Count(); i++)
            {
                List<int> kellszabaly = new List<int>();
                foreach (var alma in rules)
                {
                    if (alma.Split('|')[0].Equals(szamocska[0].ToString()))
                    {
                        kellszabaly.Add(Convert.ToInt32(alma.Split('|')[1]));
                    }
                }
                szamocska.RemoveAt(0);
                foreach (var eper in szamocska)
                {
                    if (!kellszabaly.Contains(eper))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        static void Main(string[] args)
        {
            string[] temp = File.ReadAllLines("adat.txt");
            List<string> rules = new List<string>();
            List<string> szamok = new List<string>();
            bool masodik = false;
            foreach (var item in temp)
            {
                if (item == "")
                {
                    masodik = true;
                }
                if (masodik)
                {
                    szamok.Add(item);
                }
                else
                {
                    rules.Add(item);
                }
            }
            szamok.RemoveAt(0);

            int dbsum = 0;
            int dbsum2 = 0;
            foreach (var item in szamok)
            {
                bool rosszszam = false;
                List<int> szamocska = new List<int>();
                List<int> szamocska2 = new List<int>();
                szamocska.AddRange(item.Split(',').Select(int.Parse).ToArray());
                szamocska2.AddRange(szamocska);
                rosszszam = ellenorzes(szamocska2, rules);

                if (!rosszszam)
                {
                    dbsum = dbsum + Convert.ToInt32(item.Split(',')[(szamocska2.Count()) / 2 +1]);
                }
                else
                {
                    //part 2
                    List<int> ujszam = new List<int>();
                    int szam = szamocska.Count;
                    for (int cd = 0; cd < szam; cd++)
                    {
                        bool hiba = true;
                        while (hiba)
                        {
                            hiba = false;
                            List<int> kellszabaly = new List<int>();
                            foreach (var alma in rules)
                            {
                                if (alma.Split('|')[0].Equals(szamocska[0].ToString()))
                                {
                                    kellszabaly.Add(Convert.ToInt32(alma.Split('|')[1]));
                                }
                            }
                            int kivett = szamocska[0];
                            szamocska.RemoveAt(0);
                            for (int i = 0; i < szamocska.Count; i++)
                            {

                                if (!kellszabaly.Contains(szamocska[i]))
                                {
                                    szamocska.Insert(0, kivett);
                                    szamocska.Insert(0, szamocska[i + 1]);
                                    szamocska.RemoveAt(i + 2);
                                    hiba = true;
                                    i = szamocska.Count + 1;
                                }
                            }
                            if (!hiba)
                            {
                                ujszam.Add(kivett);
                            }
                        }
                    }
                    
                    dbsum2 = dbsum2 + Convert.ToInt32(ujszam[(ujszam.Count()) / 2]);

                }
            }
            Console.WriteLine(dbsum);
            Console.WriteLine(dbsum2);

            Console.Read();
        }
    }
}
