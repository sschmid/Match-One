using Entitas;
using Entitas.Generators.Attributes;

namespace MatchOne
{
    [Context(typeof(GameContext))]
    public sealed class ViewComponent : IComponent
    {
        public IView Value;
    }
}
