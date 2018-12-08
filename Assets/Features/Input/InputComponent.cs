using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Input, Cleanup(CleanupMode.DestroyEntity)]
public sealed class InputComponent : IComponent
{
    public Vector2Int value;
}
