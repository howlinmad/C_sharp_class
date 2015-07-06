/* GSD-311 Group 1 NIM project
 * 4/2/2014
 * Steven Campbell
 * Tracy LaBombard
 * Don Petersen
 * Create a console application for a player
 * to play NIM against the computer. 
 */

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
            //Main setup program
            char playAgain = 'y';
            while (playAgain != 'n')
            {
                Program nim = new Program();
                Game Nim = new Game();
                List<List<int>> list = new List<List<int>>();
                int piles, sticks;
                string num;
                bool turn = true;
                Console.Clear();
                nim.gameIntro();



                Console.Out.Write("\n\n How many Piles for today's game? ");
                num = Console.ReadLine();
                piles = Convert.ToInt32(num);

                //Sets up the initial array for playing field
                int[] numOfPiles = new int[piles];
                int pileNumber = 1;
                for (int i = 0; i < numOfPiles.Length; i++)
                {
                    Console.Out.Write(" Enter the number sticks for pile " + pileNumber + ": "); // May want to get rid of piles
                    num = Console.ReadLine();
                    sticks = Convert.ToInt32(num);
                    numOfPiles[i] = sticks;
                    pileNumber++;
                }



                turn = Nim.playerOrder();
                //Console.Out.WriteLine("This needs to get put into arry: {0}", Nim.compDecide(Nim.getIndicator(numOfPiles),numOfPiles));

                //to test the elements of the array.
                Console.Clear();
                Console.Out.WriteLine("Sticks in each pile: \n");

                for (int i = 0; i < numOfPiles.Length; i++)
                {
                    Console.Out.Write("Pile " + (i+1) + ": " + numOfPiles[i] + " \n");
                }


                
                while (Nim.getWinner(numOfPiles) == false)//winner method)
                {
                    if (turn)
                    {
                        //method that handles player turn
                        Console.Clear();
                        Console.Out.WriteLine("Sticks in each pile: \n");

                        for (int i = 0; i < numOfPiles.Length; i++)
                        {
                            Console.Out.Write("Pile " + (i + 1) + ": " + numOfPiles[i] + " \n");
                        }
                        Console.Out.WriteLine("\n************************");
                        Console.Out.WriteLine("Player turn");
                        numOfPiles[Nim.choosePile(numOfPiles) - 1] -= Nim.chooseSticks(); ;

                        //test to see if num of sticks is decreased from correct pile.
                        //Console.Out.Write("Nuber of sticks in each pile: ");
                        //for (int i = 0; i < numOfPiles.Length; i++)
                        //{
                        //    Console.Out.WriteLine(numOfPiles[i] + " ");
                        //}

                        turn = false;

                    }
                    else
                    {
                        //put computer turn here
                        //Console.Out.WriteLine("Computer turn");
                        Nim.compDecide(Nim.getIndicator(numOfPiles), numOfPiles);
                        //Console.Out.Write("Nuber of sticks in each pile: ");
                        //for (int i = 0; i < numOfPiles.Length; i++)
                        //{
                        //    Console.Out.Write(numOfPiles[i] + " ");
                        //}

                        turn = true;
                    }
                }
                //test to see winner
                playAgain = winner(turn);

            }
           


              
            progTerm(); //Terminate program



        }
        // Intro to game
        public void gameIntro()
        {
            Console.Out.WriteLine("\n\t\t\t    Time to play Nim!");
            Console.Out.WriteLine("\n\n\t   The game where whoever picks up the last stick wins!");
        }

        // Method to terminate program
        static void progTerm()
        {
            Console.Out.WriteLine("\n\n\nProgram terminated, Press Enter to exit");
            Console.In.ReadLine();
        }
        public static char winner(bool winner)
        {
            char ans;
            // Visual effects for winning 
            String[] colorNames = ConsoleColor.GetNames(typeof(ConsoleColor));

            if (winner == false)
            {
                foreach (string colorName in colorNames)
                {
                    // Convert the string representing the enum name to the enum value.
                    ConsoleColor color = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), colorName);

                    // Cycle through the colors in console for
                    // Visual cue - My idea
                    Console.BackgroundColor = color;
                    Console.Clear();
                    System.Threading.Thread.Sleep(100);

                }
                // Reset to users console defaults and inform user of 
                // correct answer and number of attempts
                Console.ResetColor();
                Console.Clear();
                Console.Out.WriteLine("\n\n\n\n\n");
                Console.Out.WriteLine("\t\tYou must have cheated! You can't beat me fairly!");
                Console.Out.WriteLine("\t\t\t\tTry again? [y/n]");
                ans = Convert.ToChar(Console.In.ReadLine());
                return ans;
            }
            else
            {
                Console.Clear();
                Console.Out.WriteLine("\n\n\n\n\n");
                Console.Out.WriteLine("\t\t\tYou lose! Get out of my RAM!");
                Console.Out.Write("\t\t\tCare to try again? [y/n]: ");
                ans = Convert.ToChar(Console.In.ReadLine());
                return ans;
            }

        }

    }
    // Main Class for game 
    class Game
    {
        //Class variables
        public List<List<int>> list = new List<List<int>>();
        // Convert decimal to binary string
        public string decToBin(int n)
        {
            string tmpConv;
            tmpConv = Convert.ToString(n, 2);
            return tmpConv;
        }
        // Convert binary string back to decimal
        public int binToDec(string str)
        {
            int tmpConv;
            tmpConv = Convert.ToInt16(str, 2);
            return tmpConv;
        }
        // XOR method to indentify state of playing field
        public string getIndicator(int[] arr)
        {
            int comp = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                comp ^= arr[i];
            }
            return Convert.ToString(comp, 2);
        }
        // Computer decision method.
        public void compDecide(string ind, int[] arr)
        {
            if (ind == "0")
            {
                for (int i = 0; i < arr.Length; i++)
                    if (arr[i] > 0)
                    {
                        arr[i] = arr[i] - 1;
                        Console.Out.WriteLine("\n************************");
                        Console.Out.WriteLine("Computer removes " + 1 + " stick[s] from pile " + (i+1));
                        Console.Out.WriteLine("Press Enter for next turn");
                        Console.In.ReadLine();
                        break;
                    }
            }
            else
            {


                // Build a temporay list to hold array of getIndicator
                // Used to compare lengths to find appropriate row to subtract from
                List<int> tmpList = new List<int>();
                int n;
                Console.Out.WriteLine("\n************************");
                foreach (char ch in ind)
                {
                    n = (int)Char.GetNumericValue(ch);
                    tmpList.Add(ch);
                }
                int comp = 0, place = 0;
                // This was to test the counter for debug
                //Console.Out.WriteLine("List.count: " + tmpList.Count);
                // Temporary list to cycle through array elements
                // as char lists to find match
                List<char> arrList = new List<char>();
                // Run the elements through creation process
                for (int i = 0; i < arr.Length; i++)
                {
                    // Need to call decToBin method 
                    foreach (char ch in decToBin(arr[i]))
                    {
                        arrList.Add(ch);
                    }
                    // Find list with matching length...
                    //if (arrList.Count == tmpList.Count)
                    //{
                    //    // Flag which element matches
                    //    place = i;
                    //}
                    // Need to clear the list or else it continues to grow
                    if (arrList.Count >= tmpList.Count)
                    {
                        int bit = (arrList.Count - tmpList.Count);
                        if (arrList[bit] == '1')
                        {
                            place = i;
                        }
                    }
                    arrList.Clear();

                }
                // Use flag to discount the matching row
                // And perform XOR on remainder to find 
                // value needed to "zero out" the field
                for (int j = 0; j < arr.Length; j++)
                {
                    if (place != j)
                        comp ^= arr[j];
                }

                Console.Out.WriteLine("Computer removes " + (arr[place] - comp) + " stick[s] from pile " + (place + 1));
                char tst = Convert.ToChar(comp);
                arr[place] = tst;
                Console.Out.WriteLine("Press Enter for next turn");
                Console.In.ReadLine();
            }

        }
        //We might want to rebuild the array within this method since we already know the row and replacement.

       //function to choose to go first or second. 
        public bool playerOrder()
        {
            bool choice = true;
            string playerChoice;
            
            Console.Out.WriteLine(" \nWould you like to go first or second? ");
            Console.Out.Write(" (Enter 1 to go first, 2 to go second): ");
            playerChoice = Console.ReadLine();
           
                if (playerChoice == "1")
                {
                    Console.Out.WriteLine(" You have chosen to go first.");
                    choice = true;
                    //Console.Out.WriteLine(choice);
                    return choice;
                }
                else if (playerChoice == "2")
                {
                    Console.Out.WriteLine(" Ok, the computer will go first.");
                    choice = false;
                    //Console.Out.WriteLine(choice);
                    return choice;
                }
                else 
                {
                    Console.Out.WriteLine(" Not a valid choice, you forfeit to the computer going first");
                    choice = false;
                    //Console.Out.WriteLine(choice);
                    return choice;
                }
            
            
        }
        //method for player turn pile choice
        public int choosePile(int[] array)
        {
            string num;
            int pile;
            int length = array.Length;
            Console.Out.Write(" Which pile would you like to take from? ");
            num = Console.ReadLine();
            pile = Convert.ToInt32(num);
            //error check for array length
            if (pile <= length)
                return pile;
            else
            {
                Console.Out.WriteLine(" Invalid choice, ");
                return choosePile(array);
            }
        }
        //method for player turn number of sticks
        public int chooseSticks()
        {
            int sticks;
            string num;
            Console.Out.Write(" How many sticks would you like to take? ");
            num = Console.ReadLine();
            sticks = Convert.ToInt32(num);
            return sticks;
        }

        //method to check game status, checks for winner.
        public bool getWinner(int[] array)
        {            
            foreach(int elements in array)
            {
                
                if (elements != 0)
                {
                    return false;
                }                
            }
            //if all array elements are zero
            return true;
        }
     
    
    


        
        
        
        
        
        
        
        
        
        
        
        //Whitespace to get this out the way, don't think we need this anymore
        /*
        public void buildBin(int[] arr, List<List<int>> list)
        {
            //List<List<int>> list = new List<List<int>>();
            for (int i=0; i < arr.Length; i++)
            {
                List<int> binList = new List<int>();
                string tmpStr = this.decToBin(arr[i]);
                foreach (char ch in tmpStr)
                {
                    int n = (int)Char.GetNumericValue(ch);
                    //list[i].Add(n);
                    //{
                    binList.Add(n);
                }
                //}
                list.Add(binList);
            }
            
        }
        //*************************************
        //*We may not need this method anymore*
        //*************************************
        public void popList(int p,List<List<int>> list, int stk)
        {
            string tmpStr = this.decToBin(stk);
            //Console.Out.WriteLine(tmpStr); // Was to make sure that the binary string conversion was correct.
            //list[p].Remove(0);
            //Console.Out.WriteLine(list[p][1]);
            foreach (char ch in tmpStr)
            {
                //Console.Out.WriteLine("character: " + ch); // Can uncomment to see process if it gets hosed later
                int n = (int)Char.GetNumericValue(ch);
                list[p].Add(n);
                //Console.Out.WriteLine("added: " + list[p][n]);  // Can uncomment to see process if it gets hosed later

            }

        }

        public void showList(List<List<int>> list)
        {
            foreach (var binList in list)
            {
                foreach (var elem in binList)
                {
                    Console.Out.Write(elem + " ");
                }
                Console.Out.WriteLine();
            }
        }
         *  ***Left Steve's first attempt here commented out***
         *  ***in case we can use parts of it               ***
         * //           {

            //    //WHAT I AM ASKING (I know this is not correct)

            //    Console.WriteLine("how many sticks would you like to remove from Pile " + pileNumber
            //        + ":");
            //    numb = Console.ReadLine();
            //    withdraw = Convert.ToInt32(numb);

            //    //foreach (int value in numOfPiles[i] - withdraw)//<-----How would I withdraw from the piles?
            //    //I need to get an int from user and then 
            //    //withdraw from each pile ANY IDEAS?
            //    {
            //        //Console.WriteLine(numOfPiles[i]);
            //    }
            //}
         */

    }
                





}
