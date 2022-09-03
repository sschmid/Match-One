using System;
using Entitas;
using UnityEngine;

public sealed class InputSystem : IExecuteSystem
{
    readonly Contexts _contexts;

    public InputSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        EmitInput();
    }

    void EmitInput()
    {
        var input = _contexts.input.isBurstMode
            ? Input.GetMouseButton(0)
            : Input.GetMouseButtonDown(0);

        if (input)
        {
            var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var e = _contexts.input.CreateEntity();
            e.AddInput(new Vector2Int(
                (int)Math.Round(mouseWorldPos.x),
                (int)Math.Round(mouseWorldPos.y)
            ));
        }
    }
}
