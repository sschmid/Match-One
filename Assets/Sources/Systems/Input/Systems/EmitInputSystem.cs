using Entitas;
using UnityEngine;

public sealed class EmitInputSystem : IExecuteSystem, ICleanupSystem {

    readonly Contexts _contexts;
    readonly IGroup<InputEntity> _inputs;

    public EmitInputSystem(Contexts contexts) {
        _contexts = contexts;
        _inputs = _contexts.input.GetGroup(InputMatcher.Input);
    }

    public void Execute() {
        if (Input.GetKeyDown("b")) {
            _contexts.input.isBurstMode = !_contexts.input.isBurstMode;
        }

        var input = _contexts.input.isBurstMode
            ? Input.GetMouseButton(0)
            : Input.GetMouseButtonDown(0);

        if (input) {
            var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 100);
            if (hit.collider != null) {
                var pos = hit.collider.transform.position;
                _contexts.input.CreateEntity()
                    .AddInput((int)pos.x, (int)pos.y);
            }
        }
    }

    public void Cleanup() {
        foreach (var e in _inputs.GetEntities()) {
            e.Destroy();
        }
    }
}
