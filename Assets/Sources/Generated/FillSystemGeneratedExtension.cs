namespace Entitas {
    public partial class Pool {
        public ISystem CreateFillSystem() {
            return this.CreateSystem<FillSystem>();
        }
    }
}