using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long sum = 0;
            string temp = File.ReadAllText("adat.txt");
            //string pattern = @"mul\(\d{1,3},\d{1,3}\)";
            string pattern = @"(mul\(\d{1,3},\d{1,3}\))|(don't\(\)|do\(\))";
            Regex regex = new Regex(pattern);
            MatchCollection minden = regex.Matches(temp);
            Console.WriteLine(minden.Count);
            bool dont = false;
            foreach (var alma in minden)
            {
                Console.WriteLine(alma);
                if (alma.ToString() == "don't()")
                {
                    dont = true;
                }
                else if (alma.ToString() == "do()")
                {
                    dont = false;
                }
                else
                {
                    if (!dont)
                    {
                        string splitelendo = alma.ToString().Substring(4, alma.ToString().Length - 5);
                        sum = sum + (Convert.ToInt32(splitelendo.Split(',')[0]) * Convert.ToInt32(splitelendo.Split(',')[1]));
                    }
                }     
            }
            
            Console.WriteLine(sum);
            Console.Read();
        }
    }
}
