namespace Entitas {
    public partial class Pool {
        public ISystem CreateProcessInputSystem() {
            return this.CreateSystem<ProcessInputSystem>();
        }
    }
}