using System;
using System.Collections.Generic;
using System.Drawing;

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
            int answer, next, num_digits, digits_num, count = 0, count_num;
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
            "twenty",
            "thirty",
            "teen",
            "ty",
            "hundred",
            "thousand"
         };

            answer = input;
            count_num = answer;
            while (count_num > 0)
            {
                count_num = count_num / 10;
                count++;
            }
            //Console.WriteLine("Number of digits is : " + count);
            //Console.ReadLine();
            while(count > 0)
            {
                if (count == 5)
                {
                    Console.Write(digits_words[answer / 1000] + " Ten Thousand ");
                }
                if (count == 4)
                {
                    Console.Write(digits_words[answer / 1000] + " Thousand ");
                }

                if (count == 3)
                {
                    Console.Write(digits_words[answer / 100] + " hundred ");
                }
                if (count == 2)
                {
                    if (answer / 10 < 4)
                    {
                        Console.Write(digits_words[answer/10 + 11] +'-');
                    }
                    else
                    {
                        Console.Write(digits_words[answer / 10] + "ty-");
                    }
                }
                if (count == 1)
                {
                    Console.Write(digits_words[answer%10 + 1]);
                }


                answer = answer / 10;
                count--;
            }

        }
    }
}
