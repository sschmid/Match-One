namespace Entitas {
    public partial class Entity {
        public GameBoardComponent gameBoard { get { return (GameBoardComponent)GetComponent(ComponentIds.GameBoard); } }

        public bool hasGameBoard { get { return HasComponent(ComponentIds.GameBoard); } }

        public Entity AddGameBoard(GameBoardComponent component) {
            return AddComponent(ComponentIds.GameBoard, component);
        }

        public Entity AddGameBoard(int newColumns, int newRows) {
            var component = new GameBoardComponent();
            component.columns = newColumns;
            component.rows = newRows;
            return AddGameBoard(component);
        }

        public Entity ReplaceGameBoard(int newColumns, int newRows) {
            GameBoardComponent component;
            if (hasGameBoard) {
                WillRemoveComponent(ComponentIds.GameBoard);
                component = gameBoard;
            } else {
                component = new GameBoardComponent();
            }
            component.columns = newColumns;
            component.rows = newRows;
            return ReplaceComponent(ComponentIds.GameBoard, component);
        }

        public Entity RemoveGameBoard() {
            return RemoveComponent(ComponentIds.GameBoard);
        }
    }

    public partial class Pool {
        public Entity gameBoardEntity { get { return GetGroup(Matcher.GameBoard).GetSingleEntity(); } }

        public GameBoardComponent gameBoard { get { return gameBoardEntity.gameBoard; } }

        public bool hasGameBoard { get { return gameBoardEntity != null; } }

        public Entity SetGameBoard(GameBoardComponent component) {
            if (hasGameBoard) {
                throw new SingleEntityException(Matcher.GameBoard);
            }
            var entity = CreateEntity();
            entity.AddGameBoard(component);
            return entity;
        }

        public Entity SetGameBoard(int newColumns, int newRows) {
            if (hasGameBoard) {
                throw new SingleEntityException(Matcher.GameBoard);
            }
            var entity = CreateEntity();
            entity.AddGameBoard(newColumns, newRows);
            return entity;
        }

        public Entity ReplaceGameBoard(int newColumns, int newRows) {
            var entity = gameBoardEntity;
            if (entity == null) {
                entity = SetGameBoard(newColumns, newRows);
            } else {
                entity.ReplaceGameBoard(newColumns, newRows);
            }

            return entity;
        }

        public void RemoveGameBoard() {
            DestroyEntity(gameBoardEntity);
        }
    }

    public partial class Matcher {
        static AllOfMatcher _matcherGameBoard;

        public static AllOfMatcher GameBoard {
            get {
                if (_matcherGameBoard == null) {
                    _matcherGameBoard = new Matcher(ComponentIds.GameBoard);
                }

                return _matcherGameBoard;
            }
        }
    }
}
