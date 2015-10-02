namespace Entitas {
    public partial class Pool {
        public ISystem CreateRenderPositionSystem() {
            return this.CreateSystem<RenderPositionSystem>();
        }
    }
}