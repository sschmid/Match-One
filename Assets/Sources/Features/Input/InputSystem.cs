using Entitas;
using UnityEngine;

public sealed class InputSystem : ISetPool, IExecuteSystem, ICleanupSystem {

    Pool _pool;
    Group _inputs;

    public void SetPool(Pool pool) {
        _pool = pool;
        _inputs = pool.GetGroup(InputMatcher.Input);
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
