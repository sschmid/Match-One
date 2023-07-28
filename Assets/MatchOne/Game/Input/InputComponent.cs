using Entitas;
using Entitas.Generators.Attributes;
using UnityEngine;

namespace MatchOne
{
    [Context(typeof(InputContext)), Unique, Cleanup(CleanupMode.DestroyEntity)]
    public sealed class InputComponent : IComponent
    {
        public Vector2Int Value;
    }
}
