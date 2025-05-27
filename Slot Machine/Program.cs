namespace Slot_Machine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int ONELINE = 1;
            const int TWOLINES = 2;
            const int THREELINES = 3;
            const int ROW = 3;
            const int COL = 3;


            Console.WriteLine($"Hello, please select the amount you wish to play with, {ONELINE} for $1, {TWOLINES} for $2, {THREELINES} for $3");
            string wager = Console.ReadLine();

            Console.WriteLine($"You have selected {wager}");

            int selected = int.Parse(wager);

            int[,] grid = new int[ROW,COL];

            Random rnd = new Random();

            if (selected == 1) 
            {
                for (int i = 0; i < grid.GetLength(0); i++) 
                {
                    for (int j = 0; j < grid.GetLength(1); j++) 
                    {
                        grid[i, j] = (char)('0' + rnd.Next(0, 9));
                    }
                }


            }
            if (selected == 2)
            {


            }
            if (selected == 3)
            {


            }



        }
    }
}
