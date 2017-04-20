using Entitas;

public sealed class InputSystems : Feature {

    public InputSystems(Contexts contexts) : base("Input Systems") {
        Add(new EmitInputSystem(contexts));
        Add(new ProcessInputSystem(contexts));
    }
}
