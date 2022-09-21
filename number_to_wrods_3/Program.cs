using System;
using System.Collections.Generic;

namespace number_to_words_2
{
    internal class Program
    {

        static void Main(string[] args)

        /* Plan of ATTACK:
         * User Inputs a number such as 1345
         * The system checks on how big the number is This is shown through the number 1345
         * 1345 is discovered as being over one thousand so it will be divided by one thousand to 1.345 - This is rounded down and typed as one thousand
         * 
         */
        {
            Console.WriteLine("Please Enter Your Designated Number:");
            int input = Convert.ToInt32(Console.ReadLine());
            int answer, next, num_digits;
            int[] a = new int[10];

            // words for every digits from 0 to 9
            string[] digits_words = {
            "zero",
            "one",
            "two",
            "three",
            "four",
            "five",
            "six",
            "seven",
            "eight",
            "nine",
            "ten",
            "eleven",
            "twelve",
            "teen",
            "ty",
            "hundred",
            "thousand"
         };

            // number to be converted into words
            answer = input;
            Console.WriteLine("Number: " + answer);
            Console.Write("Number (words): ");

            next = 0;
            num_digits = 0;

            do
            {
                next = answer % 10;
                a[num_digits] = next;
                num_digits++;
                answer = answer / 10;
            } while (answer > 0);

            num_digits--;

            for (; num_digits >= 0; num_digits--)

                    Console.Write(digits_words[a[num_digits]] + " ");
                    Console.ReadLine();
               
            ;
        }
    }
}
