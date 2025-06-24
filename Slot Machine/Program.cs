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
            const int ROWS = 3;
            const int COLS = 3;
            const int PAYOUT1 = 6;
            const int PAYOUT2 = 0;

            int balance = 50;
            int betAmount = 3;


            Console.WriteLine("Welcome to the Slots Machine");
            Console.WriteLine($"Please select the mode you wish to play");
            Console.WriteLine($"{MIDLINE} = Middle line");
            Console.WriteLine($"{HORILINES} = Horizontal lines");
            Console.WriteLine($"{VERTLINES} = Verticle lines");
            Console.WriteLine($"{DIAGLINES} = Diagonal lines");

            string mode = Console.ReadLine();

            int selectedMode = int.Parse(mode);                         //convert string to int                       

            if (selectedMode > 4)               //if users enters anything apart from 1 2 3 4 need to enter 'if' to fix this, refer to 1st project
            {
                Console.WriteLine("Invalid selection try again");
                return;
            }
            Console.WriteLine($"You have selected {selectedMode}");
            Console.WriteLine($"Your starting balance is {balance}");
            Console.WriteLine($"Your default bet amount is {betAmount}");
                       

            while (balance > 0)
            {
                //Console.WriteLine($"your current balance is {balance}");
                //Console.WriteLine("How much do you want to bet");
                if (betAmount > balance)
                {
                    Console.WriteLine("you do not have enough in your balance for that bet");
                    continue;
                }


                int[,] grid = new int[ROWS, COLS];                         //2D array 

                Random rnd = new Random();

                //create test grid by hard coding
                //int[,] testGrid = new int[3, 3]
                //{
                //    {0,1,2},
                //    {1,1,0},
                //    {0,1,2}
                //};

                //populate grid 
                for (int i = 0; i < ROWS; i++)                           //row
                {
                    for (int j = 0; j < COLS; j++)                       //col
                    {
                        grid[i, j] = rnd.Next(0, 5);
                    }
                }
                //print grid
                Console.WriteLine("");

                for (int i = 0; i < ROWS; i++)                           //row
                {
                    for (int j = 0; j < COLS; j++)                       //col
                    {
                        Console.Write(grid[i, j] + " ");
                    }
                    Console.WriteLine();                                //need this in the loop to output like a grid
                }
                Console.WriteLine();

                bool win = true;                                //check grid/winnings 

                if (selectedMode == MIDLINE)
                {
                    int midRow = ROWS / 2;

                    for (int i = 1; i < COLS; i++)
                    {
                        //check 1,0 against 1,1 and 1,2, if 1,0 and 1,1 is wrong once this is checked then no need to check 1,2
                        if (grid[midRow, 0] != grid[midRow, i]) //&& grid[1, i] == grid[1, i])
                        {
                            win = false;
                            Console.WriteLine("middle row lose");
                            break;
                        }
                    }
                }
                if (selectedMode == HORILINES)
                {
                    for (int i = 0; i < ROWS; i++)                                   //loops through all 3 rows 
                    {
                        for (int j = 0; j < COLS; j++)
                        {
                            if (grid[i, 0] != grid[i, j]) //&& grid[i, 1] == grid[i, 2])   //checking for values are the same                                                   
                            {
                                win = false;
                                Console.WriteLine($"You lose on horizontal line {i + 1}!");
                                break;
                            }
                        }
                    }
                }
                if (selectedMode == VERTLINES)
                {
                    for (int i = 0; i < COLS; i++)                                   //loops through all 3 rows 
                    {
                        for (int j = 0; j < ROWS; j++)
                        {
                            if (grid[j, i] != grid[0, i])         //checking for values are the same                                                   
                            {
                                win = false;
                                Console.WriteLine($"You LOSE on vertical line {i + 1}!");
                                break;
                            }
                        }
                    }
                }
                if (selectedMode == DIAGLINES)              //0,0 1,1 2,2  line i need to find     TOP LEFT TO BOTTOM RIGHT                                         
                {
                    //bool winLine1 = true;
                    for (int i = 0; i < ROWS; i++)                                   //loops through all 3 rows 
                    {
                        if (grid[0, 0] != grid[i, i])                            //checking for values are the same                                                   
                        {
                            win = false;
                            Console.WriteLine("You lose on line 1");
                            break;

                        }
                        //if (win)
                        //{
                        //    Console.WriteLine("You win on line 1");
                        //}
                    }
                    //bool winLine2 = true;
                    for (int i = 0; i < ROWS; i++)             //0,2 1,1 2,0  line i need to find   //TOP RIGHT TO BOTTOM LEFT 
                    {
                        if (grid[0, COLS - 1] != grid[i, ROWS - 1 - i])
                        {
                            win = false;
                            Console.WriteLine("You lose on line 2");
                            break;
                        }
                        //if (win)
                        //{
                        //    Console.WriteLine("You win on line 2");
                        //}
                    }

                }
                else //change to else?
                {
                    Console.WriteLine("You win");
                    Console.WriteLine("You have won??????????");
                    //output winnings, need calculation
                }
                if (balance == 0)
                {
                    Console.WriteLine("Sorry, you do not have any credit left to continue");
                }
                
            }
        }
    }
}





                       
//            if (selectedMode > 4)               //if users enters anything apart from 1 2 3 4 need to enter 'if' to fix this, refer to 1st project
//            {
//                Console.WriteLine("Invalid selection try again");
//                return;
//            }

