using System;

using ChessBoard;
using Match;
using Exceptions;

namespace ChessConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessMatch match = new ChessMatch();
                while (!match.Finish)
                {
                    try
                    {
                        Console.Clear();

                        ScreenAssembly.PrintBoard(match.ChessBoard);
                        Console.WriteLine();

                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.Write($"TURNO: ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine(match.Turn);
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.Write("JOGADOR ATUAL: ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine(match.PlayerColor);
                        Console.WriteLine();


                        Console.Write("Posição de origem: ");
                        BoardPosition origem = ScreenAssembly.CapturePlayed().ToPosition();
                        match.OriginValidate(origem);
                        Console.Clear();
                        bool[,] posibleMoves = match.ChessBoard.GetPiece(origem).PossibleMoves();
                        ScreenAssembly.PrintBoard(match.ChessBoard, posibleMoves);
                        Console.WriteLine();

                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.Write($"TURNO: ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine(match.Turn);
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.Write("JOGADOR ATUAL: ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine(match.PlayerColor);
                        Console.WriteLine();

                        Console.Write("Posição de destino: ");
                        BoardPosition destino = ScreenAssembly.CapturePlayed().ToPosition();
                        match.DestinyValidate(origem, destino);
                        match.Move(origem, destino);
                    }
                    catch(BoardException e)
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(e.Message);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.ReadLine();
                    }
                }

            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
