using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Config, Unique, ComponentName("GameConfig")]
public interface IGameConfig
{
    Vector2Int BoardSize { get; }
    float BlockerProbability { get; }
}
