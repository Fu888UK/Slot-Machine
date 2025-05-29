namespace Slot_Machine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int ONELINE = 1;
            const int TWOLINES = 2;
            const int THREELINES = 3;
            const int THREELINES = 4;
            const int ROW = 3;
            const int COL = 3;

            Console.WriteLine("Welcome to the Slots Machine");
            Console.WriteLine($"Hello, please select the amount you wish to play with, {ONELINE} for $1, {TWOLINES} for $2, {THREELINES} for $3");
            //modes middle, horizontal, diagonal, vertical 
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
            //Console.WriteLine("");
            for (int i = 0; i < ROW; i++)                           //row
            {
                for (int j = 0; j < COL; j++)                       //col
                {
                    Console.Write(grid[i, j] + " ");
                }
                Console.WriteLine();                                //need this in the loop to output like a grid
            }

            //check grid/winnings 

            //incorporate above to ifs below
            //need to calify modes, is this do do with amount of wager, the difficulty of the game, ??????


            //if (selected == 1) 
            //{
            //    for (int i = 0; i < 3; i++) 
            //    {
            //        for (int j = 0; j < 3; j++) 
            //        {
            //            grid[i, j] = (char)('0' + rnd.Next(0, 9));
            //        }
            //    }


            //}
            //if (selected == 2)
            //{


            //}
            //if (selected == 3)
            //{


            //}



        }
    }
}
