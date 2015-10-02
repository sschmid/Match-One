namespace Entitas {
    public partial class Pool {
        public ISystem CreateScoreSystem() {
            return this.CreateSystem<ScoreSystem>();
        }
    }
}