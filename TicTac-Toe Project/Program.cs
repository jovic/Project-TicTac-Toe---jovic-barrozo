using System;
using System.Collections.Generic;
using TicTac_Toe_Project;

namespace TicTac_Toe_Project
{
    internal class Program
    {
        public string Name { get; set; }
        public int Score { get; set; }
        private static List<GuessingGame> _playersList;
        private static int count;


        public class Controller
        {
            _playersList = new List<GuessingGame>();
            count = 0;
        }

        public class Controller(string playerName)
        {
            Name = playerName;
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

    //public class Board
    //{
    //    public Board(int width, int height)
    //    {
    //        for (int i = 0; i < height; i++)
    //        {
    //            Console.Write("|\t");
    //            for (int j = 0; j < width; j++)
    //            {
    //                Console.WriteLine("j\t");
    //            }
    //            Console.WriteLine("|");
    //        }
    //    }
               
    //}
    static void Main(string[] args)
        {
            Console.WriteLine("Hello World!\t");
            //var boardObj = new Board(7, 6);
        }
    }
}
