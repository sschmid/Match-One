using Entitas;
using Entitas.Generators.Attributes;
using UnityEngine;

namespace MatchOne
{
    [Context(typeof(ConfigContext)), Unique]
    public sealed class PieceColorsConfigComponent : IComponent
    {
        public IPieceColorsConfig Value;
    }

    public interface IPieceColorsConfig
    {
        Color[] Colors { get; }
    }
}
