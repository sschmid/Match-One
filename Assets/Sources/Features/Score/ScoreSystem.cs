using Entitas;

public class ScoreSystem : IStartSystem, IReactiveSystem, ISetPool {
    public IMatcher GetTriggeringMatcher() {
        return Matcher.GameBoardElement;
    }

    public GroupEventType GetEventType() {
        return GroupEventType.OnEntityRemoved;
    }

    Pool _pool;

    public void SetPool(Pool pool) {
        _pool = pool;
    }

    public void Start() {
        _pool.SetScore(0);
    }

    public void Execute(Entity[] entities) {

        UnityEngine.Debug.Log("Score");

        _pool.ReplaceScore(_pool.score.score + entities.Length);
    }
}

