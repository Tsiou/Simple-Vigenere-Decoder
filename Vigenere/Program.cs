using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Vigenere
{
    class Program
    {
        static void Main(string[] args)
        {
            // For different parameters, uncomment the following lines to input the values from the keyboard, and comment the test lines.

            //Console.WriteLine("Input cleartext");
            //string cleartext = Console.ReadLine();
            //Console.WriteLine("Input ciphertext");
            //string ciphertext = Console.ReadLine();
            //Console.WriteLine("Key Length");
            //int keyLength = int.Parse(Console.ReadLine());

            List<char> alphabetList = 
                Enumerable
                    .Range('A', 'Z' - 'A' + 1)
                    .Select(c => (char)c)
                    .ToList();
            int counter = 0;


            // For testing, comment to run with custom values.
            var cleartext = "CONGRA";
            var ciphertext = "VIEOEG";
            int keyLength = 6;

            // Test 2, key length is unchanged.
            // var cleartext = "TULATI";
            // var ciphertext = "MOCIGO";

            // Test 3, key should show up as THISKEY
            // var cleartext = "SAMPLETEXT";
            // var ciphertext = "LHUHVIRXEB";
            // int keyLength = "THISKEY".Length;

            Console.WriteLine($"The key for ciphertext {ciphertext} with plaintext {cleartext} is:");
            Stopwatch watch = new Stopwatch();
            watch.Start();
            for (int i = 0; i < keyLength; i++)
            {
                for(int j = 0; j <=26; j++)
                {
                    counter++;

                    char currChar = cleartext[i] + j > 'Z' 
                                        ? (char)(cleartext[i] + j - 'Z' + 'A' - 1) 
                                        : (char)(cleartext[i] + j);
                    if (currChar == ciphertext[i])
                    {
                        Console.Write(alphabetList[j]);
                        break;
                    }

                }
            }
            watch.Stop();
            Console.WriteLine();

            Console.WriteLine($"The program took {watch.Elapsed.TotalMilliseconds}ms to run to completion after {counter} tries.");

            Console.ReadKey();
        }
    }
}
