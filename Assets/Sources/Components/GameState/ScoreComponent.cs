using Entitas;
using Entitas.CodeGeneration.Attributes;

[GameState, Unique, Event(false)]
public sealed class ScoreComponent : IComponent {

    public int value;
}
