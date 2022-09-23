using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;

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
            Console.WriteLine("Please Enter Your Designated Number between zero and ten million:");
            int input = Convert.ToInt32(Console.ReadLine());
            int answer, next, num_digits, digits_num, count = 0, count_num;
            int[] a = new int[10];

            // words for every digits from 0 to 9
            string[] digits_words = {
            "Zero",
            "One",
            "Two",
            "Three",
            "Four",
            "Five",
            "Six",
            "Seven",
            "Eight",
            "Nine",
            "Ten",
            "Eleven",
            "Twelve",
            "Twenty",
            "Thirty",
            "fourty",
            "fifty",
            "sixty",
            "seventy",
            "eighty",
            "ninety",
            "teen",
            "ty"
         };

            answer = input;
            count_num = answer;
            while (count_num > 0)
            {
                count_num = count_num / 10;
                count++;
            }
            bool million = false;
            bool hthousand = false;
            bool tthousand = false;
            bool thousand = false;
            bool hundred = false;
            bool teens = false;
            bool ones = false;

            if (count > 7 || answer < 0)
                //Check if number is greater then a million and not negative
            {
                Console.Write("This is not a valid number");
            }
            else
            {

                while (count >= 0)
                    //Check to see if there are any numbers left in the answer
                {

                    if (count == 7)
                    {
                        //If a number is a million or more
                        Console.Write(digits_words[answer / 1000000] + " Million ");
                        //Removes the millionth digit
                        answer = answer % 1000000;
                        million = true;
                    }
                    else
                    {
                        if (count == 6)
                        {
                            if (answer / 100000 == 0){


                            }
                            else
                            {
                                Console.WriteLine(digits_words[answer / 100000] + " Hundred");
                                answer = answer % 100000;
                                hthousand = true;
                            }
                        }
                        else
                        {
                            if (count == 5)
                            {
                                if (answer / 10000 == 0)
                                {

                                }
                                else
                                {
                                    if (hthousand)
                                    {
                                        Console.WriteLine(" and");
                                    }
                                    if (answer / 10000 == 1)
                                    {
                                        Console.WriteLine("Ten");
                                        answer = answer % 10000;
                                        tthousand = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine(digits_words[answer / 10000 + 11]);
                                        answer = answer % 10000;
                                        tthousand = true;
                                    }
                                };
                            }
                            else
                            {
                                if (count == 4)
                                {
                                    if (answer / 1000 == 0)
                                    {
                                        if (hthousand || tthousand){
                                            Console.WriteLine(" Thousand");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("-" + digits_words[answer / 1000] + " Thousand");
                                        answer = answer % 1000;
                                        thousand = true;
                                    }

                                }
                                else
                                {
                                    if (count == 3)
                                    {
                                        if (answer / 100 == 0)
                                        {}
                                        else
                                        {
                                            Console.WriteLine(digits_words[answer / 100] + " Hundred");
                                            answer = answer % 100;
                                            hundred = true;
                                        }
                                    }
                                    else
                                    {
                                        if (count == 2)
                                        {
                                            if (answer / 10 == 0)
                                            {

                                            }
                                            else
                                            {
                                                if (hundred){
                                                    Console.Write("and");
                                                }
                                                if (answer / 10 == 1)
                                                {
                                                    teens = true;
                                                    answer = answer % 10;
                                                }
                                                else
                                                {
                                                    Console.WriteLine(digits_words[answer / 10 + 11] + "");
                                                    answer = answer % 10;
                                                    
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (count == 1)
                                            {
                                                if(answer == 0)
                                                {
                                                    if (teens)
                                                    {
                                                        Console.Write("Ten");
                                                    }
                                                }
                                                else
                                                {
                                                    if (teens)
                                                    {
                                                        if (answer < 3 || answer == 5)
                                                            //11, 12, 15
                                                        {
                                                            if (answer == 5)
                                                                //15
                                                            {
                                                                Console.Write("Fifteen");
                                                            }
                                                            else
                                                            {
                                                                //Eleven or Twelve
                                                                Console.WriteLine(digits_words[answer + 10]);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            //Thirteen to 19
                                                            Console.WriteLine(digits_words[answer] + "teen");

                                                        }
                                                    }
                                                    else
                                                    {
                                                        //Twenty and above or below 10
                                                        Console.WriteLine("-" + digits_words[answer] + "");
                                                        answer = answer % 1;
                                                        ones = true;
                                                    }
                                                }
                                            }
                                        }

                                    }
                                }
                            }

                        }
                    }
                    count--;





                }
            }
        }
    }
}
