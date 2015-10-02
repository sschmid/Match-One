namespace Entitas {
    public partial class Pool {
        public ISystem CreateGameBoardSystem() {
            return this.CreateSystem<GameBoardSystem>();
        }
    }
}