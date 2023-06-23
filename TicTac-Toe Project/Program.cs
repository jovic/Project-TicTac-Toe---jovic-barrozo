using System;
using System.Collections.Generic;

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

        abstract class Player
        {

        }
        public class HumanPlayer 
        { 
        
        }

        public class ComupterPlayer
        {

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
