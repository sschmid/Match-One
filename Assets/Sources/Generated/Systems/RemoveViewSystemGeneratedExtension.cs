namespace Entitas {
    public partial class Pool {
        public ISystem CreateRemoveViewSystem() {
            return this.CreateSystem<RemoveViewSystem>();
        }
    }
}