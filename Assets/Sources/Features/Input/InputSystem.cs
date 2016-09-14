using Entitas;
using UnityEngine;

public class InputSystem : ISetPool, IExecuteSystem {

    Pool _pool;

    public void SetPool(Pool pool) {
        _pool = pool;
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
                Pools.sharedInstance.pool.CreateEntity()
                     .AddInput((int)pos.x, (int)pos.y);
            }
        }
    }
}
