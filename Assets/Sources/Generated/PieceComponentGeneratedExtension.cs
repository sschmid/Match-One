namespace Entitas {
    public partial class Entity {
        static readonly PieceComponent pieceComponent = new PieceComponent();

        public bool isPiece {
            get { return HasComponent(ComponentIds.Piece); }
            set {
                if (value != isPiece) {
                    if (value) {
                        AddComponent(ComponentIds.Piece, pieceComponent);
                    } else {
                        RemoveComponent(ComponentIds.Piece);
                    }
                }
            }
        }
    }

    public partial class Matcher {
        static AllOfMatcher _matcherPiece;

        public static AllOfMatcher Piece {
            get {
                if (_matcherPiece == null) {
                    _matcherPiece = new Matcher(ComponentIds.Piece);
                }

                return _matcherPiece;
            }
        }
    }
}
