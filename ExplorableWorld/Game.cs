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

        private World MyWorld;
        private Player CurrentPlayer;

        public void Start()
        {
            Title = "Welcome to the Maze!";
            CursorVisible = false;

            string[,] grid = {
                { "|" , "|" , "|" , "|" , "|" , "|" , "|" },
                { "|" , " " , "|" , " " , " " , " " , "X" },
                { "O" , " " , "|" , "|" , "|" , " " , "|" },
                { "|" , " " , "|" , "|" , "|" , " " , "|" },
                { "|" , " " , " " , " " , "|" , " " , "|" },
                { "|" , "|" , "|" , "|" , "|" , "|" , "|" },
            };

            MyWorld = new World(grid);

            CurrentPlayer = new Player(0,2);

            

            RunGameLoop();

        }

        private void DisplayIntro()
        {
           WriteLine("Welcome to the maze");
           WriteLine("\nInstructions");
           WriteLine("> Try to each the goal, which looks like this:  ");
           ForegroundColor = ConsoleColor.Green;
           WriteLine("x");
            ResetColor();
           WriteLine("> Press any key to start ");
           ReadKey(true);
        }

        private void DisplayOutro()
        {
            Clear();
            WriteLine("You escaped");
            WriteLine("Thank you for playing ");
            WriteLine(" > Press any key to exit ..... ");
            ReadKey(true);
        }



        private void DrawFrame()
        {
            Clear();
            MyWorld.Draw();
            CurrentPlayer.Draw();
        
        }



        private void HandlePlayerInput()
        { 
            ConsoleKeyInfo keyInfo = ReadKey(true);
            ConsoleKey key = keyInfo.Key;
            switch (key)
            {

                case ConsoleKey.LeftArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X-1,CurrentPlayer.Y))
                    {
                        CurrentPlayer.X -= 1;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X, CurrentPlayer.Y - 1))
                    {
                        CurrentPlayer.Y -= 1;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X+1, CurrentPlayer.Y))
                    {
                        CurrentPlayer.X += 1;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X, CurrentPlayer.Y + 1))
                    {
                        CurrentPlayer.X += 1;

                    }
                    break;
               
                default:
                    break;
            }

        }


        private void RunGameLoop()
        {
            DisplayIntro();
            while (true)
            {
                DrawFrame();

                HandlePlayerInput();
                string elemenyAtPlayerPos = MyWorld.GetElementAt(CurrentPlayer.X, CurrentPlayer.Y);
                if (elemenyAtPlayerPos =="X")
                {
                    break;
                }

                System.Threading.Thread.Sleep(25);

            }
            DisplayOutro();
        }

    }
}
