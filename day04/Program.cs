using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;


namespace day04
{
    class Program
    {
        const string key = "yzbqklnj";

        static void Main(string[] args)
        {
            // Part 1
            var num = 1;
            using ( var md5 = MD5.Create() )
                while (!IsAdventCoin(num, md5))
                {
                    num++;
                    if (num % 1000 == 0)
                        Console.Write(".");
                }
            Console.WriteLine("\nPart 1 Solution: " + num);

            // Part 2
            num = 1;
            using (var md5 = MD5.Create())
                while (!IsAdventCoin2(num, md5))
                {
                    num++;
                    if (num % 1000 == 0)
                        Console.Write(".");
                }
            Console.WriteLine("\nPart 2 Solution: " + num);

            Console.ReadKey();
        }

        private static bool IsAdventCoin(int num, MD5 hasher)
        {
            var text = key + num.ToString(System.Globalization.CultureInfo.InvariantCulture);
            var hash = hasher.ComputeHash(Encoding.UTF8.GetBytes(text));
            return hash[0] == 0 && hash[1] == 0 && hash[2] < 16;
        }

        private static bool IsAdventCoin2(int num, MD5 hasher)
        {
            var text = key + num.ToString(System.Globalization.CultureInfo.InvariantCulture);
            var hash = hasher.ComputeHash(Encoding.UTF8.GetBytes(text));
            return hash[0] == 0 && hash[1] == 0 && hash[2] == 0;
        }
    }
}
