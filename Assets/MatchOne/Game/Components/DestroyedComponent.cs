using Entitas;
using Entitas.Generators.Attributes;

namespace MatchOne
{
    [Context(typeof(GameContext)), Event(EventTarget.Self), Cleanup(CleanupMode.DestroyEntity)]
    public sealed class DestroyedComponent : IComponent { }
}
