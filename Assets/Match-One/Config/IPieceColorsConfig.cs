using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Config, Unique, ComponentName("PieceColorsConfig")]
public interface IPieceColorsConfig
{
    Color[] Colors { get; }
}
