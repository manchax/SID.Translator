using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Principal;

namespace ParseHexSID
{
    class Program
    {

        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Usage: ParseHexSID <Hex value>.");
                Console.WriteLine("Example: ParseHexSID \"01 05 00 00 00 00 00 05 15 00 00 00 1A 9E BC 0D 8D BA EF 81 B8 E3 98 4A 50 04 00 00\"");
            }

            byte[] bytes = GetBytes(args[0]).ToArray();
            Console.Write("Decimal: ");
            foreach ( var b in bytes )
            {
                Console.Write($"{b:000} ");
            }
            Console.WriteLine();
            var id = new SecurityIdentifier(bytes, 0);
            Console.WriteLine("SSDL representation: {0}", id);
        }

        static IEnumerable<byte> GetBytes(string input)
        {
            foreach (string hex in input.Split(' '))
            {
                yield return Convert.ToByte(hex, 16);
            }
        }
    }
}
