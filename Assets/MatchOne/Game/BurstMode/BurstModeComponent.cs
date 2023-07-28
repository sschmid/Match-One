using Entitas;
using Entitas.Generators.Attributes;

namespace MatchOne
{
    [Context(typeof(InputContext)), Unique, Event(EventTarget.Any), Event(EventTarget.Any, EventType.Removed)]
    public sealed class BurstModeComponent : IComponent { }
}
