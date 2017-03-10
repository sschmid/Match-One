using Entitas;
using Entitas.CodeGenerator.Api;

[Game]
public sealed class PositionComponent : IComponent {

    [EntityIndex]
    public IntVector2 value;
}
