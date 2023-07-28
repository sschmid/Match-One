using Entitas;
using Entitas.Generators.Attributes;
using UnityEngine;

namespace MatchOne
{
    [Context(typeof(ConfigContext)), Unique]
    public sealed class GameConfigComponent : IComponent
    {
        public IGameConfig Value;
    }

    public interface IGameConfig
    {
        Vector2Int BoardSize { get; }
        float BlockerProbability { get; }
    }
}
