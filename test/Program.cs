using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadLines("input.txt")
            .Select(s => s.Split(' ').Select(int.Parse));

            Console.WriteLine(input.Count(IsSafe1));
            Console.WriteLine(input.Count(IsSafe2));

            bool IsSafe1(IEnumerable<int> a) =>
                IsSafe(a.Zip(a.Skip(1), (x, y) => x - y));

            bool IsSafe2(IEnumerable<int> a) =>
                Enumerable.Range(0, a.Count())
                    .Any(i => IsSafe1(a.Take(i).Concat(a.Skip(i + 1))));

            bool IsSafe(IEnumerable<int> b) =>
                b.All(x => x >= -3 && x <= -1) ||
                b.All(x => x >= 1 && x <= 3);
            Console.Read();
        }
    }
}
