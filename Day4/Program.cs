using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] temp = File.ReadAllLines("adat.txt");
            int sum = 0;
            int xes = 0;
            for (int i = 0; i < temp.Length; i++)
            {
                string sor = temp[i];
                int sormax = sor.Length-1;
                for (int a = 0; a < sormax+1; a++)
                {
                    if (sor[a] == 'X')
                    {
                        #region jobb
                        if (sormax >= a + 3)
                        {
                            if (sor[a+1] == 'M' && sor[a + 2] == 'A' && sor[a + 3] == 'S')
                            {
                                sum = sum + 1;
                            }
                        }
                        #endregion
                        #region ball
                        if (a - 3 >= 0)
                        {
                            if (sor[a - 1] == 'M' && sor[a - 2] == 'A' && sor[a - 3] == 'S')
                            {
                                sum = sum + 1;
                            }
                        }

                        #endregion
                        #region fent
                        if (i-3 >= 0)
                        {
                            if (temp[i - 1][a] == 'M' && temp[i - 2][a] == 'A' && temp[i - 3][a] == 'S')
                            {
                                sum = sum + 1;
                            }
                        }
                        #endregion
                        #region lent
                        if (i + 3 <= temp.Length-1)
                        {
                            if (temp[i + 1][a] == 'M' && temp[i + 2][a] == 'A' && temp[i + 3][a] == 'S')
                            {
                                sum = sum + 1;
                            }
                        }
                        #endregion

                        #region jobbfent
                        if (sormax >= a + 3 && i - 3 >= 0)
                        {
                            if (temp[i - 1][a+1] == 'M' && temp[i - 2][a + 2] == 'A' && temp[i - 3][a + 3] == 'S')
                            {
                                sum = sum + 1;
                            }
                        }
                        #endregion
                        #region ballfent
                        if (a - 3 >= 0 && i - 3 >= 0)
                        {
                            if (temp[i - 1][a-1] == 'M' && temp[i - 2][a - 2] == 'A' && temp[i - 3][a - 3] == 'S')
                            {
                                sum = sum + 1;
                            }
                        }
                        #endregion
                        #region jobblent
                        if (sormax >= a + 3 && i + 3 <= temp.Length-1)
                        {
                            if (temp[i + 1][a + 1] == 'M' && temp[i + 2][a + 2] == 'A' && temp[i + 3][a + 3] == 'S')
                            {
                                sum = sum + 1;
                            }
                        }

                        #endregion
                        #region balllent
                        if (a - 3 >= 0 && i + 3 <= temp.Length-1)
                        {
                            if (temp[i + 1][a - 1] == 'M' && temp[i + 2][a - 2] == 'A' && temp[i + 3][a - 3] == 'S')
                            {
                                sum = sum + 1;
                            }
                        }
                        #endregion

                    }
                    //part 2
                    if (sor[a] == 'A')
                    {
                        if (a > 0 && sormax >= a + 1 && i + 1 <= temp.Length - 1 && i - 1 >= 0)
                        {
                            if (((temp[i -1][a-1] == 'M' && temp[i + 1][a + 1] == 'S') && (temp[i - 1][a + 1] == 'M' && temp[i + 1][a - 1] == 'S')) ||
                                ((temp[i - 1][a - 1] == 'S' && temp[i + 1][a + 1] == 'M') && (temp[i - 1][a + 1] == 'S' && temp[i + 1][a - 1] == 'M')) ||
                                ((temp[i - 1][a - 1] == 'S' && temp[i + 1][a + 1] == 'M') && (temp[i - 1][a + 1] == 'M' && temp[i + 1][a - 1] == 'S')) ||
                                ((temp[i - 1][a - 1] == 'M' && temp[i + 1][a + 1] == 'S') && (temp[i - 1][a + 1] == 'S' && temp[i + 1][a - 1] == 'M')))
                            {
                                xes = xes + 1;
                            }
                        }
                    }



                }
            }
            Console.WriteLine(sum);
            Console.WriteLine(xes);
            Console.Read();
        }
    }
}
