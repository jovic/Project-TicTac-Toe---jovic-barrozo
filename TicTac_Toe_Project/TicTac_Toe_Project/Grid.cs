
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using TicTac_Toe_Project;

namespace TicTac_Toe_Project

{
    public class Grid
    {
        public PieceEnum?[,] Pieces { get; protected set; }

        public Grid(int c, int r)
        {
            Pieces = new PieceEnum?[c, r];
        }

    }
}