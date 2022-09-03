using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Unique, Event(EventTarget.Any)]
public sealed class BoardComponent : IComponent
{
    public Vector2Int Size;
}
