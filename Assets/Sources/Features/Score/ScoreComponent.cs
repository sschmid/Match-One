using Entitas;
using Entitas.CodeGenerator;

[Score, SingleEntity]
public sealed class ScoreComponent : IComponent {

    public int value;
}
