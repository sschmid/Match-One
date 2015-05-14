using Entitas;

namespace Entitas {
    public partial class Entity {
        static readonly GameBoardElementComponent gameBoardElementComponent = new GameBoardElementComponent();

        public bool isGameBoardElement {
            get { return HasComponent(GameComponentIds.GameBoardElement); }
            set {
                if (value != isGameBoardElement) {
                    if (value) {
                        AddComponent(GameComponentIds.GameBoardElement, gameBoardElementComponent);
                    } else {
                        RemoveComponent(GameComponentIds.GameBoardElement);
                    }
                }
            }
        }
    }
}

    public partial class GameMatcher {
        static AllOfMatcher _matcherGameBoardElement;

        public static AllOfMatcher GameBoardElement {
            get {
                if (_matcherGameBoardElement == null) {
                    _matcherGameBoardElement = new GameMatcher(GameComponentIds.GameBoardElement);
                }

                return _matcherGameBoardElement;
            }
        }
    }
