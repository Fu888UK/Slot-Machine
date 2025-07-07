using System.Data;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace Slot_Machine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int MIDLINE = 1;
            const int HORILINES = 2;
            const int VERTLINES = 3;
            const int DIAGLINES = 4;
            const int INVALID = 4;
            const int ROWS = 3;
            const int COLS = 3;
            const int PAYOUT = 3;
            const int GRID_MAX = 5;
            const int GRID_MIN = 0;
            const int INT_BALANCE = 50;
            const int BET_AMOUNT = 3;
            int balance = INT_BALANCE;   
            int betAmmount = BET_AMOUNT;

            Console.WriteLine("Welcome to the Slots Machine");
            Console.WriteLine($"Please select the mode you wish to play");
            Console.WriteLine($"{MIDLINE} = Middle line");
            Console.WriteLine($"{HORILINES} = Horizontal lines");
            Console.WriteLine($"{VERTLINES} = Verticle lines");
            Console.WriteLine($"{DIAGLINES} = Diagonal lines");

            Console.WriteLine($"Your starting balance is {balance}");
            Console.WriteLine($"Your default bet amount is {BET_AMOUNT}");

            Random rnd = new Random();

            while (balance > 0)
            {
                string mode = Console.ReadLine();
                int selectedMode = 0;
                while ((!int.TryParse(mode, out selectedMode)))
                {
                    Console.WriteLine("Please enter a valid option");
                    mode = Console.ReadLine();
                }

                if (selectedMode > INVALID)
                {
                    Console.WriteLine("Invalid selection please try again with a valid selection");
                    continue;
                }
                Console.WriteLine($"You have selected {selectedMode}");
                balance = balance - BET_AMOUNT;  
                Console.WriteLine($"Your balance is now {balance}");

                if (BET_AMOUNT > balance)
                {
                    Console.WriteLine("you do not have enough in your balance for that bet");
                    return;
                }
                int[,] grid = new int[ROWS, COLS];                         

                for (int i = 0; i < ROWS; i++)                           
                {
                    for (int j = 0; j < COLS; j++)                      
                    {
                        grid[i, j] = rnd.Next(GRID_MIN, GRID_MAX);
                    }
                }                
                Console.WriteLine("");

                for (int i = 0; i < ROWS; i++)                           
                {
                    for (int j = 0; j < COLS; j++)                       
                    {
                        Console.Write(grid[i, j] + " ");
                    }
                    Console.WriteLine();                                
                }
                Console.WriteLine();

                bool win = true;                                

                if (selectedMode == MIDLINE)
                {
                    int midRow = ROWS / 2;

                    for (int i = 1; i < COLS; i++)
                    {                        
                        if (grid[midRow, 0] != grid[midRow, i]) 
                        {
                            win = false;
                            Console.WriteLine("middle row lose");                                                     
                            break;
                        }
                    }
                }
                if (selectedMode == HORILINES)
                {
                    for (int i = 0; i < ROWS; i++)                                   
                    {
                        for (int j = 0; j < COLS; j++)
                        {
                            if (grid[i, 0] != grid[i, j])                                                   
                            {
                                win = false;
                                Console.WriteLine($"You lose on horizontal line {i + 1}!");
                                break;
                                Console.WriteLine("Please select a mode for your next spin");
                            }
                        }
                    }
                }
                if (selectedMode == VERTLINES)
                {
                    for (int i = 0; i < COLS; i++)                                   
                    {
                        for (int j = 0; j < ROWS; j++)
                        {
                            if (grid[j, i] != grid[0, i])                                                           
                            {
                                win = false;
                                Console.WriteLine($"You LOSE on vertical line {i + 1}!");
                                break;
                            }
                        }
                    }
                }
                if (selectedMode == DIAGLINES)                                                     
                {                    
                    for (int i = 0; i < ROWS; i++)                                    
                    {
                        if (grid[0, 0] != grid[i, i])                                                                             
                        {
                            win = false;
                            Console.WriteLine("You lose on line 1");
                            break;
                        }
                    }                    
                    for (int i = 0; i < ROWS; i++)             
                    {
                        if (grid[0, COLS - 1] != grid[i, ROWS - 1 - i])
                        {
                            win = false;
                            Console.WriteLine("You lose on line 2");
                            break;
                        }
                    }
                }               

                if (win)                    
                {
                    int winnings = BET_AMOUNT + PAYOUT;
                    balance = balance + winnings;                                      
                    Console.WriteLine($"YOU WIN,you have won £{PAYOUT}, your new balance is £{balance}");
                    return;
                }
                if (balance == 0)
                {
                    Console.WriteLine("Sorry, you do not have any credit left to continue");
                    break;
                }

            }
        }
    }
}



