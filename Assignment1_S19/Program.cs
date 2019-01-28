using System;
using System.Collections.Generic;

namespace Assignment1_S19
{
    class Program
    {
        public static void Main()
        {
            int a = 5, b = 15;
            printPrimeNumbers(a, b);

            int n1 = 5;
            double r1 = getSeriesResult(n1);
            Console.WriteLine("The sum of the series is: " + r1);


            long n2 = 15;
            long r2 = decimalToBinary(n2);
            Console.WriteLine("Binary conversion of the decimal number " + n2 + " is: " + r2);


            long n3 = 1111;
            long r3 = binaryToDecimal(n3);
            Console.WriteLine("Decimal conversion of the binary number " + n3 + " is: " + r3);


            int n4 = 5;
            printTriangle(n4);

            int[] arr = new int[] { 1, 2, 3, 2, 2, 1, 3, 2 };
            computeFrequency(arr);


            // write your self-reflection here as a comment
            /*
             * This exercise helps me to get familiar with Visual Studio and the syntax of C#. 
             * I had not previously worked with C# before. Thus, this is a great opportunity to learn and get ready 
             * for future assignments. Additionally, I get to review Git concepts and Git Tools in Visual Studio.
             * This assignment also helps me to get my environment set up.
             * 
             * Suggestion: Instead of copy and paste the original code from the Word document, we could have had
             * the provided sample tests and guided instructions from the class github page. Then, we could have learned 
             * more git technology on how to collaborate and using git fork.
             */
        }

        /*
        * x – starting range, integer (int)
        * y – ending range, integer (int)
        * 
        * summary      : This method prints all the prime numbers between x and y
        * For example 5, 25 will print all the prime numbers between 5 and 25 i.e. 
        * 5, 7, 11, 13, 17, 19, 23
        * Tip: Write a method isPrime() to compute if a number is prime or not.
        *
        * returns      : N/A
        * return type  : void
        *
        */
        public static void printPrimeNumbers(int x, int y)
        {
            try
            {
                bool isFirstPrime = true;     //a flag to NOT print out the first comma
                for (int i = x; i <= y; i++)  //loop from x to y
                {
                    if (isPrime(i) == true)   //if the current number is a prime number, print it out
                    {
                        if (isFirstPrime)
                        {
                            Console.Write(i);
                            isFirstPrime = false;
                        }
                        else
                        {
                            Console.Write(", " + i);
                        }
                    }
                }

                if (isFirstPrime)             //if this flag is still true, meaning there was not any prime numbers
                {
                    Console.WriteLine("There is no prime numbers in the given range");
                }
                else
                {
                    Console.WriteLine();
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing printPrimeNumbers()");
            }
        }

        // create method printPrime to print if a number is prime or not
        /*
         * 
         */
        static bool isPrime(int n)
        {
            if (n < 2)                      //if a number is less than 2, it is not prime
            {
                return false;
            }

            bool isP = true;                //a flag that indicates whether this number is prime or not
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0)             //if n divides any other numbers (>2 and <n) remains zero, the number is not prime
                {
                    isP = false;
                    break;
                }
            }
            return isP;
        }

        /*
        * para    n – number of terms of the series, integer (int)
        * 
        * summary        : This method computes the series 1/2 – 2!/3 + 3!/4 – 4!/5 --- n     * where ! means factorial, i.e., 4! = 4*3*2*1 = 24. Round off the results to 
        * three decimal places. 
        * Hint: Odd terms are all positive whereas even terms are all negative.
        * Tip: Write a method to computae factorial of n, call it whenever required.
        *
        * returns        : result
        * return type    : double
        */
        public static double getSeriesResult(int n)
        {
            if (n <= 0)     //make sure n is greater than 0. otherwise, return 0
            {
                Console.WriteLine("Please enter a number greater than 0");
                return 0;
            }

            try
            {
                double sum = 0;
                double temp = 0;
                for (int i = 1; i <= n; i++)            //loop from 1 to n
                {
                    if (i % 2 == 1)                     //if number is odd, the current term is positive
                    {
                        temp = factorial(i) / (i + 1);
                    }
                    else
                    {
                        temp = -factorial(i) / (i + 1); //if number is even, the current term is negative
                    }
                    sum = sum + temp;                   //add the term to sum
                }

                sum = Math.Round(sum, 3);               //round sum to 3 decimal places before returning the result
                return sum;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing getSeriesResult()");
            }
            return 0;
        }

        // create method factorial to calculate n!
        static double factorial(int x)
        {
            double fac = 1;
            for (int i = 1; i <= x; i++)        //loop from 1 to x
            {
                fac = fac * i;                  //multiply previous result to the current number

            }
            return fac;
        }

