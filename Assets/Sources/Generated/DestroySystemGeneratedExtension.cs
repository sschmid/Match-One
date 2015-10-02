namespace Entitas {
    public partial class Pool {
        public ISystem CreateDestroySystem() {
            return this.CreateSystem<DestroySystem>();
        }
    }
}