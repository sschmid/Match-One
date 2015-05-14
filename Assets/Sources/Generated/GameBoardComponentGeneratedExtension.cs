using Entitas;

namespace Entitas {
    public partial class Entity {
        public GameBoardComponent gameBoard { get { return (GameBoardComponent)GetComponent(GameComponentIds.GameBoard); } }

        public bool hasGameBoard { get { return HasComponent(GameComponentIds.GameBoard); } }

        public void AddGameBoard(GameBoardComponent component) {
            AddComponent(GameComponentIds.GameBoard, component);
        }

        public void AddGameBoard(int newColumns, int newRows) {
            var component = new GameBoardComponent();
            component.columns = newColumns;
            component.rows = newRows;
            AddGameBoard(component);
        }

        public void ReplaceGameBoard(int newColumns, int newRows) {
            GameBoardComponent component;
            if (hasGameBoard) {
                WillRemoveComponent(GameComponentIds.GameBoard);
                component = gameBoard;
            } else {
                component = new GameBoardComponent();
            }
            component.columns = newColumns;
            component.rows = newRows;
            ReplaceComponent(GameComponentIds.GameBoard, component);
        }

        public void RemoveGameBoard() {
            RemoveComponent(GameComponentIds.GameBoard);
        }
    }

    public partial class Pool {
        public Entity gameBoardEntity { get { return GetGroup(GameMatcher.GameBoard).GetSingleEntity(); } }

        public GameBoardComponent gameBoard { get { return gameBoardEntity.gameBoard; } }

        public bool hasGameBoard { get { return gameBoardEntity != null; } }

        public Entity SetGameBoard(GameBoardComponent component) {
            if (hasGameBoard) {
                throw new SingleEntityException(GameMatcher.GameBoard);
            }
            var entity = CreateEntity();
            entity.AddGameBoard(component);
            return entity;
        }

        public Entity SetGameBoard(int newColumns, int newRows) {
            if (hasGameBoard) {
                throw new SingleEntityException(GameMatcher.GameBoard);
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
}

    public partial class GameMatcher {
        static AllOfMatcher _matcherGameBoard;

        public static AllOfMatcher GameBoard {
            get {
                if (_matcherGameBoard == null) {
                    _matcherGameBoard = new GameMatcher(GameComponentIds.GameBoard);
                }

                return _matcherGameBoard;
            }
        }
    }
