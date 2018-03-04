using Entitas;
using Entitas.CodeGeneration.Attributes;

[Input, Unique, Event(false), Event(false, EventType.Removed)]
public sealed class BurstModeComponent : IComponent {
}
