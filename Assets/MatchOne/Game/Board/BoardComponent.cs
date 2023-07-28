using Entitas;
using Entitas.Generators.Attributes;
using UnityEngine;

namespace MatchOne
{
    [Context(typeof(GameContext)), Unique, Event(EventTarget.Any)]
    public sealed class BoardComponent : IComponent
    {
        public Vector2Int Size;
    }
}
