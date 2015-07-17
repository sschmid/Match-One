namespace Entitas {
    public partial class Pool {
        public ISystem CreateFallSystem() {
            return this.CreateSystem<FallSystem>();
        }
    }
}