//            int[,] grid = new int[ROWS,COLS];                         //2D array 

//            Random rnd = new Random();

//            //create test grid by hard coding
//            //int[,] testGrid = new int[3, 3]
//            //{
//            //    {0,1,2},
//            //    {1,1,0},
//            //    {0,1,2}
//            //};

//            //populate grid 
//            for (int i = 0; i < ROWS; i++)                           //row
//            {
//                for (int j = 0; j < COLS; j++)                       //col
//                {
//                    grid[i, j] = rnd.Next(0, 5);
//                }
//            }
//            //print grid
//            Console.WriteLine("");

//            for (int i = 0; i < ROWS; i++)                           //row
//            {
//                for (int j = 0; j < COLS; j++)                       //col
//                {
//                    Console.Write(grid[i, j] + " ");
//                }
//                Console.WriteLine();                                //need this in the loop to output like a grid
//            }
//            Console.WriteLine();                       

//            bool win = true;                                //check grid/winnings 

//            if (selectedMode == MIDLINE)
//            {                                        
//                int midRow = ROWS / 2;

//                for (int i = 1; i < COLS; i++)
//                {                 
//                    //check 1,0 against 1,1 and 1,2, if 1,0 and 1,1 is wrong once this is checked then no need to check 1,2
//                    if (grid[midRow, 0] != grid[midRow, i]) //&& grid[1, i] == grid[1, i])
//                    {
//                        win = false;
//                        Console.WriteLine("middle row lose");
//                        break;
//                    }                    
//                }                
//            }
//            if (selectedMode == HORILINES)
//            {
//                for (int i = 0; i < ROWS; i++)                                   //loops through all 3 rows 
//                {
//                    for (int j = 0; j < COLS; j++) 
//                    {
//                        if (grid[i, 0] != grid[i, j]) //&& grid[i, 1] == grid[i, 2])   //checking for values are the same                                                   
//                        {
//                            win = false;
//                            Console.WriteLine($"You lose on horizontal line {i + 1}!");
//                            break;
//                        }                    
//                    }                    
//                }                
//            }
//            if (selectedMode == VERTLINES)
//            {
//                for (int i = 0; i < COLS; i++)                                   //loops through all 3 rows 
//                {
//                    for (int j = 0; j < ROWS; j++) 
//                    {                        
//                        if (grid[j, i] != grid[0, i])         //checking for values are the same                                                   
//                        {
//                            win = false;
//                            Console.WriteLine($"You LOSE on vertical line {i + 1}!");
//                            break;
//                        }                        
//                    }                        
//                }               
//            }
//            if (selectedMode == DIAGLINES)              //0,0 1,1 2,2  line i need to find     TOP LEFT TO BOTTOM RIGHT                                         
//            {
//                //bool winLine1 = true;
//                for (int i = 0; i < ROWS; i++)                                   //loops through all 3 rows 
//                {                    
//                    if (grid[0, 0] != grid[i, i])                            //checking for values are the same                                                   
//                    {
//                        win = false;                        
//                        Console.WriteLine("You lose on line 1");
//                        break;

//                    }
//                    //if (win)
//                    //{
//                    //    Console.WriteLine("You win on line 1");
//                    //}
//                }
//                //bool winLine2 = true;
//                for (int i = 0; i < ROWS; i++)             //0,2 1,1 2,0  line i need to find   //TOP RIGHT TO BOTTOM LEFT 
//                {
//                    if (grid[0, COLS - 1] != grid[i, ROWS - 1 - i])    
//                    {
//                        win = false;
//                        Console.WriteLine("You lose on line 2");
//                        break;
//                    }
//                    //if (win)
//                    //{
//                    //    Console.WriteLine("You win on line 2");
//                    //}
//                }

//            }
//            else //change to else?
//            {
//                Console.WriteLine("You win");
//                Console.WriteLine("You have won??????????");
//                //output winnings, need calculation
//            }                        
//        }
//    }
//}

//need to add bet amount/how many lines 

//MODE 4 win line 2 
//START 0,2 or 0,COLS-1, (COLS wwhich is set to 3 -1 = 2)
//CURRENT ROW - [i, COLS(3) - 2 (=1) (-i)] (i is the current row index in the loop)
//            - [i, COL(3)] - 3 (=0)] (-i)] 
//[i, ROWS -1 -i]
//0,2 1,1 2,0  line i need to find   //TOP RIGHT TO BOTTOM LEFT 
//0,2 top right corner - 1,1 centre - 2,0 bottom left corner
//if (grid[0, COLS - 1] != grid[i, COLS - 1 - i])


// add for loop to make it dynamic      // need to modify win check conditons so they work for any size grid 
//check for losing try



//int midRow = ROWS / 2;
//bool midLineWin = true;
//for (int j = 1; j < COLS; j++)
//{
//    if (grid[midRow, j] != grid[midRow, 0])
//    {
//        midLineWin = false;
//        break;
//    }
//}
//if (midLineWin)
//{
//    win = true;
//    Console.WriteLine($"Middle row {midRow + 1} win!");
//}



//for (int i = 0; i < 3; i++)
//{
//    for (int j = 0; j < 3; j++)
//    {
//        grid[i, j] = (char)('0' + rnd.Next(0, 9));
//    }

//}