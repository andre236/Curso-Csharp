using XadrezProject.xadrez;
using XadrezProject.Tabuleiro;

namespace XadrezProject
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                GameXadrez gameXadrez = new GameXadrez();

                while (!gameXadrez.EndGame)
                {
                    try
                    {
                        Console.Clear();
                        Screen.PrintGameXadrez(gameXadrez);
                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Position origin = Screen.ReadPositionXadrez().ToPosition();
                        gameXadrez.ValidateOriginPosition(origin);

                        bool[,] possiblePositions = gameXadrez.Tab.piece(origin).PossibleMovements();

                        Console.Clear();
                        Console.WriteLine();
                        Screen.PrintTable(gameXadrez.Tab, possiblePositions);

                        Console.Write("Destino: ");
                        Position destiny = Screen.ReadPositionXadrez().ToPosition();
                        gameXadrez.ValidateDestinyPosition(origin, destiny);

                        gameXadrez.DoingMovement(origin, destiny);
                    }
                    catch(TableExceptions te)
                    {
                        Console.WriteLine(te.Message);
                        Console.ReadLine();
                    }
                }

            }
            catch(TableExceptions te)
            {
                Console.WriteLine(te.Message);
            }
            
        }
    }
}