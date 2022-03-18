using XadrezProject.Tabuleiro;

namespace XadrezProject.xadrez
{
    class GameXadrez
    {
        private HashSet<Piece> _pieces;
        private HashSet<Piece> _captured;
        public Color CurrentPlayer { get; private set; }
        public int Turn { get; private set; }
        public Table Tab { get; private set; }
        public bool EndGame { get; private set; }
        public bool Check { get; private set; }


        public GameXadrez()
        {
            Tab = new Table(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            EndGame = false;
            Check = false;
            _pieces = new HashSet<Piece>();
            _captured = new HashSet<Piece>();
            PutPieces();

        }

        private void ChangePlayer()
        {
            if (CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            }
            else
            {
                CurrentPlayer = Color.White;
            }
        }

        private Color Enemy(Color color)
        {
            if(color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        private Piece Rei(Color color)
        {
            foreach(Piece p in PiecesOnGame(color))
            {
                if(p is Rei)
                {
                    return p;
                }
            }
            return null;
        }

        public bool IsCheck(Color color)
        {
            Piece r = Rei(color);

            if(r == null)
            {
                throw new TableExceptions("Não tem rei da cor: "+color+ " no tabuleiro.");
            }

            foreach (Piece p in PiecesOnGame(Enemy(color)))
            {
                bool[,] mat = p.PossibleMovements();
                if (mat[r.Position.Line, r.Position.Column])
                {
                    return true;
                }
            }
            return false;
        }

        public Piece ExecuteMovement(Position origin, Position destiny)
        {
            Piece p = Tab.RemovePiece(origin);
            p.IncrementAmountMovement();
            Piece capturedPiece = Tab.RemovePiece(destiny);
            Tab.PutPiece(p, destiny);
            if(capturedPiece != null)
            {
                _captured.Add(capturedPiece);
            }
            return capturedPiece;
        }

        public void UndoPlay(Position origin, Position destiny, Piece capturedPiece)
        {
            Piece p = Tab.RemovePiece(destiny);
            p.DecreaseAmountMovement();
            if(capturedPiece != null)
            {
                Tab.PutPiece(capturedPiece, destiny);
                _captured.Remove(capturedPiece);
            }
            Tab.PutPiece(p, origin);
        }

        public void DoingMovement(Position origin, Position destiny)
        {
            Piece capturedPiece = ExecuteMovement(origin, destiny);
            
            if (IsCheck(CurrentPlayer))
            {
                UndoPlay(origin, destiny, capturedPiece);
                throw new TableExceptions("Você não pode se colocar em xeque!");
            }

            if (IsCheck(Enemy(CurrentPlayer)))
            {
                Check = true;
            }
            else
            {
                Check = false;
            }
            Turn++;
            ChangePlayer();
        }

        public void ValidateOriginPosition(Position pos)
        {
            if(Tab.piece(pos) == null)
            {
                throw new TableExceptions("Não existe uma peça nessa posição.");

            }
            if(CurrentPlayer != Tab.piece(pos).Color)
            {
                throw new TableExceptions("A peça de origem escolhida não é sua!!");
            }
            if (!Tab.piece(pos).HavePossibleMovements())
            {
                throw new TableExceptions("Não há movimentos possíveis para a peça de origem escolhida!");
            }
        }

        public void ValidateDestinyPosition(Position origin, Position destiny)
        {
            if (!Tab.piece(origin).CanMoveTo(destiny))
            {
                throw new TableExceptions("Posição de destino inválida!");
            }
        }




        public HashSet<Piece> CapturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach(Piece x in _captured)
            {
                if(x.Color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Piece> PiecesOnGame(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in _captured)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(CapturedPieces(color));
            return aux;
        }

        public void PutNewPiece(char column, int line, Piece piece)
        {
            Tab.PutPiece(piece, new PositionXadrez(column, line).ToPosition());
            _pieces.Add(piece);
        }

        private void PutPieces()
        {
            PutNewPiece('c', 1, new Torre(Tab, Color.White));
            PutNewPiece('c', 2, new Torre(Tab, Color.White));
            PutNewPiece('d', 2, new Torre(Tab, Color.White));
            PutNewPiece('e', 2, new Torre(Tab, Color.White));
            PutNewPiece('e', 1, new Torre(Tab, Color.White));
            PutNewPiece('d', 1, new Rei(Tab, Color.White));

            PutNewPiece('c',8, new Torre(Tab, Color.Black));
            PutNewPiece('c', 7, new Torre(Tab, Color.Black));
            PutNewPiece('d', 7, new Torre(Tab, Color.Black));
            PutNewPiece('e', 7, new Torre(Tab, Color.Black));
            PutNewPiece('e',8, new Torre(Tab, Color.Black));
            PutNewPiece('d', 8, new Rei(Tab, Color.Black));

        }

    }
}
