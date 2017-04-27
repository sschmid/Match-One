public sealed class ViewSystems : Feature {

    public ViewSystems(Contexts contexts) {
        Add(new RemoveViewSystem(contexts));
        Add(new AddViewSystem(contexts));
        Add(new SetViewPositionSystem(contexts));
        Add(new AnimatePositionSystem(contexts));
    }
}
