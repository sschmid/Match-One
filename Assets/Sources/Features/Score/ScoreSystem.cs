using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class ScoreSystem : IInitializeSystem, IReactiveSystem, ISetPool {
    public TriggerOnEvent trigger { get { return Matcher.GameBoardElement.OnEntityRemoved(); } }

    Pool _pool;

    public void SetPool(Pool pool) {
        _pool = pool;
    }

    public void Initialize() {
        _pool.SetScore(0);
    }

    public void Execute(List<Entity> entities) {

        Debug.Log("Score");

        _pool.ReplaceScore(_pool.score.value + entities.Count);
    }
}

