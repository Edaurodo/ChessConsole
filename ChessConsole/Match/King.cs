using ChessBoard;
using ChessBoard.Enum;

namespace Match
{
    internal class King : Piece
    {
        public King(PieceColor color, Board board) : base(color, board)
        {

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
                for(int y = 0; y < Board.Height; y++)
                {
                    mat[x, y] = false;
                }
            }
            BoardPosition position = new BoardPosition(0, 0);

            //up
            position.SetPosition(Position.PositionWidth - 1, Position.PositionHeight);
            if (Board.PositionIsValid(position) && CanMove(position))
            {
                mat[position.PositionWidth, position.PositionHeight] = true;
            }

            //down
            position.SetPosition(Position.PositionWidth + 1, Position.PositionHeight);
            if (Board.PositionIsValid(position) && CanMove(position))
            {
                mat[position.PositionWidth, position.PositionHeight] = true;
            }

            //left
            position.SetPosition(Position.PositionWidth, Position.PositionHeight - 1);
            if (Board.PositionIsValid(position) && CanMove(position))
            {
                mat[position.PositionWidth, position.PositionHeight] = true;
            }

            //right
            position.SetPosition(Position.PositionWidth, Position.PositionHeight + 1);
            if (Board.PositionIsValid(position) && CanMove(position))
            {
                mat[position.PositionWidth, position.PositionHeight] = true;
            }

            //left-up
            position.SetPosition(Position.PositionWidth - 1, Position.PositionHeight - 1);
            if (Board.PositionIsValid(position) && CanMove(position))
            {
                mat[position.PositionWidth, position.PositionHeight] = true;
            }

            //right-up
            position.SetPosition(Position.PositionWidth - 1, Position.PositionHeight + 1);
            if (Board.PositionIsValid(position) && CanMove(position))
            {
                mat[position.PositionWidth, position.PositionHeight] = true;
            }

            //left-down
            position.SetPosition(Position.PositionWidth + 1, Position.PositionHeight - 1);
            if (Board.PositionIsValid(position) && CanMove(position))
            {
                mat[position.PositionWidth, position.PositionHeight] = true;
            }

            //right-down
            position.SetPosition(Position.PositionWidth + 1, Position.PositionHeight + 1);
            if (Board.PositionIsValid(position) && CanMove(position))
            {
                mat[position.PositionWidth, position.PositionHeight] = true;
            }
            return mat;
        }

        public override string ToString()
        {
            return "K";
        }
    }
}
