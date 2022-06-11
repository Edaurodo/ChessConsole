using ChessBoard;
using ChessBoard.Enum;
using Exceptions;

namespace Match
{
    internal class ChessMatch
    {
        public Board ChessBoard { get; private set; }
        public bool Finish { get; private set; }
        public int Turn { get; private set; }
        public PieceColor PlayerColor { get; private set; }

        public ChessMatch()
        {
            ChessBoard = new Board(8, 8);
            Finish = false;
            Turn = 1;
            PlayerColor = PieceColor.White;
            AssemblyMatch();
        }

        public void OriginValidate(BoardPosition origin)
        {
            if (ChessBoard.GetPiece(origin) == null)
            {
                throw new BoardException("Não existe peça no local de origem!");
            }
            if (ChessBoard.GetPiece(origin).Color != PlayerColor)
            {
                throw new BoardException("Você não pode mexer na peça adversaria");
            }
            if (!ChessBoard.GetPiece(origin).HasPossibleMove())
            {
                throw new BoardException("Não existe movimentos para esta peça");
            }
        }
        public void DestinyValidate(BoardPosition origin, BoardPosition destiny)
        {
            if (!ChessBoard.GetPiece(origin).PossibleMove(destiny))
            {
                throw new BoardException("Não é possivel mover para esta possisão");
            }
        }

        public void Move(BoardPosition origin, BoardPosition destiny)
        {
            ExeMoviment(origin, destiny);
            PassTurn();

        }

        private void ExeMoviment(BoardPosition origin, BoardPosition destiny)
        {
            Piece piece = ChessBoard.RemovePiece(origin);
            piece.Movement();
            Piece Captured = ChessBoard.RemovePiece(destiny);
            ChessBoard.AddPiece(piece, destiny);
        }
        private void PassTurn()
        {
            if (PlayerColor == PieceColor.White)
            {
                PlayerColor = PieceColor.Black;
                Turn++;
            }
            else
            {
                PlayerColor = PieceColor.White;
                Turn++;
            }
        }
        private void AssemblyMatch()
        {
            ChessBoard.AddPiece(new Rook(PieceColor.White, ChessBoard), new ChessPosition('a', 1).ToPosition());
            ChessBoard.AddPiece(new Knight(PieceColor.White, ChessBoard), new ChessPosition('b', 1).ToPosition());
            ChessBoard.AddPiece(new Bishop(PieceColor.White, ChessBoard), new ChessPosition('c', 1).ToPosition());
            ChessBoard.AddPiece(new Quenn(PieceColor.White, ChessBoard), new ChessPosition('d', 1).ToPosition());
            ChessBoard.AddPiece(new King(PieceColor.White, ChessBoard), new ChessPosition('e', 1).ToPosition());
            ChessBoard.AddPiece(new Bishop(PieceColor.White, ChessBoard), new ChessPosition('f', 1).ToPosition());
            ChessBoard.AddPiece(new Knight(PieceColor.White, ChessBoard), new ChessPosition('g', 1).ToPosition());
            ChessBoard.AddPiece(new Rook(PieceColor.White, ChessBoard), new ChessPosition('h', 1).ToPosition());
            
            ChessBoard.AddPiece(new WhitePawn(ChessBoard), new ChessPosition('b', 2).ToPosition());
            ChessBoard.AddPiece(new WhitePawn(ChessBoard), new ChessPosition('c', 2).ToPosition());
            ChessBoard.AddPiece(new WhitePawn(ChessBoard), new ChessPosition('d', 2).ToPosition());
            ChessBoard.AddPiece(new WhitePawn(ChessBoard), new ChessPosition('e', 2).ToPosition());
            ChessBoard.AddPiece(new WhitePawn(ChessBoard), new ChessPosition('f', 2).ToPosition());
            ChessBoard.AddPiece(new WhitePawn(ChessBoard), new ChessPosition('g', 2).ToPosition());
            ChessBoard.AddPiece(new WhitePawn(ChessBoard), new ChessPosition('h', 2).ToPosition());

            ChessBoard.AddPiece(new Rook(PieceColor.Black, ChessBoard), new ChessPosition('a', 8).ToPosition());
            ChessBoard.AddPiece(new Knight(PieceColor.Black, ChessBoard), new ChessPosition('b', 8).ToPosition());
            ChessBoard.AddPiece(new Bishop(PieceColor.Black, ChessBoard), new ChessPosition('c', 8).ToPosition());
            ChessBoard.AddPiece(new Quenn(PieceColor.Black, ChessBoard), new ChessPosition('d', 8).ToPosition());
            ChessBoard.AddPiece(new King(PieceColor.Black, ChessBoard), new ChessPosition('e', 8).ToPosition());
            ChessBoard.AddPiece(new Bishop(PieceColor.Black, ChessBoard), new ChessPosition('f', 8).ToPosition());
            ChessBoard.AddPiece(new Knight(PieceColor.Black, ChessBoard), new ChessPosition('g', 8).ToPosition());
            ChessBoard.AddPiece(new Rook(PieceColor.Black, ChessBoard), new ChessPosition('h', 8).ToPosition());
            ChessBoard.AddPiece(new BlackPawn(ChessBoard), new ChessPosition('a', 7).ToPosition());
            ChessBoard.AddPiece(new BlackPawn(ChessBoard), new ChessPosition('b', 7).ToPosition());
            ChessBoard.AddPiece(new BlackPawn(ChessBoard), new ChessPosition('c', 7).ToPosition());
            ChessBoard.AddPiece(new BlackPawn(ChessBoard), new ChessPosition('d', 7).ToPosition());
            ChessBoard.AddPiece(new BlackPawn(ChessBoard), new ChessPosition('e', 7).ToPosition());
            ChessBoard.AddPiece(new BlackPawn(ChessBoard), new ChessPosition('f', 7).ToPosition());
            ChessBoard.AddPiece(new BlackPawn(ChessBoard), new ChessPosition('g', 7).ToPosition());
            ChessBoard.AddPiece(new BlackPawn(ChessBoard), new ChessPosition('h', 7).ToPosition());
        }
    }
}
