using ChessBoard;
using ChessBoard.Enum;

namespace Match
{
    internal class WhitePawn : Piece
    {
        public WhitePawn(Board board) : base(board)
        {
            Color = PieceColor.White;
        }

        private bool CanMove(BoardPosition position)
        {
            Piece piece = Board.GetPiece(position);
            return piece == null || piece.Color != Color;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Board.Width, Board.Height];
            for (int x = 0; x < Board.Width; x++)
            {
                for (int y = 0; y < Board.Height; y++)
                {
                    mat[x, y] = false;
                }
            }
            BoardPosition position = new BoardPosition(0, 0);

            
            if(Movements != 0)
            {
                //up
                position.SetPosition(Position.PositionWidth - 1, Position.PositionHeight);
                if (Board.PositionIsValid(position) && Board.HasPiece(position) == false)
                {
                    mat[position.PositionWidth, position.PositionHeight] = true;
                }
                //up-left
                position.SetPosition(Position.PositionWidth - 1, Position.PositionHeight - 1);
                if (Board.PositionIsValid(position) && CanMove(position))
                {
                    mat[position.PositionWidth, position.PositionHeight] = true;
                }
                //up-right
                position.SetPosition(Position.PositionWidth - 1, Position.PositionHeight + 1);
                if (Board.PositionIsValid(position) && CanMove(position))
                {
                    mat[position.PositionWidth, position.PositionHeight] = true;
                }
            }


            return mat;
        }

        public override string ToString()
        {
            return "P";
        }
    }
}