using Entitas;

public class CreateGameBoardSystem : IStartSystem, ISetPool {
    Pool _pool;

    public void SetPool(Pool pool) {
        _pool = pool;
    }

    public void Start() {

        UnityEngine.Debug.Log("CreateGameBoardSystem");

        _pool.SetGameBoard(8, 9);
    }
}

