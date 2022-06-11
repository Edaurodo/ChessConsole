using ChessBoard;
using ChessBoard.Enum;

namespace Match
{
    internal class Bishop : Piece
    {
        public Bishop(PieceColor color, Board board) : base(color, board)
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
                for (int y = 0; y < Board.Height; y++)
                {
                    mat[x, y] = false;
                }
            }
            BoardPosition position = new BoardPosition(0, 0);

            //up-left
            position.SetPosition(Position.PositionWidth - 1, Position.PositionHeight - 1);
            while (Board.PositionIsValid(position) && CanMove(position))
            {
                mat[position.PositionWidth, position.PositionHeight] = true;
                if (Board.GetPiece(position) != null && Board.GetPiece(position).Color != Color)
                {
                    break;
                }
                position.PositionWidth -= 1;
                position.PositionHeight -= 1;

            }

            //up-rigth
            position.SetPosition(Position.PositionWidth - 1, Position.PositionHeight + 1);
            while (Board.PositionIsValid(position) && CanMove(position))
            {
                mat[position.PositionWidth, position.PositionHeight] = true;
                if (Board.GetPiece(position) != null && Board.GetPiece(position).Color != Color)
                {
                    break;
                }
                position.PositionWidth -= 1;
                position.PositionHeight += 1;

            }

            //down-left
            position.SetPosition(Position.PositionWidth + 1, Position.PositionHeight - 1);
            while (Board.PositionIsValid(position) && CanMove(position))
            {
                mat[position.PositionWidth, position.PositionHeight] = true;
                if (Board.GetPiece(position) != null && Board.GetPiece(position).Color != Color)
                {
                    break;
                }
                position.PositionWidth += 1;
                position.PositionHeight -= 1;

            }

            //down-right
            position.SetPosition(Position.PositionWidth + 1, Position.PositionHeight + 1);
            while (Board.PositionIsValid(position) && CanMove(position))
            {
                mat[position.PositionWidth, position.PositionHeight] = true;
                if (Board.GetPiece(position) != null && Board.GetPiece(position).Color != Color)
                {
                    break;
                }
                position.PositionWidth += 1;
                position.PositionHeight += 1;

            }
            return mat;
        }

        public override string ToString()
        {
            return "B";
        }
    }
}