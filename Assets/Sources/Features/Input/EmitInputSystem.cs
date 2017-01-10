using Entitas;
using UnityEngine;

public sealed class EmitInputSystem : IExecuteSystem, ICleanupSystem {

    readonly Context _context;
    readonly Group _inputs;

    public EmitInputSystem(Contexts contexts) {
        _context = contexts.input;
        _inputs = _context.GetGroup(InputMatcher.Input);
    }

    public void Execute() {
        if(Input.GetKeyDown("b")) {
            _context.isBurstMode = !_context.isBurstMode;
        }

        var input = _context.isBurstMode
            ? Input.GetMouseButton(0)
            : Input.GetMouseButtonDown(0);

        if(input) {
            var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 100);
            if(hit.collider != null) {
                var pos = hit.collider.transform.position;

                _context.CreateEntity()
                     .AddInput((int)pos.x, (int)pos.y);
            }
        }
    }

    public void Cleanup() {
        foreach(var e in _inputs.GetEntities()) {
            _context.DestroyEntity(e);
        }
    }
}
