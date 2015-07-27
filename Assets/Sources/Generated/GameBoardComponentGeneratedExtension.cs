using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public GameBoardComponent gameBoard { get { return (GameBoardComponent)GetComponent(ComponentIds.GameBoard); } }

        public bool hasGameBoard { get { return HasComponent(ComponentIds.GameBoard); } }

        static readonly Stack<GameBoardComponent> _gameBoardComponentPool = new Stack<GameBoardComponent>();

        public static void ClearGameBoardComponentPool() {
            _gameBoardComponentPool.Clear();
        }

        public Entity AddGameBoard(int newColumns, int newRows) {
            var component = _gameBoardComponentPool.Count > 0 ? _gameBoardComponentPool.Pop() : new GameBoardComponent();
            component.columns = newColumns;
            component.rows = newRows;
            return AddComponent(ComponentIds.GameBoard, component);
        }

        public Entity ReplaceGameBoard(int newColumns, int newRows) {
            var previousComponent = gameBoard;
            var component = _gameBoardComponentPool.Count > 0 ? _gameBoardComponentPool.Pop() : new GameBoardComponent();
            component.columns = newColumns;
            component.rows = newRows;
            ReplaceComponent(ComponentIds.GameBoard, component);
            if (previousComponent != null) {
                _gameBoardComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveGameBoard() {
            var component = gameBoard;
            RemoveComponent(ComponentIds.GameBoard);
            _gameBoardComponentPool.Push(component);
            return this;
        }
    }

    public partial class Pool {
        public Entity gameBoardEntity { get { return GetGroup(Matcher.GameBoard).GetSingleEntity(); } }

        public GameBoardComponent gameBoard { get { return gameBoardEntity.gameBoard; } }

        public bool hasGameBoard { get { return gameBoardEntity != null; } }

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
