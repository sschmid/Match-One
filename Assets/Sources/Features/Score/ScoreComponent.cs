using Entitas;
using Entitas.CodeGenerator;

[GameSession, SingleEntity]
public sealed class ScoreComponent : IComponent {

    public int value;
}
