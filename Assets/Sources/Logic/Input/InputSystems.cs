public sealed class InputSystems : Feature {

    public InputSystems(Contexts contexts) {
        Add(new EmitInputSystem(contexts));
        Add(new ProcessInputSystem(contexts));
    }
}
