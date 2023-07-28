using Entitas;
using Entitas.Generators.Attributes;
using UnityEngine;

namespace MatchOne
{
    [Context(typeof(GameContext)), Event(EventTarget.Self)]
    public sealed class PositionComponent : IComponent
    {
        public Vector2Int Value;
    }
}