        /*
        * n – non-negative number to be converted, integer (long)
        * 
        * summary: This method converts a number from decimal (base 10) to binary (base 2).
        * Implementation: A number can be converted from decimal to binary in the following   
        * steps: 1)Divide it by 2. 2)Get the integer quotient for next iteration. 3)Get the   
        * remainder for binary digit. 4)Repeat the steps until the quotient is equal to 0.
        * For example, binary conversion for 15 is 1111 
        *
        * Follow this link for detail explanation:
        * https://www.rapidtables.com/convert/number/decimal-to-binary.html
        *
        * returns      : integer 
        * return type  : long
        */
        public static long decimalToBinary(long n)
        {
            if (n < 0)               //make sure the given number is non-negative
            {
                Console.WriteLine("Please provide a non-negative number to be converted");
                return 0;
            }

            try
            {
                string resultInText = "";
                while (n != 0)      //loop until quotient is 0
                {
                    long q = n / 2; //divide by 2  
                    long r = n % 2; //get the remainder
                    resultInText = resultInText + r.ToString(); //append the remainder to the result text
                    n = q;          //get quotient for the next iteration
                }
                long bin = Convert.ToInt64(resultInText);       //convert the result text to long before returning
                return bin;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing decimalToBinary()");
            }

            return 0;
        }

        /*
        * n – non-negative number to be converted, integer (long)
        * 
        * summary: This method converts a number from binary (base 2) to decimal (base 10).
        * Implementation: A number can be converted from binary to decimal in the following   
        * steps: 1)Start from the rightmost bit to the left. 2)Multiply each bit by 2^i where 
        * i starts from 0 and increases by 1 on iteration. 3)Add all the computations for the  
        * result.
        * For example, decimal conversion for 1101 = 1 * 2^3 + 1 * 2^2 + 0 * 2^1 + 1 * 2^0
        * = 1*8 + 1*4 + 0*2 + 1*1
        * = 8 + 4 + 0 + 1
        * = 13
        *
        * Follow this link for detail explanation:
        * https://www.rapidtables.com/convert/number/binary-to-decimal.html
        *
        * Tip: Write a method to compute 2^n, i.e, 2*2*2*2---n. Call it whenever required. Do * not use Math.Power()
        *
        * returns      : integer 
        * return type  : long
        */
        public static long binaryToDecimal(long n)
        {
            try
            {
                long sum = 0;
                int length = n.ToString().Length;           //convert the number to string and get its length
                for (int i = 0; i <= (length - 1); i++)     //loop through the number of digits of the provided number
                {
                    long q = n / 10;                        //get the number for the next iteration
                    long r = n % 10;                        //get the first digit, starting from the right most
                    if (r == 1)                                //if the remainder is 1, calculate the term and add to sum
                    {
                        long temp = r * power(i);
                        sum = sum + temp;
                    }
                    else if (r != 0)                         //if the remainder is not 0 or 1, the provided number is not binary. Thus, throw error
                    {
                        throw new Exception(" Not a binary number");
                    }
                    n = q;
                }
                return sum;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured while computing binaryToDecimal()" + e.Message);
            }

            return 0;
        }
        static long power(int x)                            //calculate 2-to-the power
        {
            int result = 1;
            for (int i = 1; i <= x; i++)
            {
                result = result * 2;
            }
            return result;
        }

        /*
        * n – number of lines for the pattern, integer (int)
        * 
        * summary      : This method prints a triangle using *
        * For example n = 5 will display the output as: 

            *
           ***
          *****
         *******
        *********

        *
        * returns      : N/A
        * return type  : void
        */
        public static void printTriangle(int n)
        {
            if (n < 1)         //make sure the provided number of line is 1 or greater
            {
                Console.WriteLine("Please provide a number greater than or equal 1");
                return;
            }

            try
            {
                for (int i = 1; i <= n; i++)            //loop through the number of lines, starting from 1
                {
                    for (int j = n - i; j >= 0; j--)    //this loop prints the number of white space for each line
                    {
                        Console.Write(" ");
                    }
                    for (int k = 0; k <= 2 * i - 1; k++)//this loop prints the number of '*' for each line
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine();                //go to the next line
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing printTriangle()");
            }
        }

        /*
        * a – array of elements, integer (int)
        * 
        * summary      : This method computes the frequency of each element in the array
        * For example a = {1,2,3,2,2,1,3,2} will display the output as: 

        Number  Frequency
        1   2
        2   4
        3   2

        * returns      : N/A
        * return type  : void
        */
        public static void computeFrequency(int[] a)
        {
            if (a == null || a.Length == 0)        //make sure a has values. Otherwise, return an error message
            {
                Console.WriteLine("Please provide a non-empty array of integers");
                return;
            }

            try
            {
                Dictionary<int, int> frequencyMap = new Dictionary<int, int>(); //a key-value dictionary to keep track of the occurences of each integer

                for (int i = 0; i <= a.Length - 1; i++) //loop through the provided array of integers
                {
                    if (frequencyMap.ContainsKey(a[i])) //if the current integer is already in the dictionary, increase its frequency by 1
                    {
                        frequencyMap[a[i]] = frequencyMap[a[i]] + 1;
                    }
                    else                                //otherwise, add the current integer to the dictionary and set its frequency to 1
                    {
                        frequencyMap.Add(a[i], 1);
                    }
                }

                Console.WriteLine("Number  Frequency"); //print out the frequency of all integers in the provided array
                foreach (int key in frequencyMap.Keys)  //loop through all keys
                {
                    Console.WriteLine(key + "   " + frequencyMap[key]);
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing computeFrequency()");
            }
        }
    }
}
