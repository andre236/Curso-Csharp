using System;
using System.Collections.Generic;
using XadrezProject;
using XadrezProject.xadrez;
using XadrezProject.Tabuleiro;

namespace XadrezProject
{
    class Screen
    {

        public static void PrintGameXadrez(GameXadrez game)
        {
            PrintTable(game.Tab);
            Console.WriteLine();
            PrintCapturedPieces(game);
            Console.WriteLine();
            Console.WriteLine("Turno: " + game.Turn);
            Console.WriteLine("Aguardando a jogada de: " + game.CurrentPlayer);
            if (game.Check)
            {
                Console.WriteLine("XEQUE!");
            }
        }

        public static void PrintCapturedPieces(GameXadrez game)
        {
            Console.WriteLine("Peças capturadas: ");
            Console.WriteLine("Brancas: ");
            PrintSet(game.CapturedPieces(Color.White));
            Console.WriteLine();
            Console.WriteLine("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintSet(game.CapturedPieces(Color.Black));
            Console.ForegroundColor = aux;
            Console.WriteLine();

        }

        public static void PrintSet(HashSet<Piece> set)
        {
            Console.Write("[");
            foreach (Piece x in set)
            {
                Console.Write(x + " ");

            }
            Console.Write("]");
        }

        public static void PrintTable(Table tab)
        {
            for (int i = 0; i < tab.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Columns; j++)
                {
                    PrintPiece(tab.piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static void PrintTable(Table tab, bool[,] possiblePositions)
        {

            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor newBackground = ConsoleColor.DarkGray;

            for (int i = 0; i < tab.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Columns; j++)
                {
                    if(possiblePositions[i, j])
                    {
                        Console.BackgroundColor = newBackground;
                    }
                    else
                    {
                        Console.BackgroundColor = originalBackground;
                    }
                    
                    PrintPiece(tab.piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
            Console.BackgroundColor = originalBackground;
        }

        public static PositionXadrez ReadPositionXadrez()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");
            return new PositionXadrez(column, line);
        }


        public static void PrintPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.Color == Color.White)
                {
                    Console.Write(piece);
                }
                else
                {
                    ConsoleColor standardColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = standardColor;
                }
                Console.Write(" ");
            }


        }
    }
}
