using Entitas;
using Entitas.CodeGeneration.Attributes;

[Input, Unique, Event(EventTarget.Any), Event(EventTarget.Any, EventType.Removed)]
public sealed class BurstModeComponent : IComponent {
}
