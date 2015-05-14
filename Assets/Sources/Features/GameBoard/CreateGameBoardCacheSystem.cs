using Entitas;

public class CreateGameBoardCacheSystem : IStartSystem, IReactiveSystem, ISetPool {

    Pool _pool;
    GameBoardComponent _gameBoard;
    Group _gameBoardElements;

    public IMatcher GetTriggeringMatcher() {
        return Matcher.AllOf(Matcher.GameBoardElement);
    }

    public GroupEventType GetEventType() {
        return GroupEventType.OnEntityAddedOrRemoved;
    }

    public void SetPool(Pool pool) {
        _pool = pool;
    }

    public void Start() {
        _gameBoard = _pool.gameBoard;
        _gameBoardElements = _pool.GetGroup(Matcher.AllOf(Matcher.GameBoardElement, Matcher.Position));
        updateGrid();
    }

    public void Execute(Entity[] entities) {
        updateGrid();
    }

    void updateGrid() {

        UnityEngine.Debug.Log("CreateGameBoardCacheSystem");

        var grid = new Entity[_gameBoard.columns, _gameBoard.rows];
        foreach (var e in _gameBoardElements.GetEntities()) {
            var pos = e.position;
            grid[pos.x, pos.y] = e;
        }

        _pool.ReplaceGameBoardCache(grid);
    }
}

