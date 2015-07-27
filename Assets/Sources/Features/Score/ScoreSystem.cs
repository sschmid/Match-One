using System.Collections.Generic;
using Entitas;

public class ScoreSystem : IStartSystem, IReactiveSystem, ISetPool {
    public IMatcher trigger { get { return Matcher.GameBoardElement; } }

    public GroupEventType eventType { get { return GroupEventType.OnEntityRemoved; } }

    Pool _pool;

    public void SetPool(Pool pool) {
        _pool = pool;
    }

    public void Start() {
        _pool.SetScore(0);
    }

    public void Execute(List<Entity> entities) {

        UnityEngine.Debug.Log("Score");

        _pool.ReplaceScore(_pool.score.score + entities.Count);
    }
}

