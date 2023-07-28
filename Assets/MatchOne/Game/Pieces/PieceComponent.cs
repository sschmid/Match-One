using Entitas;
using Entitas.Generators.Attributes;

namespace MatchOne
{
    [Context(typeof(GameContext))]
    public sealed class PieceComponent : IComponent
    {
        public int Type;
    }
}
