using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public sealed class PositionComponent : IComponent {

    [EntityIndex]
    public IntVector2 value;
}
