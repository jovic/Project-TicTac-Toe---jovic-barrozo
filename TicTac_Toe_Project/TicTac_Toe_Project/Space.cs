using System;
using System.Collections.Generic;
using TicTac_Toe_Project;

namespace FourGame_Project
{
    public class Space
    {
        public PieceEnum? Piece { get; protected set; }

        public void SetPiece(PieceEnum piece)
        {
            Piece = piece;
        }
    }
}