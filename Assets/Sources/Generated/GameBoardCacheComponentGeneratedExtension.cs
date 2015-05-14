using Entitas;

namespace Entitas {
    public partial class Entity {
        public GameBoardCacheComponent gameBoardCache { get { return (GameBoardCacheComponent)GetComponent(GameComponentIds.GameBoardCache); } }

        public bool hasGameBoardCache { get { return HasComponent(GameComponentIds.GameBoardCache); } }

        public void AddGameBoardCache(GameBoardCacheComponent component) {
            AddComponent(GameComponentIds.GameBoardCache, component);
        }

        public void AddGameBoardCache(Entitas.Entity[,] newGrid) {
            var component = new GameBoardCacheComponent();
            component.grid = newGrid;
            AddGameBoardCache(component);
        }

        public void ReplaceGameBoardCache(Entitas.Entity[,] newGrid) {
            GameBoardCacheComponent component;
            if (hasGameBoardCache) {
                WillRemoveComponent(GameComponentIds.GameBoardCache);
                component = gameBoardCache;
            } else {
                component = new GameBoardCacheComponent();
            }
            component.grid = newGrid;
            ReplaceComponent(GameComponentIds.GameBoardCache, component);
        }

        public void RemoveGameBoardCache() {
            RemoveComponent(GameComponentIds.GameBoardCache);
        }
    }

    public partial class Pool {
        public Entity gameBoardCacheEntity { get { return GetGroup(GameMatcher.GameBoardCache).GetSingleEntity(); } }

        public GameBoardCacheComponent gameBoardCache { get { return gameBoardCacheEntity.gameBoardCache; } }

        public bool hasGameBoardCache { get { return gameBoardCacheEntity != null; } }

        public Entity SetGameBoardCache(GameBoardCacheComponent component) {
            if (hasGameBoardCache) {
                throw new SingleEntityException(GameMatcher.GameBoardCache);
            }
            var entity = CreateEntity();
            entity.AddGameBoardCache(component);
            return entity;
        }

        public Entity SetGameBoardCache(Entitas.Entity[,] newGrid) {
            if (hasGameBoardCache) {
                throw new SingleEntityException(GameMatcher.GameBoardCache);
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
}

    public partial class GameMatcher {
        static AllOfMatcher _matcherGameBoardCache;

        public static AllOfMatcher GameBoardCache {
            get {
                if (_matcherGameBoardCache == null) {
                    _matcherGameBoardCache = new GameMatcher(GameComponentIds.GameBoardCache);
                }

                return _matcherGameBoardCache;
            }
        }
    }
