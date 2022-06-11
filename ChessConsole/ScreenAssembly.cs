using ChessBoard;
using ChessBoard.Enum;
using Match;
using System;

namespace ChessConsole
{
    static class ScreenAssembly
    {
        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Height; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{board.Width - i} ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("| ");
                for (int j = 0; j < board.Width; j++)
                {
                    PrintPiece(board.GetPiece(i, j));
                }
                Console.WriteLine();
            }
            Console.Write("++| ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("A B C D E F G H");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void PrintBoard(Board board, bool[,] possibleMoves)
        {
            for (int i = 0; i < board.Height; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{board.Width - i} ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("| ");
                for (int j = 0; j < board.Width; j++)
                {
                    if (possibleMoves[i, j])
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    PrintPiece(board.GetPiece(i, j));
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("++| ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("A B C D E F G H");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void PrintPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.Color == PieceColor.White)
                {
                    Console.Write(piece + " ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(piece + " ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
        }

        public static void PrintInfo()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            

        }

        public static ChessPosition CapturePlayed()
        {
            string played = Console.ReadLine().ToLower();
            char height = played[0];
            int width = int.Parse(played[1] + "");
            return new ChessPosition(height, width);
        }
    }
}
