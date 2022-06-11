using Exceptions;

namespace ChessBoard
{
    internal class Board
    {
        public int Width { get; set; }
        public int Height { get; set; }
        private Piece[,] _piece;

        public Board(int width, int height)
        {
            Width = width;
            Height = height;
            _piece = new Piece[width, height];
        }

        public Piece GetPiece(int width, int height)
        {
            return _piece[width, height];
        }

        public Piece GetPiece(BoardPosition position)
        {
            return _piece[position.PositionWidth, position.PositionHeight];
        }

        public bool HasPiece(BoardPosition position)
        {
            ValidatePosition(position);
            return GetPiece(position) != null;
        }

        public void AddPiece(Piece piece, BoardPosition position)
        {
            if (HasPiece(position))
            {
                throw new BoardException("there is already a piece in this house");
            }
                _piece[position.PositionWidth, position.PositionHeight] = piece;
                piece.Position = position;
        }

        public Piece RemovePiece(BoardPosition position) {
            if (!HasPiece(position))
            {
                return null;
            }
            Piece piece = _piece[position.PositionWidth, position.PositionHeight];
            piece.Position = null;
            _piece[position.PositionWidth, position.PositionHeight] = null;
            return piece;
        }

        public bool PositionIsValid(BoardPosition position)
        {
            if(position.PositionWidth < 0 || position.PositionHeight < 0 || position.PositionWidth >= Width || position.PositionHeight >= Height)
            {
                return false;
            }
            return true;
        }

        public void ValidatePosition(BoardPosition position)
        {
            if (!PositionIsValid(position))
            {
                throw new BoardException("Position invalid");
            }
        }
    }
}
