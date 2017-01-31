using Entitas;
using Entitas.CodeGenerator.Api;

[GameSession, Unique]
public sealed class ScoreComponent : IComponent {

    public int value;
}
