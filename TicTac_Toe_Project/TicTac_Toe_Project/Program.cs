using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Xml.Linq;


namespace TicTac_Toe_Project

{
    public enum PlayerToken
    {
        //Player 1 token or character
        X,
        //Player 2 token or character
        O,
        //Empty Spaces
        E
    }
    public class FourGame
    {
        //Board number of rows.
        public static readonly int Rows = 6;

        //Board number of columns.
        public static readonly int Columns = 7;

        // Stores players token to the board.
        private PlayerToken[,] Board;

        public string player1Name { get; set; }
        public string player2Name { get; set; }
        //Initialize Board with empty values
        public FourGame()
        {
            Board = new PlayerToken[Rows, Columns];
            CreateEmptyGBoard();
        }

        // Fills the board with empty values.
        private void CreateEmptyGBoard()
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int column = 0; column < Columns; column++)
                {
                    Board[row, column] = PlayerToken.E;
                }
            }
        }

        // Creates complete board to the console window.
        public void CreateBoard()
        {
            for (int row = 0; row < Rows; row++)
            {
                Console.Write(" | ");
                for (int column = 0; column < Columns; column++)
                {
                    PlayerToken type = Board[row, column];
                    switch (type)
                    {
                        case PlayerToken.E:
                            Console.Write(" # ");
                            break;
                        case PlayerToken.X:
                            Console.Write(" X ");
                            break;
                        case PlayerToken.O:
                            Console.Write(" O ");
                            break;
                    }
                }

                Console.WriteLine(" |");
            }

            Console.Write("   ");
            for (int columns = 1; columns <= Columns; columns++)
            {
                Console.Write($" {columns} ");
            }
            Console.WriteLine("\n");
        }

        /// Adds the given token to the column given.
        public void Add(int column, PlayerToken playerToken)
        {
            // If it is full, give up.
            if (!CanAdd(column)) { return; }

            // Starting at the top, look down to see how far down gravity will pull it.
            int currentRow = 0;
            while (currentRow < Rows - 1 &&
                Board[currentRow + 1, column] == PlayerToken.E)
            {
                currentRow++;
            }

            //place the current token.
            Board[currentRow, column] = playerToken;
        }

        // Determines if a token can be added to the top of the given row.
        public bool CanAdd(int column)
        {
            if (Board[0, column] == PlayerToken.E) { return true; }
            else { return false; }
        }

        // Determines if the board is full. 
        //The last token placed may have completed four in a row for one player or another.
        public bool IsFull()
        {
            for (int column = 0; column < Columns; column++)
            {
                if (CanAdd(column)) { return false; }
            }

            return true;
        }

        // Check diagonally up if player wins
        private bool CheckDiagonallyUp(int row, int column, PlayerToken type)
        {
            // If there aren't even four more spots before leaving the board
            if (row - 3 < 0) { return false; }
            if (column + 3 >= Columns) { return false; }

            for (int distance = 0; distance < 4; distance++)
            {
                if (Board[row - distance, column + distance] != type) { return false; }
            }

            return true;
        }

        // Check diagonally down if player wins
        private bool CheckDiagonallyDown(int row, int column, PlayerToken type)
        {
            // If there aren't even four more spots before leaving the grid.
            if (row + 3 >= Rows) { return false; }
            if (column + 3 >= Columns) { return false; }

            for (int distance = 0; distance < 4; distance++)
            {
                if (Board[row + distance, column + distance] != type) { return false; }
            }

            return true;
        }

        // Check vertically up if player wins
        private bool CheckVertically(int row, int column, PlayerToken type)
        {
            // If there aren't even four more spots before leaving the grid,
            // we know it can't be.
            if (row + 3 >= Rows) { return false; }

            for (int distance = 0; distance < 4; distance++)
            {
                if (Board[row + distance, column] != type) { return false; }
            }

            return true;
        }

        // Check horizontally if player wins
        private bool CheckHorizontally(int row, int column, PlayerToken type)
        {
            // If there aren't even four more spots before leaving the grid,
            // we know it can't be.
            if (column + 3 >= Columns) { return false; }

            for (int distance = 0; distance < 4; distance++)
            {
                if (Board[row, column + distance] != type) { return false; }
            }

            return true;
        }

        // Figures out if a particular player, identified by that player's token type, has won the game yet.

        public bool HasWon(PlayerToken type)
        {
            // Use the Check methods created above if the player has won.
            for (int row = 0; row < Rows; row++)
            {
                for (int column = 0; column < Columns; column++)
                {
                    if (CheckVertically(row, column, type)) { return true; }
                    if (CheckHorizontally(row, column, type)) { return true; }
                    if (CheckDiagonallyDown(row, column, type)) { return true; }
                    if (CheckDiagonallyUp(row, column, type)) { return true; }
                }
            }

            return false;
        }

    }

    public abstract class Controller : FourGame
    {
        public int Score { get; set; }
        public string playerName { get; set; }
        public Controller(string player)
        {
            playerName = player;
        }

        public void playerMove(int playermove, PlayerToken playerToken)
        {
            if (CanAdd(playermove))
                Add(playermove, playerToken);
        }

        public override string ToString()
        {
            return $"Name: {playerName}";
        }
    }

    public class Player
    {
        public FourGame game;
        public Player(string playerName)
        {
            game.player1Name = playerName;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Player 1 name: ");
            string pl1=Console.ReadLine();

            Console.WriteLine("Enter Player 2 name: ");
            string pl2 = Console.ReadLine();

            FourGame game = new FourGame();


        }
    }
}

