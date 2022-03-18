namespace XadrezProject.Tabuleiro
{
    abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; set; }
        public int AmoutMovement { get; protected set; }
        public Table Tab { get; protected set; }

        public Piece(Table tab, Color color)
        {
            this.Position = null;
            this.Tab = tab;
            this.Color = color;
            this.AmoutMovement = 0;
        }

        public void IncrementAmountMovement()
        {
            AmoutMovement++;
        }

        public void DecreaseAmountMovement()
        {
            AmoutMovement--;
        }

        public bool HavePossibleMovements()
        {
            bool[,] mat = PossibleMovements();
            for(int i = 0; i < Tab.Lines; i++)
            {
                for(int j = 0; j < Tab.Columns; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CanMoveTo(Position position)
        {
            return PossibleMovements()[position.Line, position.Column];
        }

        public abstract bool[,] PossibleMovements();
       
    }
}
