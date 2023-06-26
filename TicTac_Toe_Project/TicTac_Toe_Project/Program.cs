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

            // Starting at the top, look down to see how far down gravity will
            // pull it.
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



    }

    public abstract class Controller:FourGame
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

}

