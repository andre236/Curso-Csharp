namespace XadrezProject.Tabuleiro
{
    class Table
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        
        public bool HasPiece { get; set; }

        private Piece[,] _pieces;

        public Table(int lines, int columns)
        {
            this.Lines = lines;
            this.Columns = columns;
            _pieces = new Piece[lines, columns];
        }

        public Piece piece(int lines, int columns)
        {
            return _pieces[lines, columns];
        }

        public Piece piece(Position pos)
        {
            return _pieces[pos.Line, pos.Column];
        }

        public bool PieceNotNull(Position pos)
        {
            ValidatePosition(pos);
            return piece(pos) != null;
        }

        public void PutPiece(Piece p, Position pos)
        {
            if (PieceNotNull(pos))
            {
                throw new TableExceptions("Posição inválida!");
            }
            _pieces[pos.Line, pos.Column] = p;
            p.Position = pos;
        }

        public Piece RemovePiece(Position pos)
        {
            if(piece(pos) == null)
            {
                return null;
            }
            Piece aux = piece(pos);
            aux.Position = null;
            _pieces[pos.Line, pos.Column] = null;
            return aux;
        }

        public bool ValidPosition(Position pos)
        {
            if (pos.Line < 0 || pos.Line >= Lines || pos.Column < 0 || pos.Column >= Columns)
            {
                return false;
            }

            return true;
        }

        public void ValidatePosition(Position pos)
        {
            if (!ValidPosition(pos))
            {
                throw new TableExceptions("Posição inválida!");
            }
        }
    }
}
