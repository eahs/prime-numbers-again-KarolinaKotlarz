using System;
using System.Diagnostics;

namespace PrimeNumbersAgain
{
    class Program
    {
        private static int[] primes;
        
        static void Main(string[] args)
        {
            int n, prime;
            Stopwatch timer = new Stopwatch();

            PrintBanner();
            n = GetNumber();

            timer.Start();
            prime = FindNthPrime(n);
            timer.Stop();

            Console.WriteLine($"\nToo easy.. {prime} is the nth prime when n is {n}. I found that answer in {timer.Elapsed.Seconds} seconds.");
            
            EvaluatePassingTime(timer.Elapsed.Seconds);
        }

        // Finds the nth prime number
        static int FindNthPrime(int n)
        {
            primes = new int[n]; // Create new array of length n
            int i = 0; // Create counter for the while loop
            int number = 1; // First number to check is 1
            
            while (i < n)
            {
                if (IsPrime(number))
                {
                    primes[i] = number;
                    i++;
                }
                number += 2;
            }
            
            return primes[n - 1];
        }
        
        // Checks if number is a prime number
        private static bool IsPrime(int number)
        {
            // Tries to divide it by each of the already known primes...
            foreach (int prime in primes)
            {
                // ...up to the square root of that number
                if (prime > Math.Sqrt(number))
                    break;
                if (prime == 0)
                {
                    break;
                }
                if (prime == 1)
                {
                    continue;
                }
                if (number % prime == 0)
                {
                    return false;
                }
            }
            return true;
            
        }

        static int GetNumber()
        {
            int n = 0;
            while (true)
            {
                Console.Write("Which nth prime should I find?: ");
                
                string num = Console.ReadLine();
                if (Int32.TryParse(num, out n))
                {
                    return n;
                }

                Console.WriteLine($"{num} is not a valid number.  Please try again.\n");
            }
        }

        static void PrintBanner()
        {
            Console.WriteLine(".................................................");
            Console.WriteLine(".#####...#####...######..##...##..######...####..");
            Console.WriteLine(".##..##..##..##....##....###.###..##......##.....");
            Console.WriteLine(".#####...#####.....##....##.#.##..####.....####..");
            Console.WriteLine(".##......##..##....##....##...##..##..........##.");
            Console.WriteLine(".##......##..##..######..##...##..######...####..");
            Console.WriteLine(".................................................\n\n");
            Console.WriteLine("Nth Prime Solver O-Matic Online..\nGuaranteed to find primes up to 2 million in under 30 seconds!\n\n");
            
        }

        static void EvaluatePassingTime(int time)
        {
            Console.WriteLine("\n");
            Console.Write("Time Check: ");

            if (time <= 30)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Pass");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Fail");
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            
        }
    }
}