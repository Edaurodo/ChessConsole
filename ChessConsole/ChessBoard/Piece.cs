using ChessBoard.Enum;

namespace ChessBoard
{
    internal abstract class Piece
    {

        public PieceColor Color { get; set; }
        public Board Board { get; set; }
        public BoardPosition Position { get; set; }
        public int Movements { get; set; }

        public Piece(Board board)
        {
            Board = board;
            Position = null;
            Movements = 0;
        }

        public Piece(PieceColor color, Board board)
        {
            Color = color;
            Board = board;
            Position = null;
            Movements = 0;
        }

        public void Movement()
        {
            Movements++;
        }
        public bool HasPossibleMove()
        {
            bool[,] mat = PossibleMoves();
            for(int i = 0; i < mat.GetLength(0); i++)
            {
                for(int j = 0; j < mat.GetLength(1); j++)
                {
                    if(mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool PossibleMove(BoardPosition destiny)
        {
            return PossibleMoves()[destiny.PositionWidth, destiny.PositionHeight];
        }
        public abstract bool[,] PossibleMoves();
        
    }
}
