using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    internal class Program
    {
        static public bool ellenorzes(int szam, bool negativ)
        {
            bool nemjo = false;
            if (!(Math.Abs(szam) > 3 || szam == 0))
            {
                if (!(szam < 0 == negativ))
                {
                    nemjo = true; 
                }
            }
            else
            {
                nemjo = true;
            }

            return nemjo;
        }
        
        
        
        static void Main(string[] args)
        {
            string[] temp = File.ReadAllLines("adat.txt");
            int sum = 0;
            foreach (var item in temp)
            {
                bool nemjo = false;
                int[] sor = item.Split().Select(int.Parse).ToArray();
                foreach (var alma in sor)
                {
                    Console.Write(alma + " ");
                }
                Console.WriteLine();
                bool negativ = true;
                if (sor[0] - sor[1] > 0)
                {
                    negativ = false;
                }
                List<int> szam = new List<int>();
                foreach (var alma in sor)
                {
                    szam.Add(alma);
                }
                for (int i = 0; i < szam.Count - 1; i++)
                {
                    int kulombseg = szam[i] - szam[i + 1];
                    if (ellenorzes(kulombseg, negativ))
                    {
                        nemjo = true;
                    }
                    Console.Write(kulombseg + " ");
                }
                Console.WriteLine();

                bool btervsiker = false;
                if (nemjo)
                {
                    bool nemjo2 = false;
                    Console.WriteLine("B-terv");
                    for (int i = 0; i < szam.Count; i++)
                    {
                        int kivesz = szam[i];
                        szam.RemoveAt(i);

                        foreach (var eper in szam)
                        {
                            Console.Write(eper + " ");
                        }
                        Console.WriteLine();

                        negativ = true;
                        if (szam[0] - szam[1] > 0)
                        {
                            negativ = false;
                        }

                        for (int a = 0; a < szam.Count - 1; a++)
                        {
                            int kulombseg = szam[a] - szam[a+1];
                            if (ellenorzes(kulombseg, negativ))
                            {
                                nemjo2 = true;
                            }
                            Console.Write(kulombseg + " ");
                        }

                        Console.WriteLine();
                        if (nemjo2)
                        {
                            Console.WriteLine("szar");
                        }
                        else
                        {
                            Console.WriteLine("jó");
                            btervsiker = true;
                        }
                        nemjo2 = false;
                        szam.Insert(i, kivesz);
                    }

                }

                Console.WriteLine();
                if (nemjo)
                {
                    Console.WriteLine("szar");
                    Console.WriteLine();
                    Console.WriteLine();
                    
                }
                else
                {
                    Console.WriteLine("jó a szám");
                    Console.WriteLine();
                    Console.WriteLine();
                    sum = sum + 1;
                }
                if (btervsiker)
                {
                    sum = sum + 1;
                    Console.WriteLine("amugy jó");
                }
                
                
                
            }
            Console.WriteLine(sum);
            
            Console.Read();
        }
    }
}
