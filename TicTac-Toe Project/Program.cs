using System;
using System.Collections.Generic;
using TicTac_Toe_Project.FourGame;

namespace TicTac_Toe_Project
{
    public class FourGame
    {
        public string Name { get; set; }
        public int Score { get; set; }
        private static List<FourGame> _playersList;
        private static int count;

        static FourGame()
        {
            _playersList = new List<FourGame>();
            count = 0;
        }
        public FourGame()
        {

        }

        public FourGame(string name)
        {
            Name = name;
            Score = 0;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Score: {Score}.";
        }


        abstract class Player
        {

        }
        public class HumanPlayer
        {

        }

        public class ComupterPlayer
        {

        }

        public class Board
        {
            public Board()
            {

            }
            public Board(int width, int height)
            {
                for (int i = 0; i < height; i++)
                {
                    Console.Write("| ");
                    for (int j = 0; j < width; j++)
                    {
                        Console.Write($"# ");
                    }
                    Console.WriteLine("|");
                }
                for (int i = 0; i < 1; i++)
                {
                    Console.Write("  ");
                    for (int j = 1; j <= width; j++)
                    {
                        Console.Write($"{j} ");
                    }
                    Console.WriteLine(" ");
                }
            }

        }
    }




    internal class Program
    {



        static void Main(string[] args)
        {
            Console.WriteLine("\nConnect 4 Game Development Project:\n");
            var boardObj = new Board(7, 6);

        }
    }
}
