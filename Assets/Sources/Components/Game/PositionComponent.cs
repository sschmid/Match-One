using Entitas;
using Entitas.CodeGeneration.Attributes;

[Event(EventTarget.Self)]
public sealed class PositionComponent : IComponent {

    [EntityIndex]
    public IntVector2 value;
}
