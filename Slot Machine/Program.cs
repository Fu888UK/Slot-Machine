﻿using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace Slot_Machine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int MIDLINE = 1;
            const int HORILINES = 2;
            const int DIAGLINES = 3;
            const int VERTLINES = 4;
            const int ROW = 3;
            const int COL = 3;

            Console.WriteLine("Welcome to the Slots Machine");
            Console.WriteLine($"Please select the mode you wish to play");
            Console.WriteLine($"{MIDLINE} = Middle line");
            Console.WriteLine($"{HORILINES} = Horizontal lines");
            Console.WriteLine($"{DIAGLINES} = Diagonal lines");
            Console.WriteLine($"{VERTLINES} = Verticle line");
            

            string mode = Console.ReadLine();                       

            int selected = int.Parse(mode);                         //convert string to int 
            Console.WriteLine($"You have selected {selected}");

            int[,] grid = new int[ROW,COL];                         //2D array 

            Random rnd = new Random();                       

            //populate grid 
            for (int i = 0; i < ROW; i++)                           //row
            {
                for (int j = 0; j < COL; j++)                       //col
                {
                    grid[i, j] = rnd.Next(0, 5);
                }             
            }
            //print grid
            Console.WriteLine("");

            for (int i = 0; i < ROW; i++)                           //row
            {
                for (int j = 0; j < COL; j++)                       //col
                {
                    Console.Write(grid[i, j] + " ");
                }
                Console.WriteLine();                                //need this in the loop to output like a grid
            }

            //check grid/winnings 
                        
            bool win = false;

            if (selected == MIDLINE)
            {
                //int middleRow = 1;
                if (grid[1,0] == grid[1,1] && grid[1,0] == grid[1,2])
                //if (grid[MIDLINE, 0] == grid[MIDLINE, 1] && grid[MIDLINE, 1] == grid[MIDLINE, 2])
                {
                    win = true;
                    Console.WriteLine("middle row win");
                                        
                }
                               
            }
            if (selected == HORILINES)
            {
                for (int i = 0; i < ROW; i++)                                   //loops through all 3 rows 
                {
                    if (grid[i, 0] == grid[i, 1] && grid[i, 1] == grid[i, 2])   //checking for values are the same
                    {
                        win = true;
                        Console.WriteLine($"You win on horizontal line {i + 1}!");
                    }
                }

            }
            if (selected == DIAGLINES)
            {


            }
            if (selected == VERTLINES)
            {


            }

            if (!win) 
            {
                Console.WriteLine("You lose, good luck with the next try");
            }


        }
    }
}






//for (int i = 0; i < 3; i++)
//{
//    for (int j = 0; j < 3; j++)
//    {
//        grid[i, j] = (char)('0' + rnd.Next(0, 9));
//    }

//}