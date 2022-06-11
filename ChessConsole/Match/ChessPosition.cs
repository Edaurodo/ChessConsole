using ChessBoard;

namespace Match
{
    internal class ChessPosition
    {
        public int Width { get; set; }
        public char Height { get; set; }

        public ChessPosition(char height, int width)
        {
            Width = width;
            Height = height;
        }

        public BoardPosition ToPosition()
        {
            return new BoardPosition(8 - Width, Height - 'a');
        }

        public override string ToString()
        {
            return $"{Width}, {Height}";
        }
    }
}
