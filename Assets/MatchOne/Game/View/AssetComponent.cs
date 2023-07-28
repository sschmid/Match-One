using Entitas;
using Entitas.Generators.Attributes;

namespace MatchOne
{
    [Context(typeof(GameContext))]
    public sealed class AssetComponent : IComponent
    {
        public string Value;
    }
}
