using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Program fib = new Program();
            int num= 0;
            string number;
            Console.Write("Enter a Number to find its Fibonacci Number(Enter zero to exit): ");
            number = Console.ReadLine();
            //Console.WriteLine(number);
            num = Convert.ToInt32(number);
            //Console.WriteLine("number into method: " +num);

            if (num == 0)
            {
                //blank so that the program terminates if user enters zero. 
            }
            else
            {
                num = fib.Fibonacci(num);
                Console.Write("The Fibonacci Number is: "+ num);
                Console.ReadLine();
            }
            
            
        }
        public int Fibonacci(int num)
        {
            if (num <= 1)
                return num;
            else
            {
                return Fibonacci(num - 1) + Fibonacci(num - 2);
                
            }
        }
    } 
}
