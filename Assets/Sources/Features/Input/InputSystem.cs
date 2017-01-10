using Entitas;
using UnityEngine;

public sealed class InputSystem : IExecuteSystem, ICleanupSystem {

    readonly Context _pool;
    readonly Group _inputs;

    public InputSystem(Contexts contexts) {
        _pool = contexts.input;
        _inputs = _pool.GetGroup(InputMatcher.Input);
    }

    public void Execute() {
        if(Input.GetKeyDown("b")) {
            _pool.isBurstMode = !_pool.isBurstMode;
        }

        var input = _pool.isBurstMode
            ? Input.GetMouseButton(0)
            : Input.GetMouseButtonDown(0);

        if(input) {
            var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 100);
            if(hit.collider != null) {
                var pos = hit.collider.transform.position;

                _pool.CreateEntity()
                     .AddInput((int)pos.x, (int)pos.y);
            }
        }
    }

    public void Cleanup() {
        foreach(var e in _inputs.GetEntities()) {
            _pool.DestroyEntity(e);
        }
    }
}
