using Entitas;
using Entitas.CodeGeneration.Attributes;

[GameState, Unique, Event(EventTarget.Any)]
public sealed class ScoreComponent : IComponent {
    public int value;
}
