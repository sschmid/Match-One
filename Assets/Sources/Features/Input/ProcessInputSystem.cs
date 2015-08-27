using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class ProcessInputSystem : IReactiveSystem, ISetPool {
    public TriggerOnEvent trigger { get { return Matcher.Input.OnEntityAdded(); } }

    Pool _pool;

    public void SetPool(Pool pool) {
        _pool = pool;
    }

    public void Execute(List<Entity> entities) {

        Debug.Log("Process Input");

        var inputEntity = entities.SingleEntity();
        var input = inputEntity.input;
        var e = _pool.gameBoardCache.grid[input.x, input.y];
        if (e != null && e.isInteractive) {
            e.isDestroy = true;
        }

        _pool.DestroyEntity(inputEntity);
    }
}

