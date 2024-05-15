using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Game2048
{
    public class ConsoleGame
    {
        public int MaxScore { get; protected set; }
        private Game _game;


        private Dictionary<int, ConsoleColor> _colors = new Dictionary<int, ConsoleColor>{
                                  {2, ConsoleColor.Blue},
                                  {4, ConsoleColor.Cyan},
                                {8, ConsoleColor.DarkBlue},
                                {16, ConsoleColor.DarkCyan},
                                {32, ConsoleColor.DarkGreen},
                                {64, ConsoleColor.DarkMagenta},
                                {128, ConsoleColor.Cyan},
                                {256, ConsoleColor.DarkGreen},
                                {512, ConsoleColor.Blue},
                                {1024, ConsoleColor.DarkGreen},
                                {2048, ConsoleColor.Green} };

        public ConsoleGame()
        {
            MaxScore = 0;
        }

        public void RunGame()
        {
            char newGame = 'Y';
            while (newGame.Equals('Y'))
            {
                _game = new Game();
                PrintBoard();

                while (_game.Status.Equals(GameStatus.Idle))
                {
                    Direction currentMove = GetMoveFromUser();
                    _game.Move(currentMove);
                    PrintBoard();
                }

                if (_game.Points > MaxScore)
                    MaxScore = _game.Points;

                PrintStatusMessage();
                newGame = AskForNewGame();
            }
        }

        private Direction GetMoveFromUser()
        {
            Console.Write("Press the arrows buttons to make a move ");
            ConsoleKeyInfo key = Console.ReadKey();
            while(key.Key != ConsoleKey.RightArrow && key.Key != ConsoleKey.LeftArrow && key.Key != ConsoleKey.UpArrow && key.Key != ConsoleKey.DownArrow)
            {
                Console.WriteLine("");
                Console.Write("Press the arrows buttons to make a move ");
                key = Console.ReadKey();
            }

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    return Direction.Top;

                case ConsoleKey.DownArrow:
                    return Direction.Bottom;

                case ConsoleKey.RightArrow:
                    return Direction.Right;

                case ConsoleKey.LeftArrow:
                    return Direction.Left;
            }

            // it'll never come to that. it's just a default return value
            return Direction.Top;
        }

        private void PrintBoard()
        {
            Console.Clear();
            for(int i = 0; i < 4; i ++)
            {
                for(int j = 0; j < 4; j++)
                {
                    if (_game.GameBoard.Data[i, j].Equals(0))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("-\t");
                    }
                    else
                    {
                        Console.ForegroundColor = _colors[_game.GameBoard.Data[i, j]];
                        Console.Write($"{_game.GameBoard.Data[i, j]}\t");
                    }
                    Console.ResetColor();
                }
                Console.WriteLine("");
            }
            Console.WriteLine(" ");
        }

        private char AskForNewGame()
        {
            Console.Write("Enter Y/N. Y = new game. N = end it: ");
            string input = Console.ReadLine().ToUpper();
            while(input == null || !input.Equals("Y") && !input.Equals("N"))
            {
                Console.Write("Enter Y/N. Y = new game. N = end it: ");
                input = Console.ReadLine().ToUpper();
            }

            return char.Parse(input);
        }

        private void PrintStatusMessage()
        {
            switch (_game.Status)
            {
                case GameStatus.Lost:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"You gained {_game.Points} points in this game. the Max is {MaxScore}.");
                    Console.WriteLine("You Lost!");
                    break;

                case GameStatus.Win:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"You gained {_game.Points} points in this game. the Max is {MaxScore}.");
                    Console.WriteLine("Congratulations, you won!");
                    break;
            }
            Console.ResetColor();
        }
    }
}
