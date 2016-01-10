using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public GameBoardCacheComponent gameBoardCache { get { return (GameBoardCacheComponent)GetComponent(ComponentIds.GameBoardCache); } }

        public bool hasGameBoardCache { get { return HasComponent(ComponentIds.GameBoardCache); } }

        static readonly Stack<GameBoardCacheComponent> _gameBoardCacheComponentPool = new Stack<GameBoardCacheComponent>();

        public static void ClearGameBoardCacheComponentPool() {
            _gameBoardCacheComponentPool.Clear();
        }

        public Entity AddGameBoardCache(Entitas.Entity[,] newGrid) {
            var component = _gameBoardCacheComponentPool.Count > 0 ? _gameBoardCacheComponentPool.Pop() : new GameBoardCacheComponent();
            component.grid = newGrid;
            return AddComponent(ComponentIds.GameBoardCache, component);
        }

        public Entity ReplaceGameBoardCache(Entitas.Entity[,] newGrid) {
            var previousComponent = hasGameBoardCache ? gameBoardCache : null;
            var component = _gameBoardCacheComponentPool.Count > 0 ? _gameBoardCacheComponentPool.Pop() : new GameBoardCacheComponent();
            component.grid = newGrid;
            ReplaceComponent(ComponentIds.GameBoardCache, component);
            if (previousComponent != null) {
                _gameBoardCacheComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveGameBoardCache() {
            var component = gameBoardCache;
            RemoveComponent(ComponentIds.GameBoardCache);
            _gameBoardCacheComponentPool.Push(component);
            return this;
        }
    }

    public partial class Pool {
        public Entity gameBoardCacheEntity { get { return GetGroup(Matcher.GameBoardCache).GetSingleEntity(); } }

        public GameBoardCacheComponent gameBoardCache { get { return gameBoardCacheEntity.gameBoardCache; } }

        public bool hasGameBoardCache { get { return gameBoardCacheEntity != null; } }

        public Entity SetGameBoardCache(Entitas.Entity[,] newGrid) {
            if (hasGameBoardCache) {
                throw new EntitasException("Could not set gameBoardCache!\n" + this + " already has an entity with GameBoardCacheComponent!",
                    "You should check if the pool already has a gameBoardCacheEntity before setting it or use pool.ReplaceGameBoardCache().");
            }
            var entity = CreateEntity();
            entity.AddGameBoardCache(newGrid);
            return entity;
        }

        public Entity ReplaceGameBoardCache(Entitas.Entity[,] newGrid) {
            var entity = gameBoardCacheEntity;
            if (entity == null) {
                entity = SetGameBoardCache(newGrid);
            } else {
                entity.ReplaceGameBoardCache(newGrid);
            }

            return entity;
        }

        public void RemoveGameBoardCache() {
            DestroyEntity(gameBoardCacheEntity);
        }
    }

    public partial class Matcher {
        static IMatcher _matcherGameBoardCache;

        public static IMatcher GameBoardCache {
            get {
                if (_matcherGameBoardCache == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.GameBoardCache);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherGameBoardCache = matcher;
                }

                return _matcherGameBoardCache;
            }
        }
    }
}
