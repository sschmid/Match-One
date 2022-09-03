using Entitas;
using Entitas.CodeGeneration.Attributes;

[Event(EventTarget.Self), Cleanup(CleanupMode.DestroyEntity)]
public sealed class DestroyedComponent : IComponent
{
}
