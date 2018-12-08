using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Unique]
public sealed class BoardComponent : IComponent
{
    public Vector2Int value;
}
