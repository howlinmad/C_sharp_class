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
            int guess = 0, guessCount= 0, replay = 101, quit = 101;
            string num;

            Console.Out.WriteLine("Time to Play the Hi-Lo Guessing Game!\n");
           
            //Replay loop
            while (replay != 0)
            {
                Console.Out.WriteLine("Enter a number between 1 and 100: ");
                //User guesses once before program enters loop
                guessCount = 1;
                //Handle User Entering letters
                try
                {
                    num = Console.ReadLine();
                    guess = int.Parse(num);

                    Random number = new Random();
                    int gameNumber = number.Next(1, 100);
                    Console.Out.WriteLine(gameNumber + "  " + guessCount);

                    //game loop to check guess against target number.
                    while (guess != gameNumber)
                    {

                        if (guess > gameNumber && guess < 101 && guess > 0)
                        {
                            Console.Out.WriteLine("Your guess is High");
                            guessCount++;
                            Console.Out.WriteLine(gameNumber + "  " + guessCount);
                        }
                        else if (guess < gameNumber && guess < 101 && guess > 0)
                        {
                            Console.Out.WriteLine("You guess is low");
                            guessCount++;
                            Console.Out.WriteLine(gameNumber + "  " + guessCount);
                        }
                        else
                        {
                            guessCount++;
                            Console.Out.WriteLine("Please Enter only Numbers between 1 and 100");
                            Console.Out.WriteLine(gameNumber + "  " + guessCount);
                        }

                        Console.Out.WriteLine("(guess again or enter 0 to quit)");
                        num = Console.ReadLine();
                        quit = int.Parse(num);
                        guess = int.Parse(num);


                        //break loop if user wants to quit
                        if (quit == 0)
                        {
                            break;
                        }


                    }//end of game loop
                    //replay loop body
                    if (guess == gameNumber)
                    {
                        Console.Out.WriteLine("Correct! The number was: " + gameNumber
                            + "\nIt took you " + guessCount + " guesses to find the number!");
                        Console.Out.WriteLine("If you would like to play again enter 1 or enter 0 to quit: ");
                        //Clear guessCount
                        guessCount = 0;
                        num = Console.ReadLine();
                        replay = int.Parse(num);
                    }
                    else if (quit == 0)
                    {
                        Console.Out.WriteLine("You Lose, The number was " + gameNumber);
                        Console.Out.WriteLine("If you would like to play again enter 1 or enter 0 to quit: ");
                        //Clear GuessCount
                        guessCount = 0;
                        num = Console.ReadLine();
                        replay = int.Parse(num);
                    }
                    Console.Out.WriteLine(gameNumber + "  " + guessCount);
                }
                catch 
                {
                    guessCount++;
                    Console.Out.WriteLine("Please Enter only Numbers between 1 and 100");
                }
                   
            }
        }
    }
}
