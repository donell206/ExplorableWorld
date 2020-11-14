using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ExplorableWorld
{
    class Game
    {

        private World MyWOorld

        public void Start()
        {

            //SetCursorPosition(15, 10);
            //Write("X");

            string[,] grid = {
                { "=" , "=" , "=" , "=" , "=" , "=" , "=" },
                { "=" , " " , "=" , " " , " " , " " , "X" },
                { "O" , " " , "=" , "=" , "=" , " " , "=" },
                { "=" , " " , "=" , "=" , "=" , " " , "=" },
                { "=" , " " , " " , " " , "=" , " " , "=" },
                { "=" , "=" , "=" , "=" , "=" , "=" , "=" },
            };

            World myWorld = new World(grid);
            myWorld.Draw();

            Player currentPlayer = new Player(0,2);
            currentPlayer.Draw();

            Console.WriteLine("\n\nPress any key to exit.......");

            ReadKey(true);

        }


        private void RunGameLoop()

    }
}
