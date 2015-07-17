namespace Entitas {
    public partial class Pool {
        public ISystem CreateCreateGameBoardCacheSystem() {
            return this.CreateSystem<CreateGameBoardCacheSystem>();
        }
    }
}