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

            #region Keyboard input
            //Console.WriteLine("Input cleartext");
            //string cleartext = Console.ReadLine();
            //Console.WriteLine("Input ciphertext");
            //string ciphertext = Console.ReadLine();
            //Console.WriteLine("Key Length");
            //int keyLength = int.Parse(Console.ReadLine());
            #endregion Keyboard input

            #region Test values
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
            #endregion Test values

            #region Variable setup
            // Creating a list of characters to avoid multiple modulo operations.
            List<char> alphabetList = 
                Enumerable
                    .Range('A', 'Z' - 'A' + 1)
                    .Select(c => (char)c)
                    .ToList();

            // Setting up the counter that counts the tries till we're done.
            int counter = 0;

            // Setting up a stopwatch for performance evaluation.
            Stopwatch watch = new Stopwatch();
            #endregion Variable setup


            Console.WriteLine($"The key for ciphertext {ciphertext} with plaintext {cleartext} is:");
            watch.Start();

            // assuming the cleartext is bigger than the key (key is calculatable), try to find each value of the key.
            for (int i = 0; i < keyLength; i++)
            {
                // loop through each character in the alphabet
                for(int j = 0; j <=26; j++)
                {
                    // increment the tries counter for every try
                    counter++;

                    // check if character is out of alphabet bounds, and set it within bounds if it does so.
                    char currChar = cleartext[i] + j > 'Z' 
                                        ? (char)(cleartext[i] + j - 'Z' + 'A' - 1) 
                                        : (char)(cleartext[i] + j);
                    // if the character is the same as the ciphertext, we have found the key distance.
                    if (currChar == ciphertext[i])
                    {
                        // we turn the distance into a character and stop looping for this char.
                        Console.Write(alphabetList[j]);
                        break;
                    }
                }
            }
            // stop the stopwatch and output results.
            watch.Stop();
            Console.WriteLine();

            Console.WriteLine($"The program took {watch.Elapsed.TotalMilliseconds}ms to run to completion after {counter} tries.");

            // just to make the program stop before exiting.
            Console.ReadKey();
        }
    }
}
