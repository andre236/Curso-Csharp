using XadrezProject.Tabuleiro;

namespace XadrezProject.xadrez
{
    class Rei : Piece
    {
        public Rei(Table tab, Color color) : base(tab, color)
        {

        }

        public override string ToString()
        {
            return "R";
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

            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }


            // NE
            pos.DefinePosition(Position.Line - 1, Position.Column + 1);

            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // Direita
            pos.DefinePosition(Position.Line, Position.Column + 1);

            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // SE
            pos.DefinePosition(Position.Line + 1, Position.Column + 1);

            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // Abaixo
            pos.DefinePosition(Position.Line + 1, Position.Column);

            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // SO
            pos.DefinePosition(Position.Line + 1, Position.Column - 1);

            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }


            // ESQUERDA
            pos.DefinePosition(Position.Line, Position.Column - 1);

            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // NO
            pos.DefinePosition(Position.Line - 1, Position.Column - 1);

            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            return mat;
        }
    }
}
