using XadrezProject.Tabuleiro;

namespace XadrezProject.xadrez
{
    class Torre : Piece
    {
        public Torre(Table tab, Color color) : base(tab, color)
        {
        }

        public override string ToString()
        {
            return "T";
        }
        private bool CanMove(Position pos)
        {
            Piece p = Tab.piece(pos);
            return p == null || p.Color != Color;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] mat = new bool[Tab.Lines, Tab.Columns];

            Position pos = new Position(0, 0);

            // Acima
            pos.DefinePosition(Position.Line - 1, Position.Column);
            
            while(Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if(Tab.piece(pos) != null && Tab.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line = pos.Line - 1;
            }

            // Abaixo
            pos.DefinePosition(Position.Line + 1, Position.Column);

            while (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Tab.piece(pos) != null && Tab.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line = pos.Line + 1;
            }

            // Direita
            pos.DefinePosition(Position.Line, Position.Column + 1);

            while (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;

                if (Tab.piece(pos) != null && Tab.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Column = pos.Column + 1;
            }
            // Esquerda
            pos.DefinePosition(Position.Line, Position.Column - 1);

            while (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Tab.piece(pos) != null && Tab.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Column = pos.Column - 1;
            }

            return mat;
        }
    }
}
