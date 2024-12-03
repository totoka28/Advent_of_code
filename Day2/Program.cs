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
                List<int> kimenet = new List<int>();
                for (int i = 0; i < sor.Length-1; i++)
                {
                    kimenet.Add(sor[i] - sor[i + 1]);
                }
                bool negativ = true;
                if (kimenet[0] > 0)
                {
                    negativ = false;
                }
                
                foreach (var item1 in kimenet)
                {

                    if(!(Math.Abs(item1) > 3 || item1 == 0))
                    {
                        if (!(item1 < 0 == negativ))
                        {
                            nemjo = true;
                        }
                    }
                    else
                    {
                        nemjo = true;
                    }

                    Console.Write(item1 + " ");
                }
                Console.WriteLine();
                if (nemjo)
                {
                    Console.WriteLine("szar");
                }
                else
                {
                    Console.WriteLine("jó");
                    sum = sum + 1;
                }
            }
            Console.WriteLine(sum);
            Console.Read();
        }
    }
}
