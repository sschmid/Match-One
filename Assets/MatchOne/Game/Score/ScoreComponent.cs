using Entitas;
using Entitas.Generators.Attributes;

namespace MatchOne
{
    [Context(typeof(GameStateContext)), Unique, Event(EventTarget.Any)]
    public sealed class ScoreComponent : IComponent
    {
        public int Value;
    }
}
