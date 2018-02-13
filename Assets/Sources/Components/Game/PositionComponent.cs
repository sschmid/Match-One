using Entitas;
using Entitas.CodeGeneration.Attributes;

[Event(true)]
public sealed class PositionComponent : IComponent {

    [EntityIndex]
    public IntVector2 value;
}
