using System.Collections.Generic;
using Entitas;

public sealed class ScoreSystem : ISetPools, IInitializeSystem, IReactiveSystem {

    public TriggerOnEvent trigger { get { return CoreMatcher.GameBoardElement.OnEntityRemoved(); } }

    Contexts _pools;

    public void SetPools(Contexts pools) {
        _pools = pools;
    }

    public void Initialize() {
        _pools.score.SetScore(0);
    }

    public void Execute(List<Entity> entities) {
        _pools.score.ReplaceScore(_pools.score.score.value + entities.Count);
    }
}
