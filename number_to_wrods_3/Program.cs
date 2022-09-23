using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace number_to_words_2
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //Writes an input for the user
            Console.WriteLine("Please Enter Your Designated Number between zero and ten million:");
            int input;
            //Checks if the user inputed a number
            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.Clear();
                Console.WriteLine("You Entered an invalid number");
                Console.WriteLine("Please Enter Your Designated Number between zero and ten million:");
            }
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
            "Fourty",
            "Fifty",
            "Sixty",
            "Seventy",
            "Eighty",
            "Ninety",
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
            bool tenthousand = false;
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
                            //If the answer is now in the hundred thousands
                        {
                            if (answer / 100000 == 0){
                                //Check if the answer is in the hundred thousands but it is zero so ignore


                            }
                            else
                            {
                                //Make hthousand true and write on screen the number with hundred
                                Console.Write(digits_words[answer / 100000] + " Hundred");
                                answer = answer % 100000;
                                hthousand = true;
                            }
                        }
                        else
                        {
                            if (count == 5)
                                //If the number is now in tens of thousands
                            {
                                if (answer / 10000 == 0)
                                    //Check if the tens of thousands have a number
                                {
                                }
                                else
                                {
                                    if (hthousand)
                                    {
                                        //Only if there was a hundredthousand digit then the program will write "and"
                                        Console.Write(" and ");
                                    }
                                    if (answer / 10000 == 1)
                                    {
                                        answer = answer % 10000;
                                        tenthousand = true;
                                    }
                                    else
                                    {
                                        //if it is greater then ten thousand (twenty - ninety thousand)
                                        Console.Write(digits_words[answer / 10000 + 11]);
                                        answer = answer % 10000;
                                        tthousand = true;
                                    }
                                };
                            }
                            else
                            {
                                if (count == 4)
                                    //if there is thousands
                                {
                                    if (answer / 1000 == 0)
                                        //if there is no digit in the thousands (a zero)
                                    {
                                        if (hthousand || tthousand || tenthousand){
                                            //If there was a hundred thousand or a tens of thousand then the program will write thousand
                                            if(tenthousand){
                                                Console.Write("Ten Thousand ");
                                                    answer = answer % 1000;
                                            }
                                            else {
                                                Console.Write(" Thousand ");
                                            }
                                        }

                                    }

                                    else
                                    {
                                        if (tenthousand)
                                        {
                                            if (answer / 1000 < 3 || answer / 1000 == 5)
                                            {
                                                if (answer / 1000 == 5)
                                                //15
                                                {
                                                    Console.Write("Fifteen Thousand ");
                                                }
                                                else
                                                {
                                                    //Eleven or Twelve
                                                    Console.Write(digits_words[answer / 1000 + 10] + " Thousand ");
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (tthousand)
                                            {
                                                //Checks if the number is in the twenty-ninety thousands and needs a hyphon
                                                Console.Write("-");
                                            }
                                            //Prints the number that is within the thousands
                                            Console.Write(digits_words[answer / 1000] + " Thousand ");
                                            answer = answer % 1000;
                                            thousand = true;
                                        }
                                    }

                                }
                                else
                                {
                                    if (count == 3)
                                        //Checks to see if the number is in the hundreds
                                    {
                                        if (answer / 100 == 0)
                                            //Checks to see if that number is a zero
                                        {}
                                        else
                                        {
                                            //The number is not a zero so it prints the number with hundred at the end
                                            Console.Write(digits_words[answer / 100] + " Hundred");
                                            answer = answer % 100;
                                            hundred = true;
                                        }
                                    }
                                    else
                                    {
                                        //Checks if number is between 0 and 99
                                        if (count == 2)
                                        {
                                            if (answer / 10 == 0)
                                            {
                                                //This means that nothing needs to be printed if this occurs
                                            }
                                            else
                                            {
                                                if (hundred){
                                                    //If there is a hundred in the original number it will print "AND"
                                                    Console.Write(" and ");
                                                }
                                                if (answer / 10 == 1)
                                                {
                                                    //Checks to see if the number is between 10-19
                                                    teens = true;
                                                    answer = answer % 10;
                                                }
                                                else
                                                {
                                                    //Number is from 20-99
                                                    Console.Write(digits_words[answer / 10 + 11] + "");
                                                    answer = answer % 10;
                                                    
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (count == 1)
                                                //Checks if the number is now single digit
                                            {
                                                if(answer == 0)
                                                {
                                                    //Checks if the number is either Ten or Zero
                                                    if (teens)
                                                        //If number is Ten it is because the boolean has been activated if not activated print "Zero"
                                                    {
                                                        
                                                        Console.Write("Ten");
                                                    }
                                                    else
                                                    {
                                                        Console.Write("Zero");
                                                    }
                                                }
                                                else
                                                {
                                                    //Checks if the number is in the teens therefore having to output a different result
                                                    if (teens)
                                                    {
                                                        //checks to see if it is 11,12,15 as these are spelt differently 
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
                                                                Console.Write(digits_words[answer + 10]);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            //Thirteen to 19
                                                            Console.Write(digits_words[answer] + "teen");

                                                        }
                                                    }
                                                    else
                                                    {
                                                        //Twenty and above or below 10
                                                        Console.Write("-" + digits_words[answer] + "");
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